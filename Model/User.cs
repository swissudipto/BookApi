using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Model
{
    public class User
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set;}
        public string? UserPassword { get; set;}
    }
}