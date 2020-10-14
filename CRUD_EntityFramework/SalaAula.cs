using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EntityFramework
{
    class SalaAula
    {
        public int id { get; set; }
        public string professor { get; set; }
        public string sala { get; set; }
        public string curso { get; set; }
        public string data { get; set; }
    }
}
