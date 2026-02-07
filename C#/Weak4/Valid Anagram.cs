public class Solution {
    public bool IsAnagram(string s, string t) {
        char[] sString = s.ToCharArray();
        char[] tString = t.ToCharArray();

        Array.Sort(sString);
        Array.Sort(tString);

        if (new string(sString) == new string(tString))
        return true;
        else
        return false;

        
    }
}
