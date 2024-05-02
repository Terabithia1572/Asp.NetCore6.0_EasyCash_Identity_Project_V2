using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageURL { get; set; }
    }
}
