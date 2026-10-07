// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan06;

// SUDAH LENGKAP -- jangan diubah. Satu baris peminjaman yang terlambat.
public record Peminjaman(Item Item, int HariTerlambat);

// Kasir TIDAK perlu tahu jenis item apa pun: ia hanya memanggil
// item.HitungDenda(...) dan objek yang sebenarnya menentukan hasilnya.
public class Kasir
{
    public int TotalDenda(IEnumerable<Peminjaman> daftar)
    {
        // TODO(Level 6): null -> ArgumentNullException; jumlahkan
        //   p.Item.HitungDenda(p.HariTerlambat) untuk semua peminjaman. JANGAN
        //   memeriksa jenis item (tidak boleh ada if/is/switch atas tipe) --
        //   biarkan polimorfisme bekerja.
        if (daftar is null)
            throw new ArgumentNullException(nameof(daftar));

        return daftar.Sum(p => p.Item.HitungDenda(p.HariTerlambat));
    }

    public Item? ItemDenganDendaTertinggi(IEnumerable<Peminjaman> daftar)
    {
        // TODO(Level 6): null -> ArgumentNullException; kembalikan Item dengan
        //   denda TERTINGGI (kalau seri, ambil yang pertama muncul); daftar
        //   kosong -> null.
        if (daftar is null)
            throw new ArgumentNullException(nameof(daftar));

        return daftar
            .Select(p => new
            {
                p.Item,
                Denda = p.Item.HitungDenda(p.HariTerlambat)
            })
            .OrderByDescending(x => x.Denda)
            .Select(x => x.Item)
            .FirstOrDefault();
    }
}
