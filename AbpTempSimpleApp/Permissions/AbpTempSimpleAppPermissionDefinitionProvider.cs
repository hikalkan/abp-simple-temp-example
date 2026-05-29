using AbpTempSimpleApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace AbpTempSimpleApp.Permissions;

public class AbpTempSimpleAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpTempSimpleAppPermissions.GroupName);


        var booksPermission = myGroup.AddPermission(AbpTempSimpleAppPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(AbpTempSimpleAppPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(AbpTempSimpleAppPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(AbpTempSimpleAppPermissions.Books.Delete, L("Permission:Books.Delete"));
        
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpTempSimpleAppPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpTempSimpleAppResource>(name);
    }
}
