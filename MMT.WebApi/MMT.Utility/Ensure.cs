using System;

namespace MMT.Utility
{
    public class Ensure
    {
        public static void IsNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
                throw new ArgumentNullException(null, $"Argument {argumentName} cannot be null.");
        }
        public static void IsNotNullOrEmpty(string argumentValue, string argumentName)
        {
            if (string.IsNullOrEmpty(argumentValue))
                throw new ArgumentNullException(null, $"Argument {argumentName} cannot be null or empty.");
        }
        public static void IsNullOrWhiteSpace(string argumentValue, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argumentValue))
                throw new ArgumentNullException(null, $"Argument {argumentName} cannot be null or whitespace.");
        }

        public static void IsNullOrWhiteSpace(object email, string v)
        {
            throw new NotImplementedException();
        }
    }
}
