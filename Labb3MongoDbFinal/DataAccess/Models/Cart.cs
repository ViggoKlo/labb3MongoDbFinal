using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Cart
    {
        public ObjectId Id { get; set; }

        public Guid CustomerId { get; set; }

        public int SausageAmount { get; set; }  = 0;

        public int BreadAmount { get; set; } = 0;

        public int KetchupAmount { get; set; } = 0;
    }
}
