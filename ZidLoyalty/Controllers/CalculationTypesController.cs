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

namespace ZidLoyalty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationTypesController : BaseAPIController
    {

        public CalculationTypesController(LoyaltyEntitiesDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        [HttpGet("GetAllCalculationType")]
        public JsonResult GetAllCalculationType()
        {
            return new JsonResult(new ResponseModel()
            {
                code = 200,
                messsage = "Calculation types have been retrieved saved successfully",
                data = CalculationType.GetCalculationTypesList(_context, _mapper)
            });
        }

        [HttpPost("AddNewCalculationType")]
        public JsonResult AddNewCalculationType(CalculationType model)
        {
            //_logger.Debug("Hossam");
            //var obj = _context.ConsumePointsIn.Include(a => a.ConsumeInStore).ToList();

            ValidationResult validation = new CalculationTypeValidator().Validate(model);

            if (validation.IsValid)
            {
                CalculationType.AddNewCalculationType(model, _context, _mapper);

                return new JsonResult(new ResponseModel()
                {
                    code = 200,
                    messsage = "Calculation type has been saved successfully"
                });
            }
            else
            {
                return new JsonResult(new ResponseModel()
                {
                    code = 500,
                    messsage = "Cannot add the new calcualtion type ",
                    errors = validation.Errors.Select(a => new { PropertyName = a.PropertyName, ErrorMessage = a.ErrorMessage }).ToList<object>()
                });
            }

        }

        [HttpPut("UpdateCalculationType")]
        public JsonResult UpdateCalculationType(CalculationType model)
        {

            ValidationResult validation = new UpdateCalculationTypeValidator().Validate(model);

            if (validation.IsValid)
            {
                bool exist =  CalculationType.UpdateCalculationType(model, _context, _mapper);

                if(exist)
                {
                    return new JsonResult(new ResponseModel()
                    {
                        code = 200,
                        messsage = "Calculation type has been updated successfully"
                    });
                }
                else
                {
                    return new JsonResult(new ResponseModel()
                    {
                        code = 500,
                        messsage = "Calculation type with ID : " + model.Id + " was not found"
                    });
                }
            }
            else
            {
                return new JsonResult(new ResponseModel()
                {
                    code = 500,
                    messsage = "Cannot update calcualtion type ",
                    errors = validation.Errors.Select(a => new { PropertyName = a.PropertyName, ErrorMessage = a.ErrorMessage }).ToList<object>()
                });
            }

        }
    }
}
