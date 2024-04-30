using System;

using Microsoft.EntityFrameworkCore;

using R5T.T0132;

using R5T.H0001.Entities;


namespace R5T.H0001
{
    [FunctionalityMarker]
    public partial interface IModelBuilderOperator : IFunctionalityMarker
    {
        public void Configure_ForProjectsDbContext(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasAlternateKey(x => x.Identity);
            modelBuilder.Entity<Project>().HasIndex(x => x.ProjectFilePathID).IsUnique();

            modelBuilder.Entity<ProjectFilePath>().HasAlternateKey(x => x.Value);
        }
    }
}
