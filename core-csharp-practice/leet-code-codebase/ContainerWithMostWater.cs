public class ContainerWithMostWater {
    public int MaxArea(int[] arr) {
        

        int max =0;
        int st =0;
        int ed = arr.Length-1;
        while (st<ed){
            int h = Math.Min(arr[st],arr[ed]);
            int w =ed - st;
            int area = h*w;
            max = Math.Max(max,area);
            if(arr[st]<arr[ed]){
                st++;

            }else
            {
                ed--;
            }

        }
       
      return max;
        
    }
}