using DAL;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BL.Models;
using BL.Validators;
using FluentValidation.Results;
using AutoMapper;
using System.Text.Json;
using ZidLoyalty.Integration;

namespace ZidLoyalty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreConfigController : BaseAPIController
    {

        public StoreConfigController(LoyaltyEntitiesDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        [HttpGet("GetAllStoresConfigs")]
        public JsonResult GetAllStoresConfigs(bool activeOnly)
        {
            ResponseModel result = new ResponseModel()
            {
                code = 200,
                messsage = "Stores Configurations have been retrieved saved successfully",
                data = StoreConfiguration.GetStoresConfigsList(activeOnly, _context, _mapper)
            };

            return new JsonResult(result);
        }



        [HttpGet("GetStoreConfigs")]
        public JsonResult GetStoreConfigs(long storeId, bool activeOnly)
        {
            return new JsonResult(new ResponseModel()
            {
                code = 200,
                messsage = "Stores Configurations have been retrieved saved successfully",
                data = StoreConfiguration.GetStoreConfigsList(storeId, activeOnly, _context, _mapper)
            });
        }




        [HttpPost("AddNewStoreConfig")]
        public JsonResult AddNewStoreConfig(StoreConfiguration model)
        {
            ValidationResult validation = new StoreConfigurationValidator(model).Validate(model);

            if (validation.IsValid)
            {

                // todo implement getStoreFromZed to check with zid apis 
                if (StoreIntegration.getStoreFromZed(model.StoreId) != null)
                {
                    StoreConfiguration.AddNewStoreConfiguration(model, _context, _mapper);

                    return new JsonResult(new ResponseModel()
                    {
                        code = 200,
                        messsage = "Store Configuration has been saved successfully"
                    });
                }
                else
                {
                    return new JsonResult(new ResponseModel()
                    {
                        code = 500,
                        messsage = "Invalid Store ID",
                        errors = validation.Errors.Select(a => new { PropertyName = a.PropertyName, ErrorMessage = a.ErrorMessage }).ToList<object>()
                    });
                }


            }
            else
            {
                return new JsonResult(new ResponseModel()
                {
                    code = 500,
                    messsage = "Cannot add the new store Configuration",
                    errors = validation.Errors.Select(a => new { PropertyName = a.PropertyName, ErrorMessage = a.ErrorMessage }).ToList<object>()
                });
            }

        }

        [HttpPut("updateStoreConfig")]
        public JsonResult updateStoreConfig(StoreConfiguration model)
        {

            ValidationResult validation = new StoreConfigurationValidator(model).Validate(model);

            if (validation.IsValid)
            {

                // todo implement getStoreFromZed to check with zid apis 
                if (StoreIntegration.getStoreFromZed(model.StoreId) != null)
                {
                    StoreConfiguration.AddNewStoreConfiguration(model, _context, _mapper);

                    return new JsonResult(new ResponseModel()
                    {
                        code = 200,
                        messsage = "Store Configuration has been updated successfully"
                    });
                }
                else
                {
                    return new JsonResult(new ResponseModel()
                    {
                        code = 500,
                        messsage = "Invalid Store ID",
                        errors = validation.Errors.Select(a => new { PropertyName = a.PropertyName, ErrorMessage = a.ErrorMessage }).ToList<object>()
                    });
                }


            }
            else
            {
                return new JsonResult(new ResponseModel()
                {
                    code = 500,
                    messsage = "Cannot update the store Configuration",
                    errors = validation.Errors.Select(a => new { PropertyName = a.PropertyName, ErrorMessage = a.ErrorMessage }).ToList<object>()
                });
            }

        }
    }
}
