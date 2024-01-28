using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.DeliveryService.Infrastructure.Common.Data
{
    public  class ContextFactory : IDesignTimeDbContextFactory<DeliveryServiceContext>
    {
        // TODO: bad, refactor!
        string connection_string = "Server=(localdb)\\mssqllocaldb;Database=HangryHub.DeliveryService;Trusted_Connection=True;";
        public  DeliveryServiceContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DeliveryServiceContext> builder = new DbContextOptionsBuilder<DeliveryServiceContext>();
   
            builder.UseSqlServer(connection_string);


            return new DeliveryServiceContext(builder.Options);
        }
    }
}
