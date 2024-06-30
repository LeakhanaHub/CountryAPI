namespace CountryAPI.Model;

public class BaseApiResponse<T>
{
    public string Message { get; set; }
    
    public T Data { get; set; }
    
    public int ErrorCode { get; set; }
}
