namespace Proyek;

public class LayananTagihan
{
    private IEnumerable<IBisaDitagih> _daftarTagihan;

    public LayananTagihan(IEnumerable<IBisaDitagih> daftarTagihan)
    {
        if (daftarTagihan == null)
            throw new ArgumentException("Daftar tagihan tidak boleh kosong.");

        _daftarTagihan = daftarTagihan;
    }

    public decimal HitungTotal()
    {
        decimal total = 0;

        foreach (IBisaDitagih tagihan in _daftarTagihan)
        {
            if (tagihan == null)
                throw new ArgumentException("Objek tagihan tidak boleh kosong.");

            total += tagihan.HitungTagihan();
        }

        return total;
    }
}
