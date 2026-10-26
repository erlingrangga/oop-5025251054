
public class Buku : Item, IDapatDipinjam, IDapatDiperpanjang, IDapatDicetak
{
    private readonly StatusPinjam _status = new();

    public int JumlahPerpanjangan { get; private set; } = 0;

    public Buku(string judul, string penulis)
        : base(judul, penulis)
    {
    }

    public override int HitungDenda(int hariTerlambat)
    {
        if (hariTerlambat <= 0)
            return 0;

        return hariTerlambat * 2000;
    }

    public override int MasaPinjamHari => 14;

    public bool Tersedia => !_status.Dipinjam;

    public void Pinjam()
    {
        _status.Tandai();
    }

    public void Kembalikan()
    {
        _status.Lepas();
        JumlahPerpanjangan = 0;
    }

    public bool Perpanjang()
    {
        if (Tersedia)
            throw new InvalidOperationException(
                "Buku harus dipinjam terlebih dahulu.");

        if (JumlahPerpanjangan >= 2)
            return false;

        JumlahPerpanjangan++;
        return true;
    }

    // TODO Level 8: Implementasikan Cetak secara eksplisit.
    string IDapatDicetak.Cetak()
    {
        return $"Buku: {Judul} oleh {Penulis}";
    }
}
