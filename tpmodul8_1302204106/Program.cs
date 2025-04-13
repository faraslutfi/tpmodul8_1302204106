using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig("covid_config.json");

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool isSuhuValid = false;

        if (config.satuan_suhu == "celcius")
        {
            isSuhuValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            isSuhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        if (isSuhuValid && hari < config.batas_hari_demam)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // Testing method UbahSatuan
        Console.WriteLine("\nMengubah satuan suhu...");
        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu sekarang: {config.satuan_suhu}");

        Console.ReadLine(); // supaya console ga ketutup
    }
}