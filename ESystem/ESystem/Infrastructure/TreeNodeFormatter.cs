using System.Collections.Generic;
using System.Linq;
using ESystem.Models;

namespace ESystem.Infrastructure
{
    public class TreeNodeFormatter
    {
        public TreeNode Get()
        {
            var elems = NodeStore.Ctx.GetAllNodes();

            var tree = PerformTree(elems);

            return tree;
        }

        private TreeNode PerformTree(IEnumerable<INode> nodes)
        {
            var tree = new TreeNode();
            tree.Root = new NodeModel(1, "root");

            LoadTree(nodes.ToArray(), tree.Root);

            return tree;
        }

        private static void LoadTree(INode[] nodes, NodeModel parentNodeModel)
        {
            var parent = parentNodeModel;

            foreach (var node in nodes)
            {
                if (node.ParentId == parent.Id)
                {
                    var newParent = new NodeModel(node.Id, node.Data);
                   
                    parent.Children.Add(newParent);

                    LoadTree(nodes, newParent);
                }
            }
        }
    }
}