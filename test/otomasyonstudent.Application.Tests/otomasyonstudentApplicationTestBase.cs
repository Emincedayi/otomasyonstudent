using Volo.Abp.Modularity;

namespace otomasyonstudent;

public abstract class otomasyonstudentApplicationTestBase<TStartupModule> : otomasyonstudentTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
