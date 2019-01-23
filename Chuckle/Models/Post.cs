using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chuckle.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Visible { get; set; }
    }
}
