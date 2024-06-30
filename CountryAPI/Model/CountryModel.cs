namespace CountryAPI.Model;

public class CountryModel
{
    public string Name { get; set; }
    public string Alpha2Code { get; set; }
    public string Capital { get; set; }
    public string CallingCodes { get; set; }
    public string FlagUrl { get; set; }
    public string[] Timezones { get; set; }
}

public class CountryArea
{
    public string Region { get; set; }
    public string Timezones { get; set; }
}

public class CountryInfoResponse
{
    public List<CountryModel> CountryInfos { get; set; }
}