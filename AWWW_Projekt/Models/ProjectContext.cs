using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AWWW_Projekt.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext([NotNullAttribute] DbContextOptions options) : base(options) { }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostComment> PostComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<PostsTags>()
            //    .HasKey(x => new { x.PostId, x.TagId });

            //modelBuilder.Entity<PostsTags>()
            //    .HasOne(x => x.Post)
            //    .WithMany(y => y.Tags);
        }
    }
}
