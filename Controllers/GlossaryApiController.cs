using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBISEvaluation.Models;
using IBISEvaluation.Models.Glossary;
using IBISEvaluation.Models.Responses;
using IBISEvaluation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IBISEvaluation.Controllers
{
    [Route("api/glossary")]
    [ApiController]
    public class GlossaryApiController : BaseApiController
    {
        //private readonly ILogger<ItineraryApiController> _logger;
        private IGlossaryServices _service = null;


        public GlossaryApiController(IGlossaryServices service, ILogger<GlossaryApiController> logger)
        {
            _service = service;
        }

        [HttpPost]
        public string Add(AddRequest model)
        {
            string connString = "Server=.;Database=IBISEvaluation;Trusted_Connection=True;MultipleActiveResultSet=True";

            //int iCode = 200;
            //BaseResponse response = null;

            //try
            //{

            //    return "Added Succesfully";
            //}
            //catch (Exception)
            //{

            //    return "Failed to Add";
            //Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master;
            //}

            return (connString);

        }

        [HttpGet]
        public ActionResult<List<Entity>> GetGlossary()
        {
            string connString = "Server=(localdb);Database=IBISEvaluation;Trusted_Connection=True;";

            int iCode = 200;
            BaseResponse response = null;

            try
            {
                List<Entity> list = _service.GetGlossary(connString);
                if (list == null)
                {
                    iCode = 400;

                    response = new ErrorResponse("Application resource not found");
                }
                if (list != null)
                {
                    response = new ItemResponse<Entity> { Item = list };
                }
            }
            catch (Exception ex)
            {
                iCode = 500;

                response = new ErrorResponse(ex.Message);
            }

            return StatusCode(iCode, response);
        }

    }
}