using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace techMADT.Core.Entities
{
    public class AppUser :IEntity

    {
        public int Id { get; set; }

        public string Name { get; set; } 

        public string Surname { get; set; }

        public string Email { get; set; } 
        public string? Phone { get; set; } 
        public string Password { get; set; }

        public string? UserName { get; set; }=string.Empty;

        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime CreatedDate { get; set; }

      

        public Guid? UpdateDate { get; set; }=Guid.NewGuid();















    }
}
