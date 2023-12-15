using Volo.Abp.Reflection;

namespace AnhLH.ConGaTrong.Permissions;

public class ConGaTrongPermissions
{
    public const string GroupName = "ConGaTrong";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(ConGaTrongPermissions));
    }
}
