// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan04;

public class Perpustakaan
{
    // TODO(Level 7): gunakan field private untuk menyimpan daftar buku.
    // DaftarBuku harus read-only dari luar (tidak bisa Add/Remove melalui
    // properti tersebut).
    private readonly List<Buku> _daftarBuku = new();

    public IReadOnlyList<Buku> DaftarBuku => _daftarBuku;

    public int JumlahJudul => _daftarBuku.Count;

    public void Tambah(Buku buku)
    {
        // TODO(Level 7): null -> ArgumentNullException.
        // ISBN yang sama -> InvalidOperationException.
        if (buku is null)
        {
            throw new ArgumentNullException(nameof(buku));
        }

        if (_daftarBuku.Any(x => x.Isbn == buku.Isbn))
        {
            throw new InvalidOperationException(
                "Buku dengan ISBN yang sama sudah ada.");
        }

        _daftarBuku.Add(buku);
    }

    public Buku? Cari(string isbn)
    {
        // TODO(Level 7): kembalikan buku dengan ISBN yang sama persis,
        // atau null jika tidak ditemukan.
        return _daftarBuku.FirstOrDefault(x => x.Isbn == isbn);
    }

    public void PinjamBuku(AkunAnggota akun, string isbn)
    {
        // TODO(Level 10): implementasikan sesuai urutan pengecekan di SOAL.md.

        if (akun is null)
        {
            throw new ArgumentNullException(nameof(akun));
        }

        Buku? buku = Cari(isbn);

        if (buku is null)
        {
            throw new ArgumentException(
                "Buku tidak ditemukan.",
                nameof(isbn));
        }

        if (akun.Denda > 0)
        {
            throw new InvalidOperationException(
                "Anggota masih memiliki denda.");
        }

        if (akun.JumlahPinjamanAktif >= AkunAnggota.MaksPinjaman)
        {
            throw new InvalidOperationException(
                "Jumlah pinjaman sudah mencapai batas maksimum.");
        }

        buku.Pinjam();
        akun.CatatPinjam();
    }

    public void KembalikanBuku(AkunAnggota akun, string isbn)
    {
        // TODO(Level 10): implementasikan sesuai urutan pengecekan di SOAL.md.

        if (akun is null)
        {
            throw new ArgumentNullException(nameof(akun));
        }

        Buku? buku = Cari(isbn);

        if (buku is null)
        {
            throw new ArgumentException(
                "Buku tidak ditemukan.",
                nameof(isbn));
        }

        if (akun.JumlahPinjamanAktif == 0)
        {
            throw new InvalidOperationException(
                "Anggota tidak memiliki pinjaman aktif.");
        }

        buku.Kembalikan();
        akun.CatatKembali();
    }
}
