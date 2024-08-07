﻿using Microsoft.EntityFrameworkCore;
using OnionCarBook.Application.Interfaces.BlogInterfaces;
using OnionCarBook.Domain.Entities;
using OnionCarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

		public List<Blog> GetAllBlogsWithAuthros()
		{
			return _context.Blogs.Include(y=>y.Author).ToList();
		}

        /// <summary>
        /// Aslında bu methodun AuthorRepositoryde açılması lazımdı o sebeple hatalı isimlendirme var bunda düşmen guzuuum.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Blog> GetBlogsByAuthorId(int id)
        {
            return _context.Blogs.Include(x=>x.Author).Where(y=>y.BlogID==id).ToList();
        }

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            return _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
        }
    }
}
