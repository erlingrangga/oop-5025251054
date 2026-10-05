// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan05;

public sealed class Asisten : Mahasiswa
{
    public string MataKuliah { get; }

    public Asisten(
        string id,
        string nama,
        Alamat alamat,
        string nrp,
        string prodi,
        string mataKuliah)
        : base(id, nama, alamat, nrp, prodi)
    {
        if (string.IsNullOrWhiteSpace(mataKuliah))
        {
            throw new ArgumentException(
                "Mata kuliah tidak boleh kosong.",
                nameof(mataKuliah));
        }

        MataKuliah = mataKuliah;
        BatasPinjam = 5;
    }

    public string InfoAsisten()
    {
        return $"{InfoLengkap()} | Asisten: {MataKuliah}";
    }
}
