using System;
using FunctionEnvioEmail.Dominio;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionEnvioEmail
{
    public static class FunctionEmail
    {
        //https://docs.microsoft.com/pt-br/azure/azure-functions/functions-bindings-timer?tabs=csharp
        //{second} {minute} {hour} {day} {month} {day-of-week}


        [FunctionName("FunctionEmail")]
        public static void Run([TimerTrigger("*/120 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"Ultima Execução da functionEmail: {DateTime.Now}");
            using (var filaEmail = new LeituraFilaEmail())
            {
                filaEmail.EnvioEmails();
            }
        }
    }
}
