using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace R5T.H0001.DB01
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DB01Context>
    {
        public DB01Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DB01Context>()
                .UseSqlServer(Instances.ConnectionStrings.DB01)
                ;

            var options = optionsBuilder.Options;

            var output = new DB01Context(options);
            return output;
        }
    }
}
