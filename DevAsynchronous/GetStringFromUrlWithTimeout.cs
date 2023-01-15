namespace DevAsynchronous
{
    public class GetStringFromUrlWithTimeout
    {
        public async Task<string> GetWithTimeout()
        {
            var url = "https://run.mocky.io/v3/b8ef8741-bfa9-47d3-af4b-ed1a7c46a12a";
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            Task<string> downloadTask = GetContentFromUrl(new HttpClient(), url);
            Task timeoutTask = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);

            Task completedTask = await Task.WhenAny(downloadTask, timeoutTask);

            if (completedTask == timeoutTask)
            {
                return null;
            }

            return await downloadTask;
        }

        Task<string> GetContentFromUrl(HttpClient client, string url)
        {
            Task.Delay(TimeSpan.FromSeconds(1));
            return client.GetStringAsync(url);
        }
    }
}
