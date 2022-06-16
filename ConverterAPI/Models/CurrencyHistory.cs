namespace CurrencyConverter.Models
{
    public class CurrencyHistory
    {
        public string ID { get; set; }
        public string CurrencyId { get; set; }
        public string Date { get; set; }
        public double ExchangeRate { get; set; }
    }
}
