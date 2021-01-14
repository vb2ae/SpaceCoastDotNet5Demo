using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkingDemo
{
    class Program
    {
        private static readonly HttpClient _client = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            try
            {
                // Pass in the token.
                using var response = await _client.GetAsync("https://localhost:5001/Time?seconds=14", cts.Token);
            }
            // If the token has been canceled, it is not a timeout.
            catch (TaskCanceledException ex) when (cts.IsCancellationRequested)
            {
                // Handle cancellation.
                Console.WriteLine("Canceled: " + ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // Handle timeout.
                Console.WriteLine("Timed out: " + ex.Message);
            }
        }
    }
}
