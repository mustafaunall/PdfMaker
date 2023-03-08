public static class StringExtensions
{

    public static string ReplaceBulk(this string s, Dictionary<string, object> values)
    {
        foreach (var item in values)
        {
            s = s.Replace(item.Key, item.Value.ToString());
        }
        return s;
    }
}

