using System;

using Microsoft.EntityFrameworkCore;

using R5T.H0001.Entities;
using R5T.T0250;


namespace R5T.H0001.DB01
{
    /// <summary>
    /// 
    /// </summary>
    [PhysicalDbContextImplementationMarker]
    public class DB01Context : DbContext, IPhysicalDbContextImplementationMarker,
        IProjectsDbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectFilePath> ProjectFilePaths { get; set; }

        public DbSet<ProjectFilePathList> ProjectFilePathLists { get; set; }

        public DbSet<ProjectFilePathListMapping> ProjectFilePathListMappings { get; set; }


        public DB01Context(DbContextOptions<DB01Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .For_ProjectsDbContext()
                ;
        }
    }
}
