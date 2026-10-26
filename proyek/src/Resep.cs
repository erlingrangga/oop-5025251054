namespace Proyek;

public class Resep : IBisaDitagih
{
    private Pasien _pasien;
    private Apoteker _apoteker;
    private Dictionary<string, decimal> _daftarObat;

    public Pasien Pasien => _pasien;
    public Apoteker Apoteker => _apoteker;
    public IReadOnlyDictionary<string, decimal> DaftarObat => _daftarObat;

    public Resep(Pasien pasien, Apoteker apoteker)
    {
        if (pasien == null)
            throw new ArgumentException("Pasien tidak boleh kosong.");

        if (apoteker == null)
            throw new ArgumentException("Apoteker tidak boleh kosong.");

        _pasien = pasien;
        _apoteker = apoteker;
        _daftarObat = new Dictionary<string, decimal>();
    }

    public void TambahObat(string namaObat, decimal harga)
    {
        if (string.IsNullOrWhiteSpace(namaObat))
            throw new ArgumentException("Nama obat tidak boleh kosong.");

        if (harga <= 0)
            throw new ArgumentException("Harga obat harus lebih dari nol.");

        if (_daftarObat.ContainsKey(namaObat))
            throw new ArgumentException("Obat tersebut sudah terdaftar.");

        _daftarObat.Add(namaObat, harga);
    }

    public decimal HitungTagihan()
    {
        decimal total = _apoteker.HitungJasa();

        foreach (KeyValuePair<string, decimal> obat in _daftarObat)
        {
            total += obat.Value;
        }

        return total;
    }

    public override string ToString()
    {
        return $"Resep untuk {Pasien.Nama}, dilayani oleh {_apoteker.Nama}, " +
               $"total Rp{HitungTagihan():N0}";
    }
}
