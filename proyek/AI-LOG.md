# AI-LOG

Saya menggunakan ChatGPT sebagai bantuan saat mengerjakan proyek Klinik Mini, terutama untuk memahami kebutuhan soal, menyusun rancangan class, memeriksa kode C#, dan merapikan dokumentasi. Kode tetap perlu saya periksa dan jalankan agar sesuai dengan kebutuhan proyek.

## 1. Rancangan class Klinik Mini

- Prompt: Meminta bantuan memahami soal ETS PBO untuk domain Klinik Mini dan menentukan class yang dibutuhkan.
- Dipakai: Rancangan `Pasien`, `TenagaMedis`, `Dokter`, `Perawat`, `Apoteker`, `Kunjungan`, `Resep`, dan class pendukung.
- Diubah atau diperiksa: Rancangan dicocokkan dengan kebutuhan soal, terutama pewarisan tenaga medis, perhitungan tagihan melalui interface, dan pengecekan jadwal.

## 2. Enkapsulasi dan validasi data

- Prompt: Meminta bantuan menerapkan enkapsulasi, validasi input, dan koleksi yang tidak bisa diubah langsung dari luar class.
- Dipakai: Pola field `private`, properti untuk membaca data, validasi pada konstruktor atau method, serta koleksi `IReadOnlyList` dan `IReadOnlyDictionary`.
- Diubah atau diperiksa: Saya memeriksa kembali aturan validasi agar data seperti nama kosong, umur di luar batas, dan biaya yang tidak valid bisa ditolak.

## 3. Perhitungan tagihan dan polimorfisme

- Prompt: Meminta bantuan menerapkan abstract class, inheritance, overriding, dan interface pada proyek Klinik Mini.
- Dipakai: `TenagaMedis`, class turunannya, `IBisaDitagih`, `Kunjungan`, `Resep`, dan `LayananTagihan`.
- Diubah atau diperiksa: Implementasi diperiksa agar biaya jasa bisa dihitung sesuai jenis tenaga medis dan total tagihan dapat dihitung melalui interface.

## 4. Penanganan kesalahan dan pengujian program

- Prompt: Meminta bantuan memeriksa skenario jadwal bentrok, validasi obat, exception kustom, dan penggunaan `IDisposable`.
- Dipakai: `JadwalBentrokException`, `ObatTidakValidException`, `JadwalKlinik`, `PencatatKlinik`, serta contoh penanganan kesalahan di `Program.cs`.
- Diubah atau diperiksa: Program dijalankan untuk memeriksa apakah jadwal bentrok dan data obat yang tidak valid ditolak serta ditangani tanpa menghentikan demo secara tidak terkendali.

## 5. Dokumentasi proyek

- Prompt: Meminta bantuan melengkapi README, diagram kelas, dan dokumentasi proses sesuai soal ETS PBO.
- Dipakai: Penjelasan domain, cara menjalankan program, status kebutuhan, dan diagram kelas Mermaid di `README.md`.
- Diubah atau diperiksa: Penjelasan dibuat lebih sederhana dan diagram perlu dicocokkan dengan class serta method yang benar-benar ada di kode.
