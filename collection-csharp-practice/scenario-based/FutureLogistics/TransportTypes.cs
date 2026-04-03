// using System;

// public class BrickTransport : GoodsTransport
// {
//     private float brickSize;
//     private int brickQuantity;
//     private float brickPrice;
    
//     public float BrickSize
//     {
//         get { return brickSize; }
//         set { brickSize = value; }
//     }
    
//     public int BrickQuantity
//     {
//         get { return brickQuantity; }
//         set { brickQuantity = value; }
//     }
    
//     public float BrickPrice
//     {
//         get { return brickPrice; }
//         set { brickPrice = value; }
//     }
    
//     public BrickTransport(string transportId, string transportDate, int transportRating, 
//                          float brickSize, int brickQuantity, float brickPrice) 
//         : base(transportId, transportDate, transportRating)
//     {
//         this.brickSize = brickSize;
//         this.brickQuantity = brickQuantity;
//         this.brickPrice = brickPrice;
//     }
    
//     public override string VehicleSelection()
//     {
//         if (brickQuantity < 300)
//             return "Truck";
//         else if (brickQuantity >= 300 && brickQuantity <= 500)
//             return "Lorry";
//         else
//             return "MonsterLorry";
//     }
    
//     public override float CalculateTotalCharge()
//     {
//         float price = brickPrice * brickQuantity;
//         float tax = price * 0.3f;
        
//         float vehiclePrice = 0;
//         string vehicle = VehicleSelection().ToLower();
//         if (vehicle == "truck") vehiclePrice = 1000;
//         else if (vehicle == "lorry") vehiclePrice = 1700;
//         else if (vehicle == "monsterlorry") vehiclePrice = 3000;
        
//         float discount = 0;
//         if (transportRating == 5) discount = price * 0.20f;
//         else if (transportRating == 3 || transportRating == 4) discount = price * 0.10f;
        
//         return price + vehiclePrice + tax - discount;
//     }
// }

// public class TimberTransport : GoodsTransport
// {
//     private float timberLength;
//     private float timberRadius;
//     private string timberType;
//     private float timberPrice;
    
//     public float TimberLength
//     {
//         get { return timberLength; }
//         set { timberLength = value; }
//     }
    
//     public float TimberRadius
//     {
//         get { return timberRadius; }
//         set { timberRadius = value; }
//     }
    
//     public string TimberType
//     {
//         get { return timberType; }
//         set { timberType = value; }
//     }
    
//     public float TimberPrice
//     {
//         get { return timberPrice; }
//         set { timberPrice = value; }
//     }
    
//     public TimberTransport(string transportId, string transportDate, int transportRating,
//                           float timberLength, float timberRadius, string timberType, float timberPrice)
//         : base(transportId, transportDate, transportRating)
//     {
//         this.timberLength = timberLength;
//         this.timberRadius = timberRadius;
//         this.timberType = timberType;
//         this.timberPrice = timberPrice;
//     }
    
//     public override string VehicleSelection()
//     {
//         float area = 2 * 3.147f * timberRadius * timberLength;
        
//         if (area < 250)
//             return "Truck";
//         else if (area >= 250 && area <= 400)
//             return "Lorry";
//         else
//             return "MonsterLorry";
//     }
    
//     public override float CalculateTotalCharge()
//     {
//         float volume = 3.147f * timberRadius * timberRadius * timberLength;
//         float typeMultiplier = timberType.ToLower() == "premium" ? 0.25f : 0.15f;
//         float price = volume * timberPrice * typeMultiplier;
//         float tax = price * 0.3f;
        
//         float vehiclePrice = 0;
//         string vehicle = VehicleSelection().ToLower();
//         if (vehicle == "truck") vehiclePrice = 1000;
//         else if (vehicle == "lorry") vehiclePrice = 1700;
//         else if (vehicle == "monsterlorry") vehiclePrice = 3000;
        
//         float discount = 0;
//         if (transportRating == 5) discount = price * 0.20f;
//         else if (transportRating == 3 || transportRating == 4) discount = price * 0.10f;
        
//         return price + vehiclePrice + tax - discount;
//     }
// }