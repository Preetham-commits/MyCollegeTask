﻿using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyCollegeTask.Localization
{
    public static class MyCollegeTaskLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(MyCollegeTaskConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(MyCollegeTaskLocalizationConfigurer).GetAssembly(),
                        "MyCollegeTask.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
