using AutoMapper;
using BL.Models;
using DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Profiles
{
    public class PointsCalcTypeProfile : Profile
    {
        public PointsCalcTypeProfile()
        {
            CreateMap<CalculationType, PointsCalcType>();
            CreateMap<PointsCalcType, CalculationType>();
        }
    }
}
