namespace Vgtu.Test.Helpers
{
    public static class StringUrlBuilder
    {
        public static string BuildUrl(string baseUrl, string uri)
        {
            int length = baseUrl.Length - 1;
            if (baseUrl[length] != '/')
                baseUrl += '/';
            return baseUrl + uri;
        }

        public static string BuildQueryUrl(string baseUrl, string query, string action)
        {
            string url = baseUrl + "?q=";
            query = FillSpaces(query, '+');
            return url + query + "&act=" + action;
        }

        public static string FillSpaces(string str, char filler)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace(' ', filler);
            }
            return "";
        }
    }
}
