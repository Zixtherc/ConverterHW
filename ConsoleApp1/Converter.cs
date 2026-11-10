class Converter
{
    private readonly decimal _usdRate;
    private readonly decimal _eurRate;

    public Converter(decimal usdRate, decimal eurRate)
    {
        _usdRate = usdRate;
        _eurRate = eurRate;
    }

    private decimal Rate(string currency) => currency == "USD" ? _usdRate : _eurRate;
    public decimal FromUah(decimal uah, string currency) => uah / Rate(currency);
    public decimal ToUah(decimal amount, string currency) => amount * Rate(currency);
}