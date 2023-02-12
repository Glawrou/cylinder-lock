namespace AndreyNosov.CylinderLock.Game
{
    public class LevelData
    {
        public PinData[] Pins { get; private set; }
        public int Timer { get; private set; }
        public ToolType[] ToolsType { get; private set; }

        public LevelData(PinData[] pins, int timer, ToolType[] toolsType)
        {
            Pins = pins;
            Timer = timer;
            ToolsType = toolsType;
        }
    }
}