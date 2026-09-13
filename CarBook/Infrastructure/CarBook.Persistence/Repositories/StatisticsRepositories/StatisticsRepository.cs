using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Enums;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository(CarBookContext _context) : IStatisticsRepository
    {
        public string BlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string BrandNameByMaxCar()
        {
            throw new NotImplementedException();

        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var value = _context.CarPricings.Where(x => x.Pricing.Name == "Günlük").Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var value = _context.CarPricings.Where(x => x.Pricing.Name == "Aylık").Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var value = _context.CarPricings.Where(x => x.Pricing.Name == "Haftalık").Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var value = _context.CarPricings.Where(x => x.Pricing.Name == "Günlük").OrderByDescending(x => x.Amount).Select(x => x.Car.Brand.Name + " " + x.Car.Model).FirstOrDefault();
            return value;
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var value = _context.CarPricings.Where(x => x.Pricing.Name == "Günlük").OrderBy(x => x.Amount).Select(x => x.Car.Brand.Name + " " + x.Car.Model).FirstOrDefault();
            return value;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == FuelType.Elektrik).Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == FuelType.Benzin || x.Fuel == FuelType.Dizel).Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == TransmissionType.Otomatik).Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
