using MyExtensionsApp.DataContracts;

namespace MyExtensionsApp.Services;

[Headers("Content-Type: application/json")]
public interface IApiClient
{
	[Get("/api/weatherforecast")]
	Task<ApiResponse<WeatherForecast>> GetWeather(CancellationToken cancellationToken = default);
}
