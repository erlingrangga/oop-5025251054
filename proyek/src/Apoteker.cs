namespace Proyek;

public class Apoteker : TenagaMedis
{
    private decimal _tarifJasa;

    public decimal TarifJasa => _tarifJasa;

    public Apoteker(string nomorPegawai, string nama, decimal tarifJasa)
        : base(nomorPegawai, nama)
    {
        if (tarifJasa <= 0)
            throw new ArgumentException("Tarif jasa apoteker harus lebih dari nol.");

        _tarifJasa = tarifJasa;
    }

    public override decimal HitungJasa()
    {
        return _tarifJasa;
    }

    public override string AmbilInformasi()
    {
        return $"Apoteker {Nama}";
    }
}
