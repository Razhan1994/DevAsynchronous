using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevAsynchronous
{
    public static class UseWhenAnyToRun
    {
        public static async Task<string> GetUrlContent()
        {
            var firstUrl = "https://run.mocky.io/v3/c59b2523-de9f-48ec-88d0-0fa7c9440157";
            var secondUrl = "https://run.mocky.io/v3/48d80a8d-9971-4478-a0c4-99257779c29c";

            var client = new HttpClient();
            
            var firstTask = CallFirstUrl(firstUrl, client);
            var secondTask = CallSecondUrl(secondUrl, client);
            var thirdTask = CallException();
            var fourthTask = CallSampleMethod();

            var finalTask = await Task.WhenAny(firstTask, secondTask, thirdTask);

            return await finalTask.Result.Content.ReadAsStringAsync();
        }

        static async Task<HttpResponseMessage> CallFirstUrl(string firstUrl, HttpClient client)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            return await client.GetAsync(firstUrl);
            
        }

        static async Task<HttpResponseMessage> CallSecondUrl(string secondUrl, HttpClient client)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return await client.GetAsync(secondUrl);
        }

        static async Task<HttpResponseMessage> CallException()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            throw new InvalidOperationException();
        }

        static async Task<HttpResponseMessage> CallSampleMethod()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("call from sample method");

            return response;
        }
    }
}
