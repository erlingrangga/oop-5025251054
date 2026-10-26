
namespace Pertemuan07;

// Bekerja dengan KONTRAK (interface), bukan kelas konkret.
public static class Katalog
{
    public static int PinjamSemua(IEnumerable<IDapatDipinjam> daftar)
    {
        if (daftar == null)
            throw new ArgumentNullException(nameof(daftar));

        int jumlahBerhasil = 0;

        foreach (IDapatDipinjam item in daftar)
        {
            try
            {
                item.Pinjam();
                jumlahBerhasil++;
            }
            catch (InvalidOperationException)
            {
                // Item sedang dipinjam, jadi lewati.
            }
        }

        return jumlahBerhasil;
    }

    public static List<IDapatDipinjam> HanyaBisaDipinjam(IEnumerable<Item> daftar)
    {
        if (daftar == null)
            throw new ArgumentNullException(nameof(daftar));

        List<IDapatDipinjam> hasil = new();

        foreach (Item item in daftar)
        {
            if (item is IDapatDipinjam dapatDipinjam)
                hasil.Add(dapatDipinjam);
        }

        return hasil;
    }
}

// Dependency Injection: LayananPeminjaman TIDAK membuat pemberitahuannya
// sendiri -- ia menerimanya dari luar lewat konstruktor.
public class LayananPeminjaman
{
    private readonly INotifikasi _notifikasi;

    public LayananPeminjaman(INotifikasi notifikasi)
    {
        // TODO(Level 6): notifikasi null -> ArgumentNullException; selain itu
        //   simpan ke field private readonly `_notifikasi`.
        throw new NotImplementedException("Level 6 belum diimplementasikan");
    }

    public void Pinjamkan(Item item, string namaAnggota)
    {
        // TODO(Level 6): item null -> ArgumentNullException; item BUKAN
        //   IDapatDipinjam -> InvalidOperationException; selain itu panggil
        //   Pinjam() (kalau melempar, biarkan menjalar dan JANGAN kirim
        //   notifikasi), lalu kirim pesan "<namaAnggota> meminjam <Judul>" lewat
        //   INotifikasi.
        throw new NotImplementedException("Level 6 belum diimplementasikan");
    }
}
