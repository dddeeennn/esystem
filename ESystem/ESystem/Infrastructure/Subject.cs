namespace ESystem.Infrastructure
{
    public class Subject : INode
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public INode Parent { get; set; }
        public int ParentId { get; set; }
        public bool IsLeaf { get; set; }

        public Subject(int id, string data, int parentId)
            : this()
        {
            Id = id;
            Data = data;
            ParentId = parentId;
        }

        public Subject()
        {
            IsLeaf = true;
        }
    }
}