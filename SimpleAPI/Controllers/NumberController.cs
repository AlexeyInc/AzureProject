using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class NumberController : ControllerBase
    {
        [HttpGet] 
        public ActionResult<string> Get()
        {
            return "Welcome to numbers world!";
        }

        [HttpGet]
        [Route("number/{num}")]
        public ActionResult<int> GetMultiplyNumber(int num)
        {
            return num * 2;
        }

        [HttpGet]
        [Route("coupleNumbers")]
        public ActionResult<int?> GetComplexObj([FromQuery] MyNumbers myNumbers)
        {
            var result = myNumbers.NumOne + myNumbers.NumTwo;
            return result;
        }

        [HttpGet]
        [Route("coupleNumbersFromBody")]
        public ActionResult<int?> GetComplexObjFromBody(MyNumbers myNumbers)
        {
            var result = myNumbers.NumOne + myNumbers.NumTwo;
            return result;
        }
    }
}