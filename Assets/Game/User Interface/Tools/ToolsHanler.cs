using UnityEngine;

namespace AndreyNosov.CylinderLock.Game
{
    public static class ToolsHanler
    {
        public static string GetTextLableTool(ToolType tool, int numbersPin)
        {
            switch (tool)
            {
                case ToolType.Sin:
                    return "-1|+1|-1";
                case ToolType.ReSin:
                    return "+1|-1|+1";
                case ToolType.Magnet:
                    return "0|0|0";
                case ToolType.ReMagnet:
                    return "10|10|10";
                case ToolType.Random:
                    return "Random";
                case ToolType.Reset:
                    return "Default";
                case ToolType.Frozen:
                    return "Frozen";
                default:
                    return "";
            }
        }

        public static void UseTool(ToolType tool, Pin[] pins)
        {
            switch (tool)
            {
                case ToolType.Sin:
                    ToolSin(pins);
                    break;
                case ToolType.ReSin:
                    ToolReSin(pins);
                    break;
                case ToolType.Magnet:
                    ToolMagnet(pins);
                    break;
                case ToolType.ReMagnet:
                    ToolReMagnet(pins);
                    break;
                case ToolType.Random:
                    ToolRandom(pins);
                    break;
                case ToolType.Reset:
                    ToolReset(pins);
                    break;
                case ToolType.Frozen:
                    ToolFrozen(pins);
                    break;
                default:
                    break;
            }
        }

        private static void ToolSin(Pin[] pins)
        {
            for (var i = 0; i < pins.Length; i++)
            {
                pins[i].PinValue += i % 2 == 0 ? -1 : 1;
            }
        }

        private static void ToolReSin(Pin[] pins)
        {
            for (var i = 0; i < pins.Length; i++)
            {
                pins[i].PinValue += i % 2 == 0 ? 1 : -1;
            }
        }

        private static void ToolMagnet(Pin[] pins)
        {
            for (var i = 0; i < pins.Length; i++)
            {
                pins[i].PinValue = 0;
            }
        }

        private static void ToolReMagnet(Pin[] pins)
        {
            for (var i = 0; i < pins.Length; i++)
            {
                pins[i].PinValue = 10;
            }
        }

        private static void ToolRandom(Pin[] pins)
        {
            for (var i = 0; i < pins.Length; i++)
            {
                pins[i].PinValue = Random.Range(0, 10);
            }
        }

        private static void ToolReset(Pin[] pins)
        {
            for (var i = 0; i < pins.Length; i++)
            {
                pins[i].ResetValue();
            }
        }

        private static void ToolFrozen(Pin[] pins)
        {
            for (var i = 0; i < pins.Length; i++)
            {
                pins[i].FrozenValue();
            }
        }
    }
}
