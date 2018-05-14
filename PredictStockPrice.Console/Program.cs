// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Microsoft.AspNet.WebApi.Client

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CallRequestResponseService
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }

    class Program
    {
        const int range = 7 * 2 + 1;

        static void Main(string[] args)
        {
            var stringTable = GetStringTable(args);
            InvokeRequestResponseService(stringTable).Wait();
        }

        // コマンドライン引数から15日分の株価を取得
        static StringTable GetStringTable(string[] args)
        {
            var adjusteds = GetAdjusteds(args).ToList();
            var values = new string[range, 1];
            for (var index = 0; index < range; index++)
                values[index, 0] = adjusteds[index];
            return new StringTable { ColumnNames = new string[] { "Adjusted" }, Values = values };
        }

        // コマンドライン引数から15日分の株価を取得
        static IEnumerable<string> GetAdjusteds(string[] args)
            => Enumerable.Range(0, range).Select(index => GetAdjusted(index < args.Length ? args[index] : null));

        // 株価 (コマンドライン引数での指定がなかった場合はランダムな株価)
        static string GetAdjusted(string arg)
            => arg != null && double.TryParse(arg, out var value) ? arg : GetRandomAdjusted();

        static Random random = new Random();

        // ランダムな株価
        static string GetRandomAdjusted()
            => (random.NextDouble() * 2.0 - 1.0).ToString();

        static async Task InvokeRequestResponseService(StringTable stringTable)
        {
            using (var client = new HttpClient()) {
                var scoreRequest = new {
                    Inputs = new Dictionary<string, StringTable>() { { "input1", stringTable } },
                    GlobalParameters = new Dictionary<string, string>() {}
                };
                const string apiKey = "your api key"; // Replace this with the API key for the web service
                client.BaseAddress = new Uri("your api URI"); // Replace this with the URI for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                // WARNING: The 'await' statement below can result in a deadlock if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false) so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)
                var response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode) {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", result);
                }
                else {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }
    }
}