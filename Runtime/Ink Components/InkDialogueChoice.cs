using System;

[Serializable]
public struct InkDialogueChoice : IDialogueComponent
{
    private string choiceText;
    private bool isSticky;
    private string knotName;
    public InkDialogueChoice(string choiceText, bool isSticky, string knotName)
    {
        this.choiceText = choiceText;
        this.isSticky = isSticky;
        this.knotName = knotName;
    }
    public override readonly string ToString()
    {
        string output = isSticky ? $"*{choiceText}" : $"*[{choiceText}]";
        return output;
    }
}
