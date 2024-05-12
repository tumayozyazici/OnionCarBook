using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Dto.AboutDtos
{
    public class ResultAboutDto
    {
        public int aboutID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imgUrl { get; set; }
    }
}