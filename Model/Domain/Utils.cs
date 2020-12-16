using System;

namespace Chelsea.Model.Domain
{
    public class Utils
    {
        /// <summary>
        /// Gets a random positive integer number.
        /// </summary>
        /// <returns>A positive integer number.</returns>
        public static int GetRandomInt()
        {
            var random = new Random();
            var number = random.Next();
            return number;
        }
    }
}