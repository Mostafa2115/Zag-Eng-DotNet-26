public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        Array.Sort(strs);
        int a = strs.Length;
        string n = strs[0], m = strs[a - 1], ans = "";
        for (int i = 0; i < n.Length; i++)
        {
             if (n[i] == m[i]) { ans += n[i]; }
             else break;
        }
        return ans;
    }
}
