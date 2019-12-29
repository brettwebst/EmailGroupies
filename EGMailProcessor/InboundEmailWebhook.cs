using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using EGMailProcessor.Models;
using EGMailProcessor.Db.todo;

namespace EGMailProcessor
{
    public static class InboundEmailWebhook
    {
        [FunctionName("InboundEmailWebhook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];
            if(req == null || req.Body == null)
            {
                log.LogError("Request failed. Request or Body were null");
            }
            log.LogInformation($"Body Stream is at position {req.Body.Position}");
            if (req.Body.Position > 0)
            {
                log.LogInformation("Attempting to set position to 0");
                req.Body.Position = 0;
                log.LogInformation($"Body Stream is at position {req.Body.Position}");
            }
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation($"RequestBody read successfully::{requestBody}");
            try
            {

                InboundEmailRaw emailRaw = new InboundEmailRaw();
                emailRaw.Id = Guid.NewGuid().ToString();
                emailRaw.body = requestBody;
                emailRaw.QueryStringVariables = "";// req.QueryString.ToString();
                emailRaw.PostVars = "";// string.Join("&", req.Form.Select(f => { return $"{f.Key}={f.Value}"; }));


                DocumentDBRepository<InboundEmailRaw> repo = new Db.todo.DocumentDBRepository<InboundEmailRaw>();
                var dbDoc = await repo.CreateItemAsync(emailRaw);
                log.LogInformation($"New Item Created {dbDoc.Id}");

                return (ActionResult)new OkObjectResult(dbDoc);
            }catch(Exception ex)
            {
                return (ActionResult)new BadRequestObjectResult(ex);
            }

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
