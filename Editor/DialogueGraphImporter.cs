using UnityEngine;
using UnityEditor.AssetImporters;
using Unity.GraphToolkit.Editor;
[ScriptedImporter(1, DialogueGraph.AssetExtension)]
public class DialogueGraphImporter : ScriptedImporter
{
    public override void OnImportAsset(AssetImportContext ctx)
    {
        DialogueGraph editorGraph = GraphDatabase.LoadGraphForImporter<DialogueGraph>(ctx.assetPath);
        DialogueWriter writer = new DialogueWriter(editorGraph.Name);

        foreach (var iNode in editorGraph.GetNodes())
        {
            if (iNode is InkRootNode rootNode) rootNode.ProcessNode(writer);
        }
        writer.WriteStory();
    }
}
