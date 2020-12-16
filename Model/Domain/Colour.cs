namespace Chelsea.Model.Domain
{
    public class Colour
    {
        public const string NoColour = "";
        public const string Red = "F12D2D";
        public const string Blue = "2D9BF1";

        private static readonly string[] Colours = new[]
        {
            Colour.NoColour, Colour.Red, Colour.Blue
        };

        public static bool IsValidColor(string value)
        {
            foreach (var colour in Colour.Colours)
            {
                if (value == colour) return true;
            }

            return false;
        }
    }
}