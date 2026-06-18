using UnityEngine;
using Unity.GraphToolkit.Editor;
using System;
namespace InkDialogueGraphTool
{
    [Serializable]
    public abstract class InkNode : Node
    {
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

    }
}

