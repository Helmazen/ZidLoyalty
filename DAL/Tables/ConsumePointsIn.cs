using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tables
{
   public class ConsumePointsIn : Entity
    {
        public long EarnedInStoreId { get; set; }

        [ForeignKey("LoyaltyStoreGroup")]
        public long ConsumeInGroupId { get; set; }


        [ForeignKey("ConsumeInStore")]
        public long ConsumeInStoreId { get; set; }


        public Store ConsumeInStore { get; set; }
    }
}
