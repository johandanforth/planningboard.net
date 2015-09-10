namespace PlanningBoard.Extensions
{
    public static class StringExtensions
    {
        public static string Left(this string text, int characters, bool dotdotdot = false)
        {
            if (text.Length > characters)
            {
                return dotdotdot
                    ? string.Format("{0}...", text.Substring(0, characters))
                    : text.Substring(0, characters);
            }
            return text;
        }
    }
}