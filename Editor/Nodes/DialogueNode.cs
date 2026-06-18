using UnityEngine;
using System;
using Unity.GraphToolkit.Editor;

namespace InkDialogueGraphTool
{
    [Serializable]
    public class DialogueNode : InkNode
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddOutputPort(PortID.Out).Build();
            context.AddInputPort(PortID.In).Build();

            context.AddInputPort<string>(PortID.Speaker).Build();
            context.AddInputPort<string>(PortID.Dialogue).Build();
        }
        public override void ProcessNode(DialogueWriter writer)
        {
            string dialogueLine = GetPortValue<string>(GetInputPortByName(PortID.Dialogue));

            string speakerID = GetInputPortByName(PortID.Speaker).Name;
            string speakerName = GetPortValue<string>(GetInputPortByName(PortID.Speaker));
            var speakerTag = new InkDialogueTag(speakerID, speakerName);


            writer.ImportDialogueNodeToInkFile(dialogueLine + speakerTag.ToString());

            var outputNode = GetOutputPortByName(PortID.Out).FirstConnectedPort.GetNode();
            if (outputNode is DivertNode divertNode)
                divertNode.ProcessNode(writer);
        }
    }
}