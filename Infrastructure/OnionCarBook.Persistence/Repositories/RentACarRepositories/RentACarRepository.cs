using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.RentACarInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Repositories.RentACarRepositories
{
	public class RentACarRepository : IRentACarRepository
	{
		private readonly CarBookContext _context;

		public RentACarRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
		{
			return await _context.RentACars.Where(filter).Include(x=>x.Car).ThenInclude(x=>x.Brand).ToListAsync();
		}
	}
}
