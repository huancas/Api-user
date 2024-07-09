using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebafinalApi.Data
{
    public class PostgreConfig
    {
       

        public PostgreConfig(string connectString) => ConnectString = connectString;

        public string ConnectString { get; set; }

    }
}
