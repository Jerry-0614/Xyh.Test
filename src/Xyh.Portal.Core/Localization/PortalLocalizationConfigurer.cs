using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Json;
using Abp.Reflection.Extensions;

namespace Xyh.Portal.Localization
{
    public static class PortalLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flags england", isDefault: true));
            //localizationConfiguration.Languages.Add(new LanguageInfo("cn", "中文", "famfamfam-flags cn"));

            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(PortalConsts.LocalizationSourceName,
                    new JsonEmbeddedFileLocalizationDictionaryProvider(
                        typeof(PortalLocalizationConfigurer).GetAssembly(),
                        "Xyh.Portal.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}