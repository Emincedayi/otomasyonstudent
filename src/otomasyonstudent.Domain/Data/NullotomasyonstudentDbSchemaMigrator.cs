using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace otomasyonstudent.Data;

/* This is used if database provider does't define
 * IotomasyonstudentDbSchemaMigrator implementation.
 */
public class NullotomasyonstudentDbSchemaMigrator : IotomasyonstudentDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
