using System;
using System.Net.Http;
using FunctionMessageStart.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionMessageStart
{
    public static class FunctionMessageStart
    {
        [FunctionName("FunctionMessageStart")]
        public static void Run([ServiceBusTrigger("geolocation", "Start", Connection = "RootManageSharedAccessKey")] Address mySbMsg, ILogger log)
        {
            try
            {
                var url = System.Environment.GetEnvironmentVariable("UrlApi", EnvironmentVariableTarget.Process);
                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(mySbMsg);
                var contentData = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync($"{url}/Geocoding/geocodificar", contentData).Result;
                var _stringSerialized = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                log.LogInformation($"Se ejecuto el msj correctamente");
            }
            catch (Exception e)
            {
                log.LogInformation($"Fallo el msj ");
                log.LogInformation(e.Message);
            }
        }
    }
}
