namespace Proyek;

public class Pasien
{
    private string _nomorRekamMedis;
    private string _nama;
    private int _umur;

    public string NomorRekamMedis => _nomorRekamMedis;
    public string Nama => _nama;
    public int Umur => _umur;

    public Pasien(string nomorRekamMedis, string nama, int umur)
    {
        if (string.IsNullOrWhiteSpace(nomorRekamMedis))
            throw new ArgumentException("Nomor rekam medis tidak boleh kosong.");

        if (string.IsNullOrWhiteSpace(nama))
            throw new ArgumentException("Nama pasien tidak boleh kosong.");

        if (umur < 0 || umur > 120)
            throw new ArgumentException("Umur pasien harus antara 0 sampai 120.");

        _nomorRekamMedis = nomorRekamMedis;
        _nama = nama;
        _umur = umur;
    }

    public override string ToString()
    {
        return $"{Nama} (RM: {NomorRekamMedis}, umur {Umur} tahun)";
    }
}
