
namespace Proyek;

public class PencatatKlinik : IDisposable
{
    private StreamWriter _penulis;
    private bool _sudahDitutup;

    public PencatatKlinik()
    {
        string lokasiFile = Path.Combine(
            AppContext.BaseDirectory,
            "aktivitas-klinik.txt");

        _penulis = new StreamWriter(lokasiFile, append: true);
        _sudahDitutup = false;
    }

    public void Catat(string pesan)
    {
        if (_sudahDitutup)
            throw new ObjectDisposedException(nameof(PencatatKlinik));

        if (string.IsNullOrWhiteSpace(pesan))
            throw new ArgumentException("Pesan catatan tidak boleh kosong.");

        string waktu = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        _penulis.WriteLine($"[{waktu}] {pesan}");
        _penulis.Flush();
    }

    public void Dispose()
    {
        if (!_sudahDitutup)
        {
            _penulis.Dispose();
            _sudahDitutup = true;
        }
    }
}
