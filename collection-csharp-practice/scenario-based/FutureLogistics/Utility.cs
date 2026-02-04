// using System;
// using System.Text.RegularExpressions;

// public class Utility : IUtility
// {
//     public GoodsTransport ParseDetails(string input)
//     {
//         string[] parts = input.Split(':');
        
//         string transportId = parts[0];
//         string transportDate = parts[1];
//         int transportRating = int.Parse(parts[2]);
//         string transportType = parts[3];
        
//         if (transportType.ToLower() == "bricktransport")
//         {
//             float brickSize = float.Parse(parts[4]);
//             int brickQuantity = int.Parse(parts[5]);
//             float brickPrice = float.Parse(parts[6]);
            
//             return new BrickTransport(transportId, transportDate, transportRating, 
//                                     brickSize, brickQuantity, brickPrice);
//         }
//         else if (transportType.ToLower() == "timbertransport")
//         {
//             float timberLength = float.Parse(parts[4]);
//             float timberRadius = float.Parse(parts[5]);
//             string timberType = parts[6];
//             float timberPrice = float.Parse(parts[7]);
            
//             return new TimberTransport(transportId, transportDate, transportRating,
//                                      timberLength, timberRadius, timberType, timberPrice);
//         }
        
//         return null;
//     }
    
//     public bool ValidateTransportId(string transportId)
//     {
//         string pattern = @"^RTS\d{3}[A-Z]$";
//         bool isValid = Regex.IsMatch(transportId, pattern);
        
//         if (!isValid)
//         {
//             Console.WriteLine($"Transport id {transportId} is invalid");
//             Console.WriteLine("Please provide a valid record");
//         }
        
//         return isValid;
//     }
    
//     public string FindObjectType(GoodsTransport goodsTransport)
//     {
//         if (goodsTransport is TimberTransport)
//             return "TimberTransport";
//         else if (goodsTransport is BrickTransport)
//             return "BrickTransport";
        
//         return "";
//     }
// }