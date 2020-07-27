using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureQueueLibrary.Messages;
using AzureQueueLibrary.QueueConnection;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class MyPersonalController : ControllerBase
    {
        private readonly IQueueCommunicator _queueCommunicator;

        public MyPersonalController(IQueueCommunicator queueCommunicator)
        {
            _queueCommunicator = queueCommunicator;
        }

        [HttpGet]
        [Route("info")]
        public async Task<JsonResult> GetMyPersonalData()
        {
            return new JsonResult(
                new { Name = "Alexey", Age = 23, Hobbies = "IT, Chill out" }
                );
        }

        [HttpPost]
        [Route("msg/{contactName}/{emailAddress}")]
        public async Task<JsonResult> ContactMe(string contactName, string emailAddress)
        {
            var thankYouEmail = new SendEmailCommand()
            {
                To = emailAddress,
                Subject = "Thank tou for reaching out",
                Body = "We will contact you shortly"
            };
            await _queueCommunicator.SendAsync(thankYouEmail);

            var adminEmail = new SendEmailCommand()
            {
                To = "allah420@protonmail.com",
                Subject = "New contact",
                Body = $"{contactName} has reached out via contatc request. Plz responde back at {emailAddress}"
            };
            await _queueCommunicator.SendAsync(adminEmail);

            //send msg to me 
            return new JsonResult(new { });
        }
    }
}