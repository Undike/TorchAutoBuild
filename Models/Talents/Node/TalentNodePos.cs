namespace TorchAutoBuild.Models.Talents.Node
{
    public readonly struct TalentNodePos
    {
        public int X { get; }
        public int Y { get; }
        public TalentNodePos(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
