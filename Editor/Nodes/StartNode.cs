using System;
using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;
using UnityEngine;
[Serializable]
public class StartNode : InkRootNode
{
    public override void ProcessNode(DialogueWriter writer)
    {
        TraverseThroughNodeTree(this);

        foreach (InkNode inkNode in connectedNodes)
        {
            inkNode.ProcessNode(writer);
        }
    }
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddOutputPort(PortID.Out).Build();
    }
}


