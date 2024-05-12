using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }



        //Navigation Props
        public List<Blog> Blogs { get; set; }

    }
}
