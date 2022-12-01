using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleAuthenticationDomain;
using SimpleAuthenticationDomain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAuthenticationData.DbContext
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        //passing configuration to the context
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //columns for identifiers need to over ride themselves
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
        }
        // need to explictly create a user since it has been added to the identityDbcontext implicitly
        //make sure dbset is within the namespace 
        //public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
