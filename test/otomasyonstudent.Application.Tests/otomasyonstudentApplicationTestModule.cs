using Volo.Abp.Modularity;

namespace otomasyonstudent;

[DependsOn(
    typeof(otomasyonstudentApplicationModule),
    typeof(otomasyonstudentDomainTestModule)
)]
public class otomasyonstudentApplicationTestModule : AbpModule
{

}
