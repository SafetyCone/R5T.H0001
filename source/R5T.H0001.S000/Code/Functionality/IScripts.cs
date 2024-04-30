using System;
using System.Threading.Tasks;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using R5T.T0132;
using R5T.T0238.Serialization;

using R5T.H0001.Entities;


namespace R5T.H0001.S000
{
    [FunctionalityMarker]
    public partial interface IScripts : IFunctionalityMarker
    {
        public async Task Remove_ExampleProject()
        {
            await using var serviceProvider = Instances.Operator.Get_ProjectsDbContext(
                out var projectsDbContext);

            var projectFilePath = Instances.ProjectFilePaths.N_001;

            // Do not delete the project file paths (since they might be in use by other projects), so no need to include them.
            var projectEntity = await projectsDbContext.Projects
                .Where(x => x.ProjectFilePath.Value == projectFilePath)
                .Include(x => x.ProjectReferencesList).ThenInclude(x => x.Mappings)
                .FirstAsync();

            projectsDbContext.ProjectFilePathListMappings.RemoveRange(projectEntity.ProjectReferencesList.Mappings);
            projectsDbContext.ProjectFilePathLists.Remove(projectEntity.ProjectReferencesList);
            projectsDbContext.Remove(projectEntity);

            await projectsDbContext.SaveChangesAsync();
        }

        public async Task Remove_ExampleProject_OLD()
        {
            await using var serviceProvider = Instances.Operator.Get_ProjectsDbContext(
                out var projectsDbContext);

            var exampleProject = await projectsDbContext.Projects
                .Where(x => x.ProjectFilePath.Value == Instances.FilePaths.Example_ProjectFilePath)
                .FirstAsync();

            projectsDbContext.Projects.Remove(exampleProject);

            await projectsDbContext.SaveChangesAsync();
        }

        public async Task Get_ExampleProject()
        {
            await using var serviceProvider = Instances.Operator.Get_ProjectsDbContext(
                out var projectsDbContext);

            var projectFilePath = Instances.ProjectFilePaths.N_001;

            var projectEntity = await projectsDbContext.Projects
                .Where(x => x.ProjectFilePath.Value == projectFilePath)
                .Include(x => x.ProjectFilePath)
                .Include(x => x.ProjectReferencesList).ThenInclude(x => x.Mappings).ThenInclude(x => x.ProjectFilePath)
                .FirstAsync();

            var projectDesriptor = new ProjectDescriptor
            {
                Identity = projectEntity.Identity,
                FilePath = projectEntity.ProjectFilePath.Value,
                Name = projectEntity.Name,
                Description = projectEntity.Description,
                Type = projectEntity.Type,
                GitHubRepositoryUrl = projectEntity.GitHubRepositoryUrl,
                IsPrivate = projectEntity.IsPrivate,
                ProjectReferences = projectEntity.ProjectReferencesList.Mappings
                    .Select(x => x.ProjectFilePath.Value)
                    .ToArray()
            };

            Console.WriteLine(projectDesriptor);
        }

        public async Task Add_ExampleProject()
        {
            await using var serviceProvider = Instances.Operator.Get_ProjectsDbContext(
                out var projectsDbContext);

            var projectDescriptor = Instances.ProjectDescriptors.N_001;

            var projectFilePathsRequired = projectDescriptor.ProjectReferences
                .Append(projectDescriptor.FilePath)
                .Now();

            var projectFilePathEntities = await projectsDbContext.ProjectFilePaths
                .Where(x => projectFilePathsRequired.Contains(x.Value))
                .ToDictionaryAsync(
                    x => x.Value);

            var projectFilePathsToAdd = projectFilePathsRequired
                .Except(projectFilePathEntities.Keys)
                .Now();

            var projectFilePathEntitiesByProjectFilePath = projectFilePathsRequired
                .Select(projectFilePath =>
                {
                    if (!projectFilePathEntities.TryGetValue(projectFilePath, out var projectFilePathEntity))
                    {
                        projectFilePathEntity = new ProjectFilePath
                        {
                            Value = projectFilePath
                        };

                        projectsDbContext.ProjectFilePaths.Add(projectFilePathEntity);
                    }

                    return projectFilePathEntity;
                })
                .ToDictionary(
                    x => x.Value);

            var projectReferencesListEntity = new ProjectFilePathList();

            projectsDbContext.ProjectFilePathLists.Add(projectReferencesListEntity);

            foreach (var projectReferenceProjectFilePath in projectDescriptor.ProjectReferences)
            {
                var projectFilePathEntity = projectFilePathEntitiesByProjectFilePath[projectReferenceProjectFilePath];

                var mappingEntity = new ProjectFilePathListMapping
                {
                    ProjectFilePath = projectFilePathEntity,
                    ProjectFilePathList = projectReferencesListEntity
                };

                projectsDbContext.ProjectFilePathListMappings.Add(
                    mappingEntity);
            }

            var projectEntity = new Project
            {
                Identity = projectDescriptor.Identity,

                Name = projectDescriptor.Name,
                Description = projectDescriptor.Description,
                Type = projectDescriptor.Type,

                GitHubRepositoryUrl = projectDescriptor.GitHubRepositoryUrl,
                IsPrivate = projectDescriptor.IsPrivate,

                ProjectFilePath = projectFilePathEntitiesByProjectFilePath[projectDescriptor.FilePath],
                ProjectReferencesList = projectReferencesListEntity,
            };

            projectsDbContext.Projects.Add(projectEntity);

            await projectsDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Note: no longer works after DB schema change.
        /// </summary>
        /// <returns></returns>
        public async Task Add_ExampleProject_OLD()
        {
            await using var serviceProvider = Instances.Operator.Get_ProjectsDbContext(
                out var projectsDbContext);

            var exmapleProject = new Project
            {
                Name = "R5T.H0001.S000",
                Description = "Scripts for the projects repository database project.",
                //ProjectFilePath = Instances.FilePaths.Example_ProjectFilePath,
            };

            // Output: 00000000-0000-0000-0000-000000000000.
            Console.WriteLine($"{exmapleProject.Identity}: identity-after construction");

            projectsDbContext.Projects.Add(exmapleProject);

            // Output: eb1f55b4-e4ec-433b-52ad-08dc658723a9
            Console.WriteLine($"{exmapleProject.Identity}: identity-after add");

            await projectsDbContext.SaveChangesAsync();

            // Output: eb1f55b4-e4ec-433b-52ad-08dc658723a9
            Console.WriteLine($"{exmapleProject.Identity}: identity-after save changes");
        }

        public void Deserialize_ProjectDescriptor_FromJsonString()
        {
            var jsonString = Instances.ProjectDescriptorJsonStrings.N_001;
            
            var projectDescriptor = Instances.JsonOperator.Load_FromString<ProjectDescriptor>(
                jsonString);

            Console.WriteLine(projectDescriptor.Identity);
        }

        public void Deserialize_Guid()
        {
            var identified = new Identified
            {
                Identity = Instances.GuidOperator.New()
            };

            var jsonString = Instances.JsonOperator.Save_ToString(identified);

            Console.WriteLine(jsonString);

            var identified2 = Instances.JsonOperator.Load_FromString<Identified>(jsonString);

            Console.WriteLine(identified2);

            var jsonString2 = @"
{
    ""Identity"": ""039f60c1-b839-4720-87d8-8ddccae14ed0""
}";

            var identified3 = Instances.JsonOperator.Load_FromString<Identified>(jsonString2);

            Console.WriteLine(identified3);
        }
    }
}
