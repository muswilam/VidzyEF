using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy.EntityConfigurations
{
    public class VideoConfigurations : EntityTypeConfiguration<Video>
    {
        public VideoConfigurations()
        {
            Property(v => v.Name)
           .IsRequired()
           .HasMaxLength(255);

            HasRequired(v => v.Genre)
            .WithMany(g => g.Videos)
            .HasForeignKey(v => v.GenreId)
            .WillCascadeOnDelete(false);

        }
    }
}
