using UnityEngine;
using System;
using System.Linq;
using Unity.GraphToolkit.Editor;
using System.Collections.Generic;
[Serializable]
public class ChoiceNode : InkNode
{
    const string optionID = "portCount";
    protected int portCount;
    private List<IPort> choiceOutputPorts => GetOutputPorts().Where(port => port.Name.StartsWith("Choice ")).ToList();
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort(PortID.In).Build();

        context.AddInputPort<bool>(PortID.StickyChoice).Build();
        context.AddInputPort<string>(PortID.Speaker).Build();
        context.AddInputPort<string>(PortID.Dialogue).Build();

        var option = GetNodeOptionByName(optionID);
        option.TryGetValue(out portCount);
        for (int i = 0; i < portCount; i++)
        {
            context.AddInputPort<string>($"Choice Text {i}").Build();
            context.AddOutputPort($"Choice {i}").Build();
        }
    }
    protected override void OnDefineOptions(IOptionDefinitionContext context)
    {
        context.AddOption<int>(optionID).WithDefaultValue(2).Delayed();
    }

    public override void ProcessNode(DialogueWriter writer)
    {
        string dialogueLine = GetPortValue<string>(GetInputPortByName(PortID.Dialogue));
        bool isSticky = GetPortValue<bool>(GetInputPortByName(PortID.StickyChoice));

        writer.ImportDialogueNodeToInkFile(dialogueLine);

        foreach (var outputPort in choiceOutputPorts)
        {
            string index = outputPort.Name.Substring("Choice ".Length);
            var textPort = GetInputPortByName($"Choice Text {index}");

            var choiceText = GetPortValue<string>(textPort);

            writer.ImportChoiceNodeToInkFile(choiceText, isSticky);

            var outputNode = outputPort.FirstConnectedPort.GetNode();
            if (outputNode is DivertNode divertNode)
                divertNode.ProcessNode(writer);
        }
    }
}


