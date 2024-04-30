using System;

using Microsoft.EntityFrameworkCore;

using R5T.H0001.Entities;
using R5T.T0250;


namespace R5T.H0001
{
    /// <summary>
    /// 
    /// </summary>
    [DbContextImplementationMarker]
    public class ProjectsDbContext : DbContext, IDbContextImplementationMarker,
        IProjectsDbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectFilePath> ProjectFilePaths { get; set; }

        public DbSet<ProjectFilePathList> ProjectFilePathLists { get; set; }

        public DbSet<ProjectFilePathListMapping> ProjectFilePathListMappings { get; set; }


        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
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
