namespace Proyek;

public class Kunjungan : IBisaDitagih
{
    private Pasien _pasien;
    private TenagaMedis _tenagaMedis;
    private DateTime _waktu;
    private int _durasiMenit;
    private List<Tindakan> _daftarTindakan;

    public Pasien Pasien => _pasien;
    public TenagaMedis TenagaMedis => _tenagaMedis;
    public DateTime Waktu => _waktu;
    public int DurasiMenit => _durasiMenit;
    public IReadOnlyList<Tindakan> DaftarTindakan => _daftarTindakan.AsReadOnly();

    public Kunjungan(
        Pasien pasien,
        TenagaMedis tenagaMedis,
        DateTime waktu,
        int durasiMenit)
    {
        if (pasien == null)
            throw new ArgumentException("Pasien tidak boleh kosong.");

        if (tenagaMedis == null)
            throw new ArgumentException("Tenaga medis tidak boleh kosong.");

        if (durasiMenit <= 0)
            throw new ArgumentException("Durasi kunjungan harus lebih dari nol.");

        _pasien = pasien;
        _tenagaMedis = tenagaMedis;
        _waktu = waktu;
        _durasiMenit = durasiMenit;
        _daftarTindakan = new List<Tindakan>();
    }

    public void TambahTindakan(Tindakan tindakan)
    {
        if (tindakan == null)
            throw new ArgumentException("Tindakan tidak boleh kosong.");

        _daftarTindakan.Add(tindakan);
    }

    public decimal HitungTagihan()
    {
        decimal total = _tenagaMedis.HitungJasa();

        foreach (Tindakan tindakan in _daftarTindakan)
        {
            total += tindakan.Biaya;
        }

        return total;
    }

    public override string ToString()
    {
        return $"Kunjungan {Pasien.Nama} bersama {_tenagaMedis.AmbilInformasi()} " +
               $"pada {_waktu:dd/MM/yyyy HH:mm}";
    }
}
