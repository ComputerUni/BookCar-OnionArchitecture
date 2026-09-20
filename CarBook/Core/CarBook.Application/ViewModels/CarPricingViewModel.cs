using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.ViewModels
{
    public class CarPricingViewModel
    {
        public string Model { get; set; }
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeklyAmount { get; set; }
        public decimal MonthlyAmount { get; set; }
        public TransmissionType Transmission { get; set; }
        public FuelType Fuel { get; set; }
    }
}
