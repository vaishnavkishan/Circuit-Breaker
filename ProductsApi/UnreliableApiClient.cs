namespace ProductsApi;

public interface IUnreliableApiClient
{
    Task CallUnreliableApi();
}

public class UnreliableApiClient: IUnreliableApiClient
{
    private readonly HttpClient _httpClient;

    public UnreliableApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task CallUnreliableApi()
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "WeatherForecast");
            var response= await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
                await Task.Delay(TimeSpan.FromSeconds(2));
        }
        catch (HttpRequestException e)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            throw;
        }
    }
}