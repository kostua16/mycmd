using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Raven;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace mycmd
{
    public class DbSetting
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }
    }
    public class DbScript
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    class ScriptHelper
    {
        public EmbeddableDocumentStore SystemStore;
        public IDocumentSession System;
        public ScriptHelper()
        {
            var p1 = Path.Combine("Data", "System.db");
            SystemStore = new EmbeddableDocumentStore { DataDirectory = p1 };
            SystemStore.Initialize();
            System = SystemStore.OpenSession();
            SystemStore.Conventions.RegisterIdConvention<DbSetting>((db, cmds, setting) => "Settings/" + setting.Name);
            SystemStore.Conventions.RegisterIdConvention<DbScript>((db, cmds, script) => "Scripts/" + script.Name);
            try
            {
                SystemStore.DatabaseCommands.PutIndex("Settings/ByName", new IndexDefinitionBuilder<DbSetting>
                {
                    Map = settings =>
                          from setting
                              in settings
                          select new { setting.Name }
                });
                SystemStore.DatabaseCommands.PutIndex("Scripts/ByName", new IndexDefinitionBuilder<DbScript>
                {
                    Map = scripts =>
                          from script
                              in scripts
                          select new { script.Name }
                });
            }
            catch (Exception)
            {
                
            }
            
            IndexCreation.CreateIndexes(typeof(DbScript).Assembly,SystemStore);
            IndexCreation.CreateIndexes(typeof(DbSetting).Assembly, SystemStore);
        }
        ~ScriptHelper()
        {
            System.SaveChanges();
        }
    }
}
