using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.ReviewInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetReviewByCarIdAsync(int id)
        {
            return await _context.Reviews.Where(x => x.CarID == id).ToListAsync();
        }
    }
}
