namespace Proyek;

public class Perawat : TenagaMedis
{
    private decimal _tarifJasa;

    public decimal TarifJasa => _tarifJasa;

    public Perawat(string nomorPegawai, string nama, decimal tarifJasa)
        : base(nomorPegawai, nama)
    {
        if (tarifJasa <= 0)
            throw new ArgumentException("Tarif jasa perawat harus lebih dari nol.");

        _tarifJasa = tarifJasa;
    }

    public override decimal HitungJasa()
    {
        return _tarifJasa;
    }

    public override string AmbilInformasi()
    {
        return $"Perawat {Nama}";
    }
}
