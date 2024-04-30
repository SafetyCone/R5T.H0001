using System;

using Microsoft.EntityFrameworkCore;


namespace R5T.H0001
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder For_ProjectsDbContext(this ModelBuilder modelBuilder)
        {
            Instances.ModelBuilderOperator.Configure_ForProjectsDbContext(modelBuilder);

            return modelBuilder;
        }
    }
}
