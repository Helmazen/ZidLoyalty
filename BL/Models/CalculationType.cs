using AutoMapper;
using DAL;
using DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CalculationType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Desciption { get; set; }
        public string DesciptionAr { get; set; }


        public static bool AddNewCalculationType(CalculationType model, LoyaltyEntitiesDBContext db, IMapper _mapper)
        {
            //new PointsCalcTypeProfile();

            //PointsCalcType newCalcType = _mapper.Map<PointsCalcType>(model);

            //db.PointsCalcType.Add(newCalcType);


            db.PointsCalcType.Add(new PointsCalcType()
            {
                Name = model.Name,
                Desciption = model.Desciption,
                DesciptionAr = model.DesciptionAr
            });
            db.SaveChanges();

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
