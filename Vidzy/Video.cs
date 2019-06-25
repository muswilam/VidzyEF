using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy
{
    public class Video
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        //nav props
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
        public Classification Classification { get; set; }
    }
}
