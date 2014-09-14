namespace ESystem.Infrastructure
{
    public class Question : INode
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public INode Parent { get; set; }
        public int ParentId { get; set; }
        public bool IsLeaf { get; set; }

        public Question(int id, string data, int parentId):this()
        {
            Id = id;
            Data = data;
            ParentId = parentId;
        }

        public Question(esNode question):this()
        {
            Id = question.idNode;
            Data = question.data;
            ParentId = question.idParentNode;
        }

        public Question()
        {
            IsLeaf = false;
        }
    }
}