using AutoMapper;
using DAL;
using DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BL.Models
{
    public class StoreConfiguration
    {
        public long Id { get; set; }
        public CalculationType CalculationType { get; set; }
        public string DefaultName { get; set; }
        public string Name { get; set; }
        public int PointsAmt { get; set; }
        public decimal PerPurchaseAmt { get; set; }
        public long StoreId { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }



        public static IQueryable<StoreConfiguration> GetStoresConfigsList(bool activeOnly, LoyaltyEntitiesDBContext db, IMapper _mapper)
        {
            return db.StoreLoyaltyConfig.Include(a=>a.PointsCalcType).Where(a=> !activeOnly || a.IsActive == activeOnly).Select(a => new StoreConfiguration() { 
                Id = a.Id, CalculationType = new CalculationType() 
                { 
                    Desciption = a.PointsCalcType.Desciption ,
                    DesciptionAr = a.PointsCalcType.DesciptionAr,
                    Name = a.PointsCalcType.Name
                }  ,
                DefaultName = a.DefaultName,
                PointsAmt = a.PointsAmt,
                PerPurchaseAmt = a.PerPurchaseAmt,
                StoreId = a.StoreId,
                IsActive = a.IsActive,
                StartDate = a.StartDate,
                EndDate =  a.EndDate,
                Name = a.Name
            });
        }

        public static IQueryable<StoreConfiguration> GetStoreConfigsList(long storeId, bool activeOnly, LoyaltyEntitiesDBContext db, IMapper _mapper)
        {

            return db.StoreLoyaltyConfig.Include(a => a.PointsCalcType).Where(a => (!activeOnly || a.IsActive == activeOnly) && a.StoreId == storeId).Select(a => new StoreConfiguration()
            {
                Id = a.Id,
                CalculationType = new CalculationType()
                {
                    Desciption = a.PointsCalcType.Desciption,
                    DesciptionAr = a.PointsCalcType.DesciptionAr,
                    Name = a.PointsCalcType.Name
                },
                DefaultName = a.DefaultName,
                PointsAmt = a.PointsAmt,
                PerPurchaseAmt = a.PerPurchaseAmt,
                StoreId = a.StoreId,
                IsActive = a.IsActive,
                StartDate = a.StartDate,
                EndDate = a.EndDate.Value,
                Name = a.Name
            });

        }



        public static bool AddNewStoreConfiguration(StoreConfiguration model, LoyaltyEntitiesDBContext db, IMapper _mapper)
        {
            StoreLoyaltyConfig newStoreLoyaltyConfig = new StoreLoyaltyConfig()
            {
                Name = model.Name,
                DefaultName = "Store " + model.StoreId + " Calc Type : " + model.CalculationType.Id,
                IsActive = true,
                PerPurchaseAmt = model.PerPurchaseAmt,
                PointsAmt = model.PointsAmt,
                PointsCalcTypeId = model.CalculationType.Id,
                StartDate = DateTime.Now,
                StoreId = model.StoreId
            };

            db.StoreLoyaltyConfig.Add(newStoreLoyaltyConfig);

            db.SaveChanges();

            List<StoreLoyaltyConfig> oldconfigs =  db.StoreLoyaltyConfig.Where(a => a.StoreId == model.StoreId && a.IsActive == true && a.Id != newStoreLoyaltyConfig.Id).ToList();

            foreach (StoreLoyaltyConfig item in oldconfigs)
            {
                item.IsActive = false;
                item.EndDate = DateTime.Now;
                db.SaveChanges();
            }

            return true;
        }



        public static bool UpdateCalculationType(CalculationType model, LoyaltyEntitiesDBContext db, IMapper _mapper)
        {
            PointsCalcType calcType = db.PointsCalcType.Where(a => a.Id == model.Id).FirstOrDefault();

            if (calcType == null) return false;

            calcType.Name = model.Name;
            calcType.Desciption = model.Desciption;
            calcType.DesciptionAr = model.DesciptionAr;


            db.SaveChanges();

            return true;
        }



        public static IQueryable<CalculationType> GetCalculationTypesList(LoyaltyEntitiesDBContext db, IMapper _mapper)
        {
            return db.PointsCalcType.Select(a => new CalculationType() { Id = a.Id, Desciption = a.Desciption, DesciptionAr = a.DesciptionAr, Name = a.Name });
        }
    }
}
