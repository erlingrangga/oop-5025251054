
# PROSES

Berkas ini menjadi bahan utama ujian lisan. Tulis dengan kata-kata sendiri.

## 1. Domain dan masalahnya

Proyek yang saya buat adalah Klinik Mini, yaitu aplikasi sederhana untuk membantu pencatatan di klinik. Aplikasi ini digunakan untuk mencatat data pasien, tenaga medis, kunjungan, dan resep obat, sekaligus menghitung tagihan. Aplikasi juga memeriksa jadwal tenaga medis agar tidak bentrok dan memastikan data obat yang dimasukkan sesuai aturan.

## 2. Rancangan kelas

Saya membuat class `Pasien` untuk menyimpan data pasien, seperti nama, nomor rekam medis, dan umur.

Untuk tenaga medis, saya menggunakan abstract class `TenagaMedis` yang memiliki tiga class turunan, yaitu `Dokter`, `Perawat`, dan `Apoteker`. Ketiganya memiliki perhitungan jasa masing-masing, tetapi tetap menggunakan dasar class yang sama.

Class `Kunjungan` menghubungkan pasien, tenaga medis, waktu kunjungan, durasi, dan daftar tindakan. Sementara itu, class `Resep` menghubungkan pasien dengan apoteker dan daftar obat.

Saya juga membuat interface `IBisaDitagih` yang digunakan oleh `Kunjungan` dan `Resep`, karena keduanya sama-sama memiliki tagihan. Class `LayananTagihan` menerima daftar objek yang bisa ditagih melalui konstruktor dan menghitung totalnya.

Selain itu, ada class `JadwalKlinik` untuk memeriksa jadwal yang bentrok. `JadwalBentrokException` digunakan untuk menangani bentroknya jadwal, sedangkan `ObatTidakValidException` digunakan saat data obat tidak sesuai. Class `PencatatKlinik` digunakan untuk mencatat aktivitas ke file dan menutup file tersebut dengan `Dispose()`.

## 3. Satu keputusan desain dan alasannya

Saya memilih menggunakan interface `IBisaDitagih` karena kunjungan dan resep sama-sama memiliki tagihan, tetapi cara menghitungnya berbeda.

Pada kunjungan, tagihan berasal dari jasa tenaga medis dan biaya tindakan. Sementara itu, pada resep, tagihan berasal dari jasa apoteker dan harga obat. Dengan interface ini, `LayananTagihan` bisa menghitung keduanya tanpa perlu membedakan jenis objeknya satu per satu.

Menurut saya, cara ini membuat kode lebih mudah dikembangkan jika nantinya ada jenis tagihan lain. Class baru cukup menerapkan `IBisaDitagih` agar bisa ikut dihitung oleh layanan tagihan.

## 4. Bug atau kendala (minimal dua)

### Kendala 1: Memeriksa jadwal tenaga medis

Pada sistem jadwal, tenaga medis tidak boleh memiliki dua kunjungan yang waktunya bertabrakan. Pengecekannya perlu memperhatikan waktu mulai dan durasi kunjungan, bukan hanya membandingkan jam mulai.

Solusinya adalah menghitung waktu selesai dari setiap kunjungan, kemudian membandingkan rentang waktu kunjungan baru dengan jadwal yang sudah terdaftar. Jika tenaga medisnya sama dan waktunya bertabrakan, program melempar `JadwalBentrokException`. Kesalahan tersebut kemudian ditangani di `Program.cs`.

### Kendala 2: Memvalidasi data obat

Data obat perlu diperiksa agar nama obat tidak kosong, harga lebih dari nol, dan obat yang sama tidak dimasukkan dua kali.

Solusinya adalah melakukan pemeriksaan di method `TambahObat()`. Jika data tidak sesuai, program melempar `ObatTidakValidException` sehingga obat tersebut tidak ditambahkan ke daftar.

### Kendala 3: Menghitung total tagihan

Kunjungan dan resep memiliki komponen biaya yang berbeda. Jika perhitungan total hanya dibuat untuk satu jenis objek, layanan tagihan akan sulit digunakan untuk objek lain.

Solusinya adalah menggunakan interface `IBisaDitagih` yang memiliki method `HitungTagihan()`. Dengan begitu, `LayananTagihan` cukup memanggil method tersebut untuk setiap objek yang diterima, tanpa perlu mengetahui detail perhitungan di dalam setiap class.

