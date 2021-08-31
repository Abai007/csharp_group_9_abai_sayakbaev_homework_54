using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_54.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int BrendId { get; set; }
        public Brend Brend { get; set; }
    }
}
