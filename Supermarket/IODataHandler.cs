using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Supermarket
{
    public static class IODataHandler
    {
        private static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
        public static bool Initialized = false;
        public static DatabaseNode Database { get; private set; }
        private static string Filepath = @"SupermarketDatabaseData.json";

        public static void Initialize()
        {
            Database = new DatabaseNode("Catalog");
            LoadData();
            Initialized = true;
        }

        public static void UpdateDatabase(DatabaseNode newDatabase)
        {
            Database = newDatabase;
            WriteData();
        }

        public static Product GetProductByCode(string code)
        {
            if(code.Length == 12)
            {
                DatabaseItem result = RecursiveAiderFunction(Database, code);
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return (Product)result;
                }
            }
            else
            {
                return null;
            }
        }

        private static DatabaseItem RecursiveAiderFunction(DatabaseNode node, string code)
        {
            foreach(var item in node.Items)
            {
                if (item.GetType() == typeof(DatabaseNode))
                {
                    DatabaseItem result = RecursiveAiderFunction((DatabaseNode)item, code);
                    if(result != null)
                    {
                        return result;
                    }
                }
                else if (item.GetType() == typeof(Product))
                {
                    if(((Product)item).Code == code)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private static void LoadData()
        {
            if (!File.Exists(Filepath))
            {
                File.WriteAllText(Filepath, "{\r\n  \"Name\": \"Catalog\",\r\n  \"Items\": []\r\n}");
            }
            string rawData = File.ReadAllText(Filepath);
            Database = JsonConvert.DeserializeObject<DatabaseNode>(rawData, SerializerSettings);
        }

        private static void WriteData()
        {
            string serializedData = JsonConvert.SerializeObject(Database,Formatting.Indented, SerializerSettings);
            File.WriteAllText(Filepath,serializedData);
        }
    }
}
