// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan04;

public class Buku
{
    // TODO(Level 1): field PUBLIK di bawah ini melanggar enkapsulasi (siapa pun
    //   bisa mengubahnya sembarangan). Jadikan field PRIVATE (awali nama dengan
    //   _) lalu ekspos lewat properti read-only: public get, tanpa setter
    //   publik. Nama properti tetap Isbn, Judul, StokTotal, StokTersedia.
    private string _isbn = "";
    private string _judul = "";
    private int _stokTotal;
    private int _stokTersedia;

    public string Isbn => _isbn;
    public string Judul => _judul;
    public int StokTotal => _stokTotal;
    public int StokTersedia => _stokTersedia;

    // TODO(Level 8): properti di bawah ini menerima nilai apa saja. Beri nilai
    //   awal 7 dan tambahkan logika validasi di accessor set (perlu field
    //   pendukung): nilai harus 1..30, di luar itu lempar
    //   ArgumentOutOfRangeException dan JANGAN mengubah nilai lama.
    private int _batasHariPinjam = 7;

    public int BatasHariPinjam
    {
        get => _batasHariPinjam;
        set
        {
            if (value < 1 || value > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            _batasHariPinjam = value;
        }
    }

    // TODO(Level 2): validasi di AWAL konstruktor -- judul null/kosong/spasi
    //   saja atau stokTotal negatif -> lempar ArgumentException
    //   (ArgumentOutOfRangeException juga boleh); jangan ada state yang berubah
    //   kalau ditolak.
    // TODO(Level 6): validasi & normalisasi ISBN -- buang tanda '-' dan spasi;
    //   hasilnya harus tepat 13 digit angka dengan digit cek ISBN-13 yang benar;
    //   kalau tidak, lempar ArgumentException. Isbn menyimpan versi TANPA '-'.
    public Buku(string isbn, string judul, int stokTotal)
    {
        if (string.IsNullOrWhiteSpace(judul))
        {
            throw new ArgumentException("Judul tidak boleh kosong.");
        }

        if (stokTotal < 0)
        {
            throw new ArgumentException("Stok total tidak boleh negatif.");
        }

        string isbnbersih = isbn?.Replace("-", "").Replace(" ", "") ?? "";

        if (isbnbersih.Length != 13 || !isbnbersih.All(char.IsDigit))
        {
            throw new ArgumentException("ISBN harus terdiri dari 13 digit.");
        }

        int jumlah = 0;

        for (int i = 0; i < 12; i++)
        {
            int digit = isbnbersih[i] - '0';

            if (i % 2 == 0)
            {
                jumlah += digit;
            }
            else
            {
                jumlah += digit * 3;
            }
        }

        int digitcek = (10 - (jumlah % 10)) % 10;

        if (digitcek != isbnbersih[12] - '0')
        {
            throw new ArgumentException("ISBN-13 tidak valid.");
        }

        // TODO(Level 1): isi Isbn, Judul, StokTotal dari parameter; StokTersedia
        //   awal = stokTotal.
        _isbn = isbnbersih;
        _judul = judul;
        _stokTotal = stokTotal;
        _stokTersedia = stokTotal;
    }

    public void Pinjam()
    {
        // TODO(Level 3): kurangi StokTersedia satu. Kalau stok sudah 0, lempar
        //   InvalidOperationException dan biarkan stok tetap.
        if (_stokTersedia == 0)
        {
            throw new InvalidOperationException("Stok buku sudah habis.");
        }

        _stokTersedia--;
    }

    public void Kembalikan()
    {
        // TODO(Level 4): tambah StokTersedia satu. Kalau stok sudah sama dengan
        //   StokTotal (tidak ada yang sedang dipinjam), lempar
        //   InvalidOperationException dan biarkan stok tetap.
        if (_stokTersedia == _stokTotal)
        {
            throw new InvalidOperationException("Semua buku sudah tersedia.");
        }

        _stokTersedia++;
    }

    // Level 5: properti TERHITUNG -- tanpa field pendukung, tanpa setter.
    public double PersentaseTersedia
    {
        get
        {
            // TODO(Level 5): kembalikan StokTersedia / StokTotal * 100 (double).
            //   Kalau StokTotal = 0 kembalikan 0 (bukan NaN).
            if (_stokTotal == 0)
            {
                return 0;
            }

            return (double)_stokTersedia / _stokTotal * 100;
        }
    }

    public string Status
    {
        get
        {
            // TODO(Level 5): kembalikan "Tersedia" kalau StokTersedia > 0,
            //   selain itu "Habis".
            if (_stokTersedia > 0)
            {
                return "Tersedia";
            }

            return "Habis";
        }
    }
}
