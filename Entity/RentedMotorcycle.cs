using Amazon.Runtime.Internal.Transform;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace registerAPI.Entity
{
    public class RentedMotorcycle
    {
        public int CNH { get; set; }
        public string? LicensePlate { get; set; }
        public DateOnly StartPeriod  { get; set; }
        public DateOnly EndPeriod { get; set; }
        public string? TypeCNH { get; set; }
        public int ChooseYourPlan { get; set; }


       
    }

    
}
