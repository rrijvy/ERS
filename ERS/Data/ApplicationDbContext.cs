using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ERS.Models;

namespace ERS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<District> Districts { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public DbSet<Upazila> Upazilas { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ESSInfo> ESSInfos { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductTemplate> ProductTemplates { get; set; }

        public DbSet<EmpDistrictMap> EmpDistrictMaps { get; set; }

        public DbSet<EmpDivisionMap> EmpDivisionMaps { get; set; }

        public DbSet<EmpUpazilaMap> EmpUpazilaMaps { get; set; }

        public DbSet<EmpProductMap> EmpProductMaps { get; set; }
    }
}
