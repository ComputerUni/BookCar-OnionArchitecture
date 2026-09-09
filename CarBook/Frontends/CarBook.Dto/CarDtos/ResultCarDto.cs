using CarBook.Domain.Enums;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarDtos
{
    public class ResultCarDto
    {
        public int carId { get; set; }
        public int brandId { get; set; }
        public string brandName { get; set; }
        public string model { get; set; }
        public string coverImageUrl { get; set; }
        public int km { get; set; }
        public TransmissionType transmission { get; set; }
        public byte seat { get; set; }
        public byte luggage { get; set; }
        public FuelType fuel { get; set; }
        public string bigImageUrl { get; set; }
    }
}
