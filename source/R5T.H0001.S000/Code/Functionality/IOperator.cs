using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

using R5T.T0132;


namespace R5T.H0001.S000
{
    [FunctionalityMarker]
    public partial interface IOperator : IFunctionalityMarker
    {
        public ServiceProvider Get_ProjectsDbContext(
            out ProjectsDbContext projectsDbContext)
        {
            var services = new ServiceCollection();

            services.AddDbContext<ProjectsDbContext>(options =>
            {
                options.UseSqlServer(Instances.ConnectionStrings.Local_Development);
            });

            var serviceProvider = services.BuildServiceProvider();

            projectsDbContext = serviceProvider.GetRequiredService<ProjectsDbContext>();

            return serviceProvider;
        }
    }
}
