namespace ApplicationServices.Helpers
{
    public static class StringExtension
    {
        public static string ToCamelCase(this string str)
        {
            return string.Join(" ",str.Split().Select(i => char.ToUpper(i[0]) + i.Substring(1)));
        }
    }
}
