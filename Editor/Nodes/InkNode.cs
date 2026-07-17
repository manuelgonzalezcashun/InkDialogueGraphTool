using UnityEngine;
using Unity.GraphToolkit.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
namespace InkDialogueGraphTool
{
    [Serializable]
    public abstract class InkNode : Node
    {
        public List<InkNode> connectedNodes { get; private set; } = new List<InkNode>();
        public abstract void ProcessNode(DialogueWriter writer);
        public T GetPortValue<T>(IPort port)
        {
            if (port == null) return default;

            if (port.IsConnected)
            {
                if (port.FirstConnectedPort.GetNode() is IVariableNode variableNode)
                {
                    variableNode.Variable.TryGetDefaultValue(out T value);
                    return value;
                }
            }

            port.TryGetValue(out T fallbackValue);
            return fallbackValue;
        }
        protected void TraverseThroughNodeTree(INode rootNode)
        {
            if (rootNode == null || rootNode.OutputPortCount == 0) return;

            if (rootNode == this) connectedNodes.Clear();

            bool isStartOrKnotNode = (rootNode is KnotNode) || (rootNode is StartNode);

            var outputPorts = rootNode.GetOutputPorts() ?? Enumerable.Empty<IPort>();
            var nodes = outputPorts
            .Where(port => port != null && port.IsConnected)
            .Select(port => port.FirstConnectedPort?.GetNode() as InkNode)
            .Where(node => node != null)
            .ToList();

            foreach (var node in nodes)
            {
                if (connectedNodes.Contains(node)) continue;

                if (node is DivertNode && !isStartOrKnotNode) continue;
                if (node is DialogueNode && rootNode is ChoiceNode) continue;

                connectedNodes.Add(node);
                TraverseThroughNodeTree(node);
            }
        }
    }
}

