using System.Net.Http.Headers;
using CountryAPI.Model;

using Newtonsoft.Json.Linq;

namespace CountryAPI.Services;

public class CountryService
{
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://restcountries.com/v3.1/");
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<CountryModel> GetCountryByNameAsync(string name)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"name/{name}?fullText=true");
        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var json = JArray.Parse(responseData)[0];

            return new CountryModel
            {
                Name = json["name"]["common"].ToString(),
                Alpha2Code = json["cca2"].ToString(),
                Capital = json["capital"]?.FirstOrDefault()?.ToString(),
                CallingCodes = json["idd"]["root"]?.ToString() + json["idd"]["suffixes"]?.FirstOrDefault()?.ToString(),
                FlagUrl = json["flags"]["png"].ToString(),
                Timezones = json["timezones"].ToObject<string[]>()
            };
        }
        else
        {
            throw new HttpRequestException($"{(int)response.StatusCode} ({response.ReasonPhrase})");
        }
    }
    public async Task<List<CountryModel>> GetCountryByAreaAsync(CountryArea param)
    {
        HttpResponseMessage response = await _httpClient.GetAsync("all");
        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadAsStringAsync();
            var countriesJson = JArray.Parse(responseData);
            var filteredCountriesJson = countriesJson
                .Where(json =>
                {
                    bool matchesRegion = string.IsNullOrEmpty(param.Region) || json["region"]?.ToString().Equals(param.Region, StringComparison.OrdinalIgnoreCase) == true;
                    bool matchesTimezone = string.IsNullOrEmpty(param.Timezones) || (json["timezones"]?.ToObject<string[]>()?.Any(tz => tz.Equals(param.Timezones, StringComparison.OrdinalIgnoreCase)) == true);
                    return matchesRegion && matchesTimezone;
                });
            var countries = filteredCountriesJson.Select(json => new CountryModel
            {
                Name = json["name"]["common"].ToString(),
                Alpha2Code = json["cca2"].ToString(),
                Capital = json["capital"]?.FirstOrDefault()?.ToString(),
                CallingCodes = json["idd"]["root"]?.ToString() + json["idd"]["suffixes"]?.FirstOrDefault()?.ToString(),
                FlagUrl = json["flags"]["png"].ToString(),
                Timezones = json["timezones"]?.ToObject<string[]>()
            }).ToList();

            return countries;
        }
        else
        {
            throw new HttpRequestException($"{(int)response.StatusCode} ({response.ReasonPhrase})");
        }
    }
}