﻿using Microsoft.EntityFrameworkCore;
using OnionCarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Context
{
    public class CarBookContext : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAdress> FooterAdresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RentACar> RentACars { get; set; }
        public DbSet<RentACarProcess> RentACarProcesses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GHOST2023\\SQLEXPRESS;Database=OnionCarBook;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasOne(x => x.PickUpLocation).WithMany(x => x.PickUpReservation).HasForeignKey(x => x.PickUpLocationID).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Reservation>().HasOne(x => x.DropOffLocation).WithMany(x => x.DropOffReservation).HasForeignKey(x => x.DropOffLocationID).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Reservation>().Property(x => x.CarID).HasColumnType("int");
            modelBuilder.Entity<Reservation>().HasOne(x => x.Car).WithMany(x => x.Reservations).HasForeignKey(x => x.CarID).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
