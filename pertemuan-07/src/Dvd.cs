
public class Dvd : Item, IDapatDipinjam
{
    public int DurasiMenit { get; }

    private readonly StatusPinjam _status = new();

    public Dvd(string judul, string penulis, int durasiMenit)
        : base(judul, penulis)
    {
        if (durasiMenit <= 0)
            throw new ArgumentException("Durasi harus lebih dari 0.");

        DurasiMenit = durasiMenit;
    }

    public override int HitungDenda(int hariTerlambat)
    {
        if (hariTerlambat <= 0)
            return 0;

        return Math.Min(hariTerlambat * 5000, 50000);
    }

    public override int MasaPinjamHari => 2;

    public bool Tersedia => !_status.Dipinjam;

    public void Pinjam()
    {
        _status.Tandai();
    }

    public void Kembalikan()
    {
        _status.Lepas();
    }

    // TODO Level 10: Tambahkan properti Catatan.
    protected override string Catatan()
    {
        return "Periksa kondisi disk";
    }
}
