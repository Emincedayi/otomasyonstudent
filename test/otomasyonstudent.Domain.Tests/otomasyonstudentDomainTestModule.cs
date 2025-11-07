using Volo.Abp.Modularity;

namespace otomasyonstudent;

[DependsOn(
    typeof(otomasyonstudentDomainModule),
    typeof(otomasyonstudentTestBaseModule)
)]
public class otomasyonstudentDomainTestModule : AbpModule
{

}
