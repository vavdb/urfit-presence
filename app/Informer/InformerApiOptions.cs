namespace urfit_presence;

public class InformerApiOptions
{
    public const string SectionName = "InformerApi";
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string SecurityCode { get; set; } = string.Empty;
}
