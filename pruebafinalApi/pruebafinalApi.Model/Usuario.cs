using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebafinalApi.Model
{
    public class Usuario
    {

         public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreateDate { get; set; }

        public string UpdateDate { get; set; }

        public int IdProfile { get; set; }
    }
}
