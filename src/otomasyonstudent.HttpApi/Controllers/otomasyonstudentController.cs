using otomasyonstudent.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace otomasyonstudent.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class otomasyonstudentController : AbpControllerBase
{
    protected otomasyonstudentController()
    {
        LocalizationResource = typeof(otomasyonstudentResource);
    }
}
