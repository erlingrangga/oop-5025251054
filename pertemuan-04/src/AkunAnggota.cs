// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan04;

public class AkunAnggota
{
    public const int MaksPinjaman = 3;

    // TODO(Level 9): NomorAnggota harus get-only dan divalidasi di konstruktor.
    public string NomorAnggota { get; }

    // TODO(Level 9): Nama harus bisa diisi saat object initializer,
    // tetapi tidak bisa diubah setelahnya.
    public string Nama { get; init; }

    // TODO(Level 9): Denda hanya boleh diubah melalui TambahDenda
    // dan BayarDenda.
    public int Denda { get; private set; }

    // TODO(Level 10): setter JumlahPinjamanAktif harus private.
    public int JumlahPinjamanAktif { get; private set; }

    public AkunAnggota(string nomorAnggota, string nama)
    {
        // TODO(Level 9): nomorAnggota null/kosong/spasi -> ArgumentException.
        if (string.IsNullOrWhiteSpace(nomorAnggota))
        {
            throw new ArgumentException(
                "Nomor anggota tidak boleh kosong.",
                nameof(nomorAnggota));
        }

        NomorAnggota = nomorAnggota;
        Nama = nama;
    }

    public void TambahDenda(int jumlah)
    {
        // TODO(Level 9): jumlah <= 0 -> ArgumentOutOfRangeException.
        // Selain itu, tambahkan jumlah ke Denda.
        if (jumlah <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(jumlah));
        }

        Denda += jumlah;
    }

    public int BayarDenda(int jumlah)
    {
        // TODO(Level 9): jumlah <= 0 -> ArgumentOutOfRangeException.
        // Jika jumlah > Denda -> InvalidOperationException.
        // Jika valid, kurangi Denda dan kembalikan sisa Denda.
        if (jumlah <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(jumlah));
        }

        if (jumlah > Denda)
        {
            throw new InvalidOperationException(
                "Jumlah pembayaran melebihi denda.");
        }

        Denda -= jumlah;

        return Denda;
    }

    internal void CatatPinjam()
    {
        // TODO(Level 10): tambahkan satu jumlah pinjaman aktif.
        JumlahPinjamanAktif++;
    }

    internal void CatatKembali()
    {
        // TODO(Level 10): kurangi satu jumlah pinjaman aktif,
        // tetapi jangan sampai kurang dari 0.
        if (JumlahPinjamanAktif > 0)
        {
            JumlahPinjamanAktif--;
        }
    }
}
