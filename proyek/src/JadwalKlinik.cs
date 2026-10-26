namespace Proyek;

public class JadwalKlinik
{
    private List<Kunjungan> _daftarKunjungan;

    public IReadOnlyList<Kunjungan> DaftarKunjungan =>
        _daftarKunjungan.AsReadOnly();

    public JadwalKlinik()
    {
        _daftarKunjungan = new List<Kunjungan>();
    }

    public void DaftarkanKunjungan(Kunjungan kunjungan)
    {
        if (kunjungan == null)
            throw new ArgumentException("Kunjungan tidak boleh kosong.");

        DateTime waktuMulaiBaru = kunjungan.Waktu;
        DateTime waktuSelesaiBaru =
            waktuMulaiBaru.AddMinutes(kunjungan.DurasiMenit);

        foreach (Kunjungan jadwalLama in _daftarKunjungan)
        {
            bool tenagaMedisSama =
                jadwalLama.TenagaMedis.NomorPegawai ==
                kunjungan.TenagaMedis.NomorPegawai;

            DateTime waktuMulaiLama = jadwalLama.Waktu;
            DateTime waktuSelesaiLama =
                waktuMulaiLama.AddMinutes(jadwalLama.DurasiMenit);

            bool waktuBertabrakan =
                waktuMulaiBaru < waktuSelesaiLama &&
                waktuSelesaiBaru > waktuMulaiLama;

            if (tenagaMedisSama && waktuBertabrakan)
            {
                throw new JadwalBentrokException(
                    $"Jadwal {kunjungan.TenagaMedis.Nama} bentrok " +
                    $"dengan kunjungan pada {waktuMulaiLama:dd/MM/yyyy HH:mm}.");
            }
        }

        _daftarKunjungan.Add(kunjungan);
    }
}
