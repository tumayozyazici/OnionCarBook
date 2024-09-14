using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.CarFeatureInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values =_context.CarFeatures.Where(x=>x.CarFeatureID==id).FirstOrDefault();
            values.Available= false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public async Task CreateCarFeatureByCarIdAsync(CarFeature carFeature)
        {
            await _context.CarFeatures.AddAsync(carFeature);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CarFeature>> GetCarFeaturesByCarIdAsync(int carId)
        {
            return await _context.CarFeatures.Include(x => x.Feature).Where(x => x.CarID == carId).ToListAsync();
        }
    }
}
