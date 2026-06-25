using System;
namespace InkDialogueGraphTool
{
    [Serializable]
    public class DoneDivertNode : DivertNode
    {
        const string doneDivertName = "-> DONE";
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort(PortID.In).Build();
        }
        public override void ProcessNode(DialogueWriter writer)
        {
            writer.ImportDialogueNodeToInkFile(doneDivertName);
        }
    }
}