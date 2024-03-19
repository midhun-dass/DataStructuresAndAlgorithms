namespace DataStructuresAndAlgorithms.DynamicProgramming
{
    public class PalindromicSubstrings
    {
        public static List<string> SubstringsPalindrome(string s) {
            string paliStr = "";
            List<string> res = new List<string>();

            for (int i = 0; i < s.Length; i++)
            {
                int l = i;
                int r = i;

                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    paliStr = s.Substring(l, r - l + 1);
                    res.Add(paliStr);

                    l -= 1;
                    r += 1;
                }

                l = i;
                r = i + 1;

                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                   paliStr = s.Substring(l, r - l + 1);
                   res.Add(paliStr);

                    l -= 1;
                    r += 1;
                }
            }

            return res;
            
        }
    }
}