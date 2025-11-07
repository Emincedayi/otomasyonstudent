using otomasyonstudent.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace otomasyonstudent.Permissions;

public class otomasyonstudentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(otomasyonstudentPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(otomasyonstudentPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<otomasyonstudentResource>(name);
    }
}
