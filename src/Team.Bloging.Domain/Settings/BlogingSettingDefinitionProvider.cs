using Volo.Abp.Settings;

namespace Team.Blogging.Settings
{
    public class BlogingSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BlogingSettings.MySetting1));
        }
    }
}
