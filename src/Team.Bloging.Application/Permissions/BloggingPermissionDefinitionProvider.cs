using Team.Blogging.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Team.Blogging.Permissions
{
    public class BloggingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            if (context.GetGroupOrNull(BloggingPermissions.GroupName)==null)
            {
                var myGroup = context.AddGroup(BloggingPermissions.GroupName);
            }
            

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BlogingPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BloggingResource>(name);
        }
    }
}
