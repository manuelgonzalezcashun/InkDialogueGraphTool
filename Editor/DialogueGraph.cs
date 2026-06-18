using UnityEngine;
using Unity.GraphToolkit.Editor;
using UnityEditor;
using System;
namespace InkDialogueGraphTool
{
    [Serializable]
    [Graph(AssetExtension)]
    public class DialogueGraph : Graph
    {
        public const string AssetExtension = "inkdg";

        [MenuItem("Assets/Create/Dialogue Graph", false)]
        private static void CreateAssetFile()
        {
            GraphDatabase.PromptInProjectBrowserToCreateNewAsset<DialogueGraph>();
        }
    }
}

