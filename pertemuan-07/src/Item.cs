
namespace Pertemuan07;

// Level 1: Item dijadikan abstract class karena tidak ada "item umum"
// yang bisa dibuat langsung.
// Level 9: Item mengimplementasikan IComparable<Item> untuk mengurutkan
// item berdasarkan Judul.
public abstract class Item : IComparable<Item>
{
    public string Judul { get; }

    // SUDAH LENGKAP -- jangan diubah.
    protected Item(string judul)
    {
        if (string.IsNullOrWhiteSpace(judul))
            throw new ArgumentException("Judul tidak boleh kosong.", nameof(judul));
        Judul = judul;
    }

    // Level 1: setiap jenis item wajib menentukan dendanya sendiri.
    public abstract int HitungDenda(int hariTerlambat);

    // Level 2: setiap jenis item menentukan masa pinjamnya sendiri.
    public abstract int MasaPinjamHari { get; }

    // Method KONKRET di kelas abstrak: logika bersama yang memakai anggota abstrak.
    public DateOnly HitungTanggalKembali(DateOnly tanggalPinjam)
    {
        // Level 2: tanggal kembali dihitung berdasarkan masa pinjam item.
        return tanggalPinjam.AddDays(MasaPinjamHari);
    }

    // Hook: kelas turunan BOLEH menimpa, tapi tidak wajib. SUDAH LENGKAP.
    protected virtual string Catatan() => "";

    // Template Method: urutan langkahnya dikunci di sini (BUKAN virtual),
    // bagian yang bervariasi diserahkan ke HitungDenda() dan Catatan().
    public string BuatStruk(int hariTerlambat)
    {
        // Level 10: hari terlambat negatif dianggap 0.
        if (hariTerlambat < 0)
            hariTerlambat = 0;

        string struk = $"STRUK PENGEMBALIAN\nJudul: {Judul}\nTerlambat: {hariTerlambat} hari\nDenda: Rp{HitungDenda(hariTerlambat)}";

        string catatan = Catatan();

        // Tambahkan catatan jika kelas turunan memilikinya.
        if (!string.IsNullOrEmpty(catatan))
            struk += $"\nCatatan: {catatan}";

        return struk;
    }

    public int CompareTo(Item? other)
    {
        // Level 9: null dianggap lebih kecil daripada item ini.
        if (other is null)
            return 1;

        // Judul dibandingkan tanpa membedakan huruf besar dan kecil.
        return string.Compare(
            Judul,
            other.Judul,
            StringComparison.OrdinalIgnoreCase
        );
    }
}
