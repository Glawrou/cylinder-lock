namespace AndreyNosov.CylinderLock.Game
{
    public class PinData
    {
        public int Value { get; private set; }
        public int CorrectValue { get; private set; }

        public PinData(int value, int correctValue)
        {
            Value = value;
            CorrectValue = correctValue;
        }
    }
}
