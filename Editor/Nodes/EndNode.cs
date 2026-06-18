using System;

namespace InkDialogueGraphTool
{
    [Serializable]
    public class EndNode : InkNode
    {
        public override void ProcessNode(DialogueWriter writer) { }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort(PortID.In).Build();
        }
    }
}



