using System;

using Microsoft.EntityFrameworkCore;

using R5T.H0001.Entities;
using R5T.T0250;


namespace R5T.H0001
{
    /// <summary>
    /// 
    /// </summary>
    [DbContextDefinitionMarker]
    public interface IProjectsDbContext : IDbContextDefinitionMarker
    {
        DbSet<Project> Projects { get; }
        DbSet<ProjectFilePath> ProjectFilePaths { get; }
        DbSet<ProjectFilePathList> ProjectFilePathLists { get; }
        DbSet<ProjectFilePathListMapping> ProjectFilePathListMappings { get; }
    }
}
