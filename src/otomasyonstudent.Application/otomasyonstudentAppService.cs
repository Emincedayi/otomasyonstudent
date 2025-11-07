using otomasyonstudent.Localization;
using Volo.Abp.Application.Services;

namespace otomasyonstudent;

/* Inherit your application services from this class.
 */
public abstract class otomasyonstudentAppService : ApplicationService
{
    protected otomasyonstudentAppService()
    {
        LocalizationResource = typeof(otomasyonstudentResource);
    }
}
