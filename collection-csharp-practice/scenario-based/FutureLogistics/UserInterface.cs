// using System;

// public class UserInterface
// {
//     public static void Main(string[] args)
//     {
//         IUtility utility = new Utility();
        
//         Console.WriteLine("Enter the Goods Transport details");
//         string input = Console.ReadLine();
        
//         string[] parts = input.Split(':');
//         string transportId = parts[0];
        
//         if (!utility.ValidateTransportId(transportId))
//         {
//             return;
//         }
        
//         GoodsTransport transport = utility.ParseDetails(input);
//         string objectType = utility.FindObjectType(transport);
        
//         Console.WriteLine($"Transporter id : {transport.TransportId}");
//         Console.WriteLine($"Date of transport : {transport.TransportDate}");
//         Console.WriteLine($"Rating of the transport : {transport.TransportRating}");
        
//         if (objectType == "BrickTransport")
//         {
//             BrickTransport brick = (BrickTransport)transport;
//             Console.WriteLine($"Quantity of bricks : {brick.BrickQuantity}");
//             Console.WriteLine($"Brick price : {brick.BrickPrice}");
//         }
//         else if (objectType == "TimberTransport")
//         {
//             TimberTransport timber = (TimberTransport)transport;
//             Console.WriteLine($"Type of the timber : {timber.TimberType}");
//             Console.WriteLine($"Timber price per kilo : {timber.TimberPrice}");
//         }
        
//         Console.WriteLine($"Vehicle for transport : {transport.VehicleSelection()}");
//         Console.WriteLine($"Total charge : {transport.CalculateTotalCharge()}");
//     }
// }