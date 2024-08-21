﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionCarBook.Dto.CommentDtos
{
    public class ResultCommentByBlogIdDto
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public int BlogID { get; set; }
    }
}