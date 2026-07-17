namespace InkDialogueGraphTool
{
    public struct PortID
    {
        public const string In = "In";
        public const string Out = "Out";
        public const string Speaker = "Speaker";
        public const string Dialogue = "Dialogue";
        public const string StickyChoice = "Is Sticky Choice?";
        public const string KnotName = "Knot Name";
        public const string DivertName = "Divert Name";
        public const string Tags = "Tags";
        public const string Variable = "Variable";

        public string ChoiceTextIndex(int i)
        {
            return $"Choice Text {i}";
        }
    }
}