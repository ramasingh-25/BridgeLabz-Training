class Palindrome {

      //method to check whether the number is palindrome
	  
      public boolean isPalindrome(int x) {
	
	//Negative Numbers cannot be palindrome 
	
	
        if(x<0) return false;
        int original=x;
      int rev =0;
	  
	  //Reverse the number
      while (x!=0){
        int lastdigit = x%10;
        rev = rev*10 + lastdigit;
        x=x/10;
    
        }

        
// if both are equal then number is palindrome 
      return original ==rev;
      }
}