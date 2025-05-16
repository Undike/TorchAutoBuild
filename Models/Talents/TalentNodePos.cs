namespace TorchAutoBuild.Models.Talents
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
