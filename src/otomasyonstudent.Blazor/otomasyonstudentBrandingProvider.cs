using Microsoft.Extensions.Localization;
using otomasyonstudent.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace otomasyonstudent.Blazor;

[Dependency(ReplaceServices = true)]
public class otomasyonstudentBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<otomasyonstudentResource> _localizer;

    public otomasyonstudentBrandingProvider(IStringLocalizer<otomasyonstudentResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
