namespace Chelsea.Model.Domain
{
    public class Colour
    {
        public const string RED = "F12D2D";
        public const string BLUE = "2D9BF1";

        private static readonly string[] Colours = new[]
        {
            Colour.RED, Colour.BLUE
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