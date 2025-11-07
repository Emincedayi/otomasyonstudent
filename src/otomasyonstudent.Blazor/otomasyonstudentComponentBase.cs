using otomasyonstudent.Localization;
using Volo.Abp.AspNetCore.Components;

namespace otomasyonstudent.Blazor;

public abstract class otomasyonstudentComponentBase : AbpComponentBase
{
    protected otomasyonstudentComponentBase()
    {
        LocalizationResource = typeof(otomasyonstudentResource);
    }
}
