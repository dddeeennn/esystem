namespace ESystem.Infrastructure
{
    public static class NodeStore
    {
        public static readonly NodeHanderService Ctx;
        public static LevelTreeNode TmpNode;
        public static int UnknowAnswer = 0;

        static NodeStore()
        {
            Ctx = new NodeHanderService();
        }

    }
}