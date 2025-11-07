using Volo.Abp.Modularity;

namespace otomasyonstudent;

/* Inherit from this class for your domain layer tests. */
public abstract class otomasyonstudentDomainTestBase<TStartupModule> : otomasyonstudentTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
