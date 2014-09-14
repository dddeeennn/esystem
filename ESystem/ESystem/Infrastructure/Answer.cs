namespace ESystem.Infrastructure
{
    public class Answer
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public bool IsLeaf { get; set; }
        public int NextNodeId { get; set; }

        public Answer()
        { }

        public Answer(string data, bool isLeaf)
        {
            Data = data;
            IsLeaf = isLeaf;
        }

        public Answer(int id, string data, bool isLeaf, int nextNodeId)
            : this(id, data, isLeaf)
        {
            NextNodeId = nextNodeId;
        }

        public Answer(int id, string data, bool isLeaf)
        {
            Id = id;
            Data = data;
            IsLeaf = isLeaf;
        }
    }
}