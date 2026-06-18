using System;

namespace InkDialogueGraphTool
{

    [Serializable]
    public class DivertNode : InkNode
    {
        const string doneDivertName = "DONE";
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort(PortID.In).Build();
            context.AddInputPort<string>(PortID.DivertName).Build();
        }

        public override void ProcessNode(DialogueWriter writer)
        {
            var value = GetPortValue<string>(GetInputPortByName(PortID.DivertName));

            string divertText = string.IsNullOrEmpty(value) || value.ToUpper() == doneDivertName ? $"-> {doneDivertName}" : $"-> {value}";
            writer.ImportDialogueNodeToInkFile(divertText);
        }
    }
}