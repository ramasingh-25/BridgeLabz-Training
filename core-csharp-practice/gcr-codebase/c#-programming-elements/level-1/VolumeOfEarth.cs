using System;

public class VolumeOfEarth{
public static void Main(String[] args){
   
        double radiusKm = 6378;
        double pi = Math.PI;

     
        double volumeKm = (4.0 / 3.0) * pi * Math.Pow(radiusKm, 3);

       
        double radiusMiles = radiusKm * 0.621371;

   
        double volumeMiles = (4.0 / 3.0) * pi * Math.Pow(radiusMiles, 3);

        Console.WriteLine("The volume of earth in cubic kilometers is  "+  volumeKm  +"in Miles  " + volumeMiles);
    }
}

   
   

