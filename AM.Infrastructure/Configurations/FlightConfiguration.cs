using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // renommer la table associative 
            builder.HasMany(f => f.Passengers)
                .WithMany(p => p.Flights)
                .UsingEntity(t => t.ToTable("VolsPassenger"));

            //Config de FK
            //builder.HasOne(f => f.Plane)
            //    .WithMany(p => p.Flights)            <=> [FForeignKey()]
            //    .HasForeignKey(f => f.PlaneFK)
            //    .OnDelete(DeleteBehavior.Cascade);


          

        }
    }
}
