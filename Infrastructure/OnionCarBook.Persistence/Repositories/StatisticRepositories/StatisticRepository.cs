using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.StatisticInterfaces;
using OnionCarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == 2).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == 5).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var value = _context.CarPricings.Where(x => x.PricingID == 3).Average(x => x.Amount);
            return value;
        }

        public string GetBlogByMaxBlogComment()
        {
            var blogTitle = _context.Comments.Include(x => x.Blog).GroupBy(x => x.BlogID)
                                     .Select(g => new
                                     {
                                         BlogId = g.Key,
                                         Count = g.Count(),
                                         BlogTitle = g.FirstOrDefault().Blog.Title
                                     })
                                     .OrderByDescending(g => g.Count)
                                     .Select(g => g.BlogTitle)
                                     .FirstOrDefault();

            return blogTitle;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public string GetBrandByMaxCarCount()
        {
            var brandName = _context.Cars.Include(x => x.Brand).GroupBy(x => x.BrandID)
                                    .Select(g => new
                                    {
                                        BrandId = g.Key,
                                        Count = g.Count(),
                                        BrandName = g.FirstOrDefault().Brand.Name
                                    })
                                    .OrderByDescending(g => g.Count)
                                    .Select(g => g.BrandName)
                                    .FirstOrDefault();

            return brandName;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModelByMaxRentPriceDaily()
        {
            var brandModel = _context.CarPricings.Where(x => x.PricingID == 2).OrderByDescending(x => x.Amount)
                                    .Include(x => x.Car)
                                    .ThenInclude(c => c.Brand)
                                    .Select(x => x.Car.Brand.Name + " " + x.Car.Model)
                                    .FirstOrDefault();

            return brandModel;
        }

        public string GetCarBrandAndModelByMinRentPriceDaily()
        {
            var brandModel = _context.CarPricings.Where(x => x.PricingID == 2).OrderBy(x => x.Amount)
                                     .Include(x => x.Car)
                                     .ThenInclude(c => c.Brand)
                                     .Select(x => x.Car.Brand.Name + " " + x.Car.Model)
                                     .FirstOrDefault();

            return brandModel;
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountBelow1000Km()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCountOfAutomaticCars()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}