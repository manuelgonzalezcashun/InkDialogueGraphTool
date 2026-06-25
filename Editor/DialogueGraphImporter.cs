using UnityEngine;
using UnityEditor.AssetImporters;
using Unity.GraphToolkit.Editor;
using System.Linq;
namespace InkDialogueGraphTool
{
    [ScriptedImporter(1, DialogueGraph.AssetExtension)]
    public class DialogueGraphImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            DialogueGraph editorGraph = GraphDatabase.LoadGraphForImporter<DialogueGraph>(ctx.assetPath);
            DialogueWriter writer = new DialogueWriter(editorGraph.Name);

            var startNode = editorGraph.GetNodes().OfType<StartNode>().FirstOrDefault();
            if (startNode != null) startNode.ProcessNode(writer);

            foreach (var iNode in editorGraph.GetNodes())
            {
                if (iNode is StartNode) continue;

                if (iNode is InkRootNode rootNode) rootNode.ProcessNode(writer);
            }
            writer.WriteStory();
        }
    }
}

