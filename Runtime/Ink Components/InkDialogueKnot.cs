using System;

[Serializable]
public struct InkDialogueKnot : IDialogueComponent
{
    private string knotName;

    public InkDialogueKnot(string knotName)
    {
        this.knotName = knotName;
    }
    public override readonly string ToString()
    {
        string output = $"\n==={knotName}===";
        return output;
    }
}
