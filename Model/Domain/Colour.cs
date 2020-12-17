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

        /// <summary>
        /// Checks if a string is a valid colour that exists in the Colour class.
        /// </summary>
        /// <param name="value">String representing the colour to be evaluated.</param>
        /// <returns>A boolean whether the value is valid or not.</returns>
        public static bool IsValidColour(string value)
        {
            foreach (var colour in Colour.Colours)
            {
                if (value == colour) return true;
            }

            return false;
        }
    }
}