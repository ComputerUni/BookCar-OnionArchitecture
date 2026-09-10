using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingWithCarDto
    {
        public int CarPricingId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public TransmissionType Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
    }
}
