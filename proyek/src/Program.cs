 // Titik masuk aplikasi. Ganti isi berkas ini dengan demo (menu atau skenario berurutan)
 // yang memperlihatkan semua aturan khas domain kalian, termasuk skenario gagal yang
 // ditangani exception. Kelas-kelas domain ditulis di berkas terpisah.
Console.WriteLine("Proyek ETS PBO - tulis demo di sini.");

using Proyek;

PencatatKlinik? pencatat = null;

try
{
    pencatat = new PencatatKlinik();
    pencatat.Catat("Sistem Klinik Mini dimulai.");

    Pasien pasien = new Pasien("RM001", "Budi", 20);

    Dokter dokter = new Dokter("D001", "Dr. Andi", 150000m);
    Perawat perawat = new Perawat("P001", "Siti", 50000m);
    Apoteker apoteker = new Apoteker("A001", "Rina", 25000m);

    Console.WriteLine("\n=== DAFTAR TENAGA MEDIS ===");

    List<TenagaMedis> tenagaMedis = new List<TenagaMedis>
    {
        dokter,
        perawat,
        apoteker
    };

    foreach (TenagaMedis tenaga in tenagaMedis)
    {
        Console.WriteLine(tenaga);
    }

    Console.WriteLine("\n=== KUNJUNGAN PASIEN ===");
    Console.WriteLine(pasien);

    DateTime waktuKunjungan = new DateTime(2026, 10, 27, 9, 0, 0);

    Kunjungan kunjungan = new Kunjungan(
        pasien, dokter, waktuKunjungan, 30);

    kunjungan.TambahTindakan(
        new Tindakan("Pemeriksaan umum", 50000m));

    kunjungan.TambahTindakan(
        new Tindakan("Tes laboratorium", 75000m));

    JadwalKlinik jadwal = new JadwalKlinik();
    jadwal.DaftarkanKunjungan(kunjungan);

    Console.WriteLine(kunjungan);
    Console.WriteLine($"Tagihan kunjungan: Rp{kunjungan.HitungTagihan():N0}");

    Console.WriteLine("\n=== RESEP OBAT ===");

    Resep resep = new Resep(pasien, apoteker);
    resep.TambahObat("Paracetamol", 15000m);
    resep.TambahObat("Vitamin", 20000m);

    Console.WriteLine(resep);
    Console.WriteLine($"Tagihan resep: Rp{resep.HitungTagihan():N0}");

    Console.WriteLine("\n=== TOTAL TAGIHAN ===");

    LayananTagihan layananTagihan = new LayananTagihan(
        new List<IBisaDitagih> { kunjungan, resep });

    Console.WriteLine($"Total: Rp{layananTagihan.HitungTotal():N0}");

    Console.WriteLine("\n=== UJI JADWAL BENTROK ===");

    try
    {
        Kunjungan bentrok = new Kunjungan(
            new Pasien("RM002", "Ani", 25),
            dokter,
            waktuKunjungan.AddMinutes(15),
            30);

        jadwal.DaftarkanKunjungan(bentrok);
    }
    catch (JadwalBentrokException ex)
    {
        Console.WriteLine($"Jadwal ditolak: {ex.Message}");
        pencatat.Catat($"Jadwal bentrok ditangani: {ex.Message}");
    }

    Console.WriteLine("\n=== UJI VALIDASI ===");

    try
    {
        new Pasien("", "Pasien Tidak Valid", 20);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Data ditolak: {ex.Message}");
    }

    pencatat.Catat("Demo Klinik Mini selesai.");
}
catch (Exception ex)
{
    Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
}
finally
{
    pencatat?.Dispose();
    Console.WriteLine("\nSistem Klinik Mini selesai.");
}
