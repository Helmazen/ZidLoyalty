using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using AutoMapper;

namespace ZidLoyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseAPIController  : ControllerBase 
    {
        protected LoyaltyEntitiesDBContext _context;

        protected ILogger _logger;
        protected readonly IMapper _mapper;

        public BaseAPIController(LoyaltyEntitiesDBContext context , IMapper mapper)
        {

            _logger =  NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            _context = context;

            _mapper = mapper;
        }


    }
}
