using Unity.GraphToolkit.Editor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace InkDialogueGraphTool
{
    [Serializable]
    public abstract class InkRootNode : InkNode
    {
        protected List<InkNode> connectedNodes = new List<InkNode>();
        protected void TraverseThroughNodeTree(INode rootNode)
        {
            if (rootNode == null || rootNode.OutputPortCount == 0) return;

            var outputPorts = rootNode.GetOutputPorts() ?? Enumerable.Empty<IPort>();
            var nodes = outputPorts
            .Where(port => port != null && port.IsConnected)
            .Select(port => port.FirstConnectedPort?.GetNode() as InkNode)
            .Where(node => node != null)
            .ToList();

            foreach (var node in nodes)
            {
                if (node is DivertNode && !(rootNode is StartNode)) return;

                connectedNodes.Add(node);
                TraverseThroughNodeTree(node);
            }
        }
    }
}