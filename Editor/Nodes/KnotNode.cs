using System;
using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;

namespace InkDialogueGraphTool
{
    [Serializable]
    public class KnotNode : InkNode
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<string>(PortID.KnotName).Build();
            context.AddOutputPort(PortID.Out).Build();
        }
        public override void ProcessNode(DialogueWriter writer)
        {
            string portValue = GetPortValue<string>(GetInputPortByName(PortID.KnotName));
            string knotName = portValue.Trim().Replace(" ", "");

            writer.ImportKnotNodeToInkFile(knotName);

            TraverseThroughNodeTree(this);
            foreach (var node in connectedNodes)
            {
                node.ProcessNode(writer);
            }
        }
    }
}
