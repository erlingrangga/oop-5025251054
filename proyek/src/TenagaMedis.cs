namespace Proyek;

public abstract class TenagaMedis
{
    private string _nomorPegawai;
    private string _nama;

    public string NomorPegawai => _nomorPegawai;
    public string Nama => _nama;

    public TenagaMedis(string nomorPegawai, string nama)
    {
        if (string.IsNullOrWhiteSpace(nomorPegawai))
            throw new ArgumentException("Nomor pegawai tidak boleh kosong.");

        if (string.IsNullOrWhiteSpace(nama))
            throw new ArgumentException("Nama tenaga medis tidak boleh kosong.");

        _nomorPegawai = nomorPegawai;
        _nama = nama;
    }

    public abstract decimal HitungJasa();

    public virtual string AmbilInformasi()
    {
        return $"{Nama} ({NomorPegawai})";
    }

    public override string ToString()
    {
        return $"{AmbilInformasi()} - Jasa Rp{HitungJasa():N0}";
    }
}
