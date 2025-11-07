using otomasyonstudent.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace otomasyonstudent.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(otomasyonstudentEntityFrameworkCoreModule),
    typeof(otomasyonstudentApplicationContractsModule)
)]
public class otomasyonstudentDbMigratorModule : AbpModule
{
}
