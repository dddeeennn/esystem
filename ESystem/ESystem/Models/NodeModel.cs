using System.Collections.Generic;

namespace ESystem.Models
{
    public class NodeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Data { get; set; }
        public List<NodeModel> Children { get; set; }

        public NodeModel()
        {
            Children = new List<NodeModel>();
            Data = new object();
        }

        public NodeModel(int id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }

        public NodeModel(int id, string name, object data)
            : this(id, name)
        {
            Data = data;
        }
    }
}