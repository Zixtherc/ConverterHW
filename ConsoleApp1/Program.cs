class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        decimal usd = ReadDecimal("Курс USD до грн: ");
        decimal eur = ReadDecimal("Курс EUR до грн: ");
        var converter = new Converter(usd, eur);

        Console.Write("Напрямок (1 - з грн у валюту, 2 - з валюти в грн): ");
        bool fromUah = Console.ReadLine() == "1";

        string currency;
        while (true)
        {
            Console.Write("Валюта (USD/EUR): ");
            currency = (Console.ReadLine() ?? "").Trim().ToUpper();
            if (currency == "USD" || currency == "EUR") break;
            Console.WriteLine("Введіть USD або EUR");
        }

        decimal sum = ReadDecimal("Сума: ");

        if (fromUah)
            Console.WriteLine($"{sum} UAH = {converter.FromUah(sum, currency):F2} {currency}");
        else
            Console.WriteLine($"{sum} {currency} = {converter.ToUah(sum, currency):F2} UAH");
    }

    static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? "").Replace(',', '.');
            if (decimal.TryParse(input, System.Globalization.NumberStyles.Number,
                    System.Globalization.CultureInfo.InvariantCulture, out decimal value) && value > 0)
                return value;
            Console.WriteLine("Введіть додатне число");
        }
    }
}