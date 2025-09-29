using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    public abstract class DatabaseItem
    {
        public abstract string Name { get; set; }
    }
    public class DatabaseNode : DatabaseItem
    {
        public override string Name { get; set; }
        public List<DatabaseItem> Items { get; set; }
        public DatabaseNode(string name) { Name = name; Items = new List<DatabaseItem>(); }
    }

    public class Navigator
    {
        public DatabaseNode Root { get; private set; }

        public List<DatabaseNode> Path { get; private set; } = new List<DatabaseNode>();

        public DatabaseNode CurrentLocation => Path.LastOrDefault();

        public Navigator(DatabaseNode root) { Root = root; Path.Add(Root); }

        public void NavigateInChild(DatabaseNode child)
        {
            Path.Add(child);
        }

        public void NavigateUp()
        {
            if (Path.Count > 1)
                Path.RemoveAt(Path.Count - 1);
        }

        public string GetCurrentPathString()
        {
            return string.Join("/", Path.Select(n => n.Name));
        }

        public Product GetObjectFromCode(string code, DatabaseNode startingNode = null)
        {
            if(startingNode == null)
            {
                startingNode = Root;
            }
            foreach(DatabaseItem item in startingNode.Items)
            {
                if(item.GetType() == typeof(DatabaseNode))
                {
                    Product thing = GetObjectFromCode(code, (DatabaseNode)item);
                    if (thing.Code == code)
                    {
                        return thing;
                    }
                }
                else if(item.GetType() == typeof(Product))
                {
                    if(((Product)item).Code == code)
                    {
                        return (Product)item;
                    }
                }
            }
            return null;
        }
    }
}
