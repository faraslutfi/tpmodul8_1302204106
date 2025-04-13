using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; } = "celcius";
    public int batas_hari_demam { get; set; } = 14;
    public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    public static CovidConfig LoadConfig(string path)
    {
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<CovidConfig>(jsonString);
        }
        return new CovidConfig(); // pakai default kalau file tidak ada
    }

    public void UbahSatuan()
    {
        if (satuan_suhu == "celcius")
            satuan_suhu = "fahrenheit";
        else
            satuan_suhu = "celcius";
    }
}