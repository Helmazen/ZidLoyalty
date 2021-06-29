using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tables
{
   public class Store : Entity
    {
        public string Name { get; set; }
         
        public List<ConsumePointsIn> ConsumePointsIns { get; set; }
    }
}
