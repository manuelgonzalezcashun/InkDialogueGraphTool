using System;
using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;
[Serializable]
public class KnotNode : InkRootNode
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort<string>(PortID.KnotName).Build();
        context.AddOutputPort(PortID.Out).Build();
    }
    public override void ProcessNode(DialogueWriter writer)
    {
        string knotName = GetPortValue<string>(GetInputPortByName(PortID.KnotName));
        writer.ImportKnotNodeToInkFile(knotName);

        TraverseThroughNodeTree(this);
        foreach (var node in connectedNodes)
        {
            node.ProcessNode(writer);
        }
    }
}
