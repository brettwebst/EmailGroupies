using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;

namespace EGMailProcessor
{
    public static class SendEmail
    {
        [FunctionName("SendEmail")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,ILogger log, ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            var config = new ConfigurationBuilder()
            .SetBasePath(context.FunctionAppDirectory)
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
             .AddEnvironmentVariables()
            .Build();

            SendGridClientOptions options = new SendGridClientOptions()
            {
                ApiKey = config["AzureWebJobsSendGridApiKey"]
            };

            var client = new SendGridClient(options);
            var from = new EmailAddress("azure@groupies.email", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("brettwebst@parse.groupies.email", "Brett Webster");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return new OkObjectResult(response);

        }
    }
}
