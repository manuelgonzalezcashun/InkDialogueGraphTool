using System;

[Serializable]
public struct InkDialogueVariable : IDialogueComponent
{
    private string variableKey;
    private object variableValue;

    public InkDialogueVariable(string variableKey, object variableValue)
    {
        this.variableKey = variableKey;
        this.variableValue = variableValue;
    }
    public override readonly string ToString()
    {
        return $"VAR {variableKey} = {variableValue}";
    }
}
