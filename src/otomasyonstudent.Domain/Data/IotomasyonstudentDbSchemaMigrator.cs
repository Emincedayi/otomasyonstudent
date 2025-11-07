using System.Threading.Tasks;

namespace otomasyonstudent.Data;

public interface IotomasyonstudentDbSchemaMigrator
{
    Task MigrateAsync();
}
