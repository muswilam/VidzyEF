using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    public enum Classification : byte
    {
        Silver = 1,
        Gold = 2,
        Platinum = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            //action movies sorted by name 
            var actionMovies = context.Videos
                .Where(m => m.Genre.Name == "Action")
                .OrderBy(m => m.Name);

            foreach(var actionMov in actionMovies)
            {
                //Console.WriteLine(actionMov.Name);
            }

            //Gold drama movies sorted by release date
            var goldDramaMovs = context.Videos
                .Where(m => m.Classification == Classification.Gold && m.Genre.Name == "Drama")
                .OrderByDescending(m => m.ReleaseDate);

            foreach (var goldMov in goldDramaMovs)
            {
                //Console.WriteLine(goldMov.Name + " --- " + goldMov.ReleaseDate);
            }

            //all movies projected into anonymous type with two props movieName and Genre
            var movieWithGenre = context.Videos
                .Select(m => new 
                { 
                    movieName = m.Name,
                    genre = m.Genre.Name
                });
            foreach (var mov in movieWithGenre)
            {
                //Console.WriteLine(mov.movieName);
            }

            //all movies grouped by thier classfication 
            var movsWithClassfication = context.Videos
                .GroupBy(m => m.Classification)
                .Select(g => new 
                {
                    classification = g.Key.ToString(),
                    videos = g.OrderBy(v => v.Name)
                });

            foreach (var cla in movsWithClassfication)
            {
                //Console.WriteLine("classifictaion : {0} ",cla.classification);
                foreach (var vid in cla.videos)
                {
                    //Console.WriteLine(vid.Name);
                }
            }

            //list of classification sorted and count of movies in them
            var classi = context.Videos
                .GroupBy(m => m.Classification);

            foreach (var cla in classi)
            {
                Console.WriteLine("{0} ({1})",cla.Key , cla.Count());
            }
            
            //list of genres and number of videos they include 
            var genres = context.Genres
                .GroupJoin(context.Videos,
                g => g.Id,
                v => v.GenreId, 
                (genre, videos) => new 
                {
                    gen = genre.Name,
                    vids = videos.Count()
                });

            foreach (var vid in genres)
            {
                //Console.WriteLine("{0} ({1})",vid.gen,vid.vids);
            }
        }
    }
}
