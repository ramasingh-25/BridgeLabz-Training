using System;

class LengthOfLastWord
{
    public int LengthOfLastWordMethod(string s)
	
	
	
    {
        string str = s.Trim();
        int count = 0;



        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] != ' ')
            {
                count++;
            }
            else
			
			
            {
                break;
            }
        }
		
		
        return count;
    }
	
	
}
