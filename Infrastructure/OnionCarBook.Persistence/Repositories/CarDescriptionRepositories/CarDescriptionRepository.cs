using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.CarDescriptionInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<CarDescription> GetCarDescriptionByCarIdAsync(int id)
        {
            return await _context.CarDescriptions.FirstOrDefaultAsync(x => x.CarID == id);
        }
    }
}
