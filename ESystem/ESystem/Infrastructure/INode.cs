namespace ESystem.Infrastructure
{
    public interface INode
    {
        int Id { get; set; }
        string Data { get; set; }
        int ParentId { get; set; }
        bool IsLeaf { get; set; }
    }
}
