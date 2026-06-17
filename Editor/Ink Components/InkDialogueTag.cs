using System;

[Serializable]
public struct InkDialogueTag : IDialogueComponent
{
    private string tagKey;
    private string tagValue;
    public InkDialogueTag(string tagKey, string tagValue)
    {
        this.tagKey = tagKey;
        this.tagValue = tagValue;
    }
    public override readonly string ToString()
    {
        return $" #{tagKey}:{tagValue}";
    }
}