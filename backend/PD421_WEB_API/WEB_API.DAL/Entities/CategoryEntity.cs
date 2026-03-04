using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_API.DAL.Entities
{
    public class CategoryEntity 
    {
        public int Id { get; set; }

        public required String Name { get; set; }

        public String? Description;

        public String? Image;

    }
}
