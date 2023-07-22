namespace EnigmaShopAPI.Models.WebResponse;

public class WebResponse
{
    public int  Code { get; set; }
    public string Message { get; set; }
    public dynamic Data { get; set; }
}