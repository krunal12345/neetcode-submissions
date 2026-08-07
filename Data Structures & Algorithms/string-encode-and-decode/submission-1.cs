public class Solution {

    public string Encode(IList<string> strs)
    {
        StringBuilder sb = new StringBuilder();

        foreach (string str in strs)
        {
            sb.Append(str.Length);
            sb.Append('#');
            sb.Append(str);
        }

        return sb.ToString();
    }

    public List<string> Decode(string s)
    {
        List<string> result = new List<string>();

        int i = 0;

        while (i < s.Length)
        {
            // Find '#'
            int j = i;

            while (s[j] != '#')
                j++;

            // Length is between i and j
            int length = int.Parse(s.Substring(i, j - i));

            // Skip '#'
            j++;

            // Extract string
            result.Add(s.Substring(j, length));

            // Move to next encoded string
            i = j + length;
        }

        return result;
    }
}
