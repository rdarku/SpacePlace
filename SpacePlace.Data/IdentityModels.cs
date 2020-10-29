using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpacePlace.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - DOB;
                double totalAgeInYears = ageSpan.TotalDays / 365.25;
                int yearsOfAge = Convert.ToInt32(Math.Floor(totalAgeInYears));
                return yearsOfAge;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim(nameof(FullName), FullName.ToString()));
            userIdentity.AddClaim(new Claim(nameof(DOB), DOB.ToString()));
            userIdentity.AddClaim(new Claim(nameof(Age), Age.ToString()));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<SpaceOwner> SpaceOwners { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<Renter> Renters { get; set; }

        public DbSet<Space> Spaces { get; set; }

        public DbSet<SpaceAmenity> SpaceAmenities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpaceAmenity>()
                .HasKey(s => new { s.SpaceId, s.AmenityId });
                
        }



        public DbSet<Booking> Bookings { get; set; }


        public DbSet<Rating> Ratings { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Space>()
                .HasRequired(c => c.SpaceOwner)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}