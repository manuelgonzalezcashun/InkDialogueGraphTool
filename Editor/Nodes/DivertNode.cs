using System;

namespace InkDialogueGraphTool
{

    [Serializable]
    public class DivertNode : InkNode
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort(PortID.In).Build();
            context.AddInputPort<string>(PortID.DivertName).Build();
        }

        public override void ProcessNode(DialogueWriter writer)
        {
            string value = GetPortValue<string>(GetInputPortByName(PortID.DivertName)).Trim().Replace(" ", "");

            if (string.IsNullOrEmpty(value)) return;
            string divertText = $"-> {value}";

            writer.ImportDialogueNodeToInkFile(divertText);
        }
    }
}