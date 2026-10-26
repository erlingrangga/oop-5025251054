namespace Proyek;

public class Tindakan
{
    private string _nama;
    private decimal _biaya;

    public string Nama => _nama;
    public decimal Biaya => _biaya;

    public Tindakan(string nama, decimal biaya)
    {
        if (string.IsNullOrWhiteSpace(nama))
            throw new ArgumentException("Nama tindakan tidak boleh kosong.");

        if (biaya < 0)
            throw new ArgumentException("Biaya tindakan tidak boleh negatif.");

        _nama = nama;
        _biaya = biaya;
    }

    public Tindakan(string nama) : this(nama, 0m)
    {
    }

    public override string ToString()
    {
        return $"{Nama} - Rp{Biaya:N0}";
    }
}
