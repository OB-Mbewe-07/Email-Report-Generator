namespace Email_Generator.Models;

public record SalesData(decimal Revenue, string TopProduct, double ChurnRate)
{
    public string FormatRevenue() => Revenue.ToString("C");
    public string FormatTopProduct() => TopProduct;
    public string FormatChurnRate() => ChurnRate.ToString("P2");
}