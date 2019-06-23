using Team.Bloging.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Team.Bloging.Permissions
{
    public class BlogingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BlogingPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BlogingPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BlogingResource>(name);
        }
    }
}
