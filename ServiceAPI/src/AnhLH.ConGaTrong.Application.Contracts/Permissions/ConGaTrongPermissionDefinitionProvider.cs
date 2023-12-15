using AnhLH.ConGaTrong.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AnhLH.ConGaTrong.Permissions;

public class ConGaTrongPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ConGaTrongPermissions.GroupName, L("Permission:ConGaTrong"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ConGaTrongResource>(name);
    }
}
