namespace Thales.DotNet.Tech.Infrastructure.Entities;

public class ResponseEmployee
{
    public string status { get; set; }

    public Employee[] data { get; set; }
    public string message { get; set; }
}
