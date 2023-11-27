using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReservationTicket> ReservationTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=ISMAEL\SQLEXPRESS01;
 Initial Catalog=AirportM-4-ERP-BI1;Integrated Security=true;
 User ID=ISMAEL  ; Password=ismael150  ;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        //appel des classes de config : fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfig());


            //2 ème methode de fluent API et 2 eme de config de typeC <=> [Owned]
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName, full =>
            {
                full.Property(p => p.FirstName).IsRequired();
                full.Property(p => p.LastName);

            });
            // config des FK en utilisant Fluent API - 2 ème methode 
            // config de PassengerFk <=> [ForeignKey]


            //modelBuilder.Entity<Passenger>().HasMany(p => p.Reservations)
            //    .WithOne(r => r.Passenger).HasForeignKey(p => p.PassengerFK);


            // Cônfig de TicketFK
            //modelBuilder.Entity<ReservationTicket>().HasOne(r => r.Ticket)
            //    .WithMany(t => t.Reservations).HasForeignKey(p => p.TicketFK);
            //    

            // 2 ème methode de config de la clé composée 
            //modelBuilder.Entity<ReservationTicket>().HasKey(p => new
            //{
            //    p.PassengerFK,
            //    p.TicketFK,
            //    p.DateReservation
            //});


            // config de TPH : l'approche par défaut de l'heritage = discri de type int
            //modelBuilder.Entity<Passenger>()
            //    .HasDiscriminator<int>("PassengerType")
            //    .HasValue<Passenger>(0)
            //    .HasValue<Staff>(1)
            //    .HasValue<Traveller>(2);
            // de type Char
            //modelBuilder.Entity<Passenger>()
            //   .HasDiscriminator<char>("PassengerType")
            //   .HasValue<Passenger>('P')
            //   .HasValue<Staff>('S')
            //   .HasValue<Traveller>('T');


            //TPT : Table per Type 
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            base.OnModelCreating(modelBuilder);

        }
        //pré-convention
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
          //  configurationBuilder.Properties<string>().HaveMaxLength(50);
            base.ConfigureConventions(configurationBuilder);
        }
    }
}
