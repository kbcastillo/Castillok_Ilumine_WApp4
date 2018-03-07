using MobileSalesTool.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;

namespace MobileSalesTool.DAL
{
    public class MobileSalesToolConfiguration : DbConfiguration
    {
        public MobileSalesToolConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new MobileSalesToolInterceptorTransientErrors());
            DbInterception.Add(new MobileSalesToolInterceptorLogging());
        }
    }
}