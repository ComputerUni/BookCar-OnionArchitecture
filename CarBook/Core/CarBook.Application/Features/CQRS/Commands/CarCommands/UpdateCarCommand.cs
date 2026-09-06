using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateCarCommand
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public TransmissionType Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
        public string BigImageUrl { get; set; }
    }
}
