using System;

[Serializable]
public struct InkDialogueLine : IDialogueComponent
{
    private string dialogueLine;
    public InkDialogueLine(string dialogueLine)
    {
        this.dialogueLine = dialogueLine;
    }
    public override readonly string ToString()
    {
        return dialogueLine;
    }
}
