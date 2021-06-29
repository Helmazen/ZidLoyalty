using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Tables
{
   public class StoreLoyaltyConfig : Entity
    {
        [ForeignKey("PointsCalcType")]
        public long PointsCalcTypeId { get; set; }
        public PointsCalcType PointsCalcType { get; set; }
        public string DefaultName { get; set; }
        public string Name { get; set; }
        public int PointsAmt { get; set; }
        public decimal PerPurchaseAmt { get; set; }
        public long StoreId { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
