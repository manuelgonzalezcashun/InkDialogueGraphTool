using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;

[Serializable]
public class DialogueWriter
{
    readonly string END_DIVERT = "\n-> END";
    readonly string INK_EXTENSION = ".ink";
    readonly string inkStoriesPath = Application.dataPath + "/InkDialogueGraphTool/Ink Stories";

    public List<IDialogueComponent> dialogueLines = new List<IDialogueComponent>();

    string file;
    string inkFile;

    public DialogueWriter(string inkFileName)
    {
        inkFile = inkFileName + INK_EXTENSION;

        if (!Directory.Exists(inkStoriesPath))
            Directory.CreateDirectory(inkStoriesPath);
    }
    public void ImportDialogueNodeToInkFile(string line)
    {
        dialogueLines.Add(new InkDialogueLine(line));
    }
    public void ImportChoiceNodeToInkFile(string line, bool isSticky, string knotName = "")
    {
        dialogueLines.Add(new InkDialogueChoice(line, isSticky, knotName));
    }
    public void ImportKnotNodeToInkFile(string knotName)
    {
        dialogueLines.Add(new InkDialogueKnot(knotName));
    }
    public void WriteStory()
    {
        file = Path.Combine(inkStoriesPath, inkFile);

        string tempFile = file + ".tmp";
        var lines = dialogueLines.Select(line => line.ToString());
        File.WriteAllLines(tempFile, lines);
        File.AppendAllText(tempFile, END_DIVERT);

        if (File.Exists(file))
            File.Replace(tempFile, file, null);
        else
            File.Move(tempFile, file);
    }
}
