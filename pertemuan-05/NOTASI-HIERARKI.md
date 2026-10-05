# Diagram Hierarki Kelas (UML) — Perpustakaan

Gambarkan diagram UML yang menunjukkan **hubungan antar kelas** di pertemuan ini, di bagian **bawah** penanda di akhir berkas ini. Format bebas — boleh kotak ASCII/Mermaid (`classDiagram`) atau daftar bertingkat. Yang wajib ada:

- Kelas `Anggota`, `Mahasiswa`, `Dosen`, `Asisten`, `Alamat`, dan `LogAktivitas`.
- Hubungan **pewarisan** (*is-a*): panah segitiga kosong dari kelas turunan ke kelas induk (`<|--` di Mermaid, atau `▲`, atau tulis "extends"/"turunan dari").
- Hubungan **komposisi** (*has-a*): berlian terisi dekat pihak pemilik (`*--` di Mermaid, atau `◆`, atau tulis "komposisi"/"memiliki") — siapa memiliki siapa?
- Anggota `protected` ditandai dengan simbol `#` (mis. `# BatasPinjam`), `public` dengan `+`, `private` dengan `-`.

Contoh format Mermaid (untuk kelas lain, bukan jawaban):

```mermaid
classDiagram
    Kendaraan <|-- Mobil
    Mobil *-- Mesin
    class Kendaraan {
        + Merek : string
        # kecepatan : int
    }
```

Jangan hapus baris penanda di bawah ini — jawaban kalian harus ditulis **setelah** baris itu, bukan sebelumnya.

<!-- TULIS JAWABAN KALIAN DI BAWAH BARIS INI -->
```mermaid
classDiagram
%% protected = #, public = +, private = -

class Anggota {
    +string Id
    +string Nama
    +Alamat Alamat
    #int BatasPinjam
    +int JumlahPinjam
    +IReadOnlyList~string~ Riwayat
    +Anggota(string id, string nama, Alamat alamat)
    +string Info()
    +void Pinjam(string judul)
}

class Mahasiswa {
    +string Nrp
    +string Prodi
    +Mahasiswa(string id, string nama, Alamat alamat, string nrp, string prodi)
    +string InfoLengkap()
}

class Dosen {
    +string Nip
    +Dosen(string id, string nama, Alamat alamat, string nip)
    +string InfoLengkap()
}

class Asisten {
    +string MataKuliah
    +Asisten(string id, string nama, Alamat alamat, string nrp, string prodi, string mataKuliah)
    +string InfoAsisten()
}

class Alamat {
    +string Jalan
    +string Kota
    +Alamat(string jalan, string kota)
    +string ToString()
}

class LogAktivitas {
    -List~string~ _entri
    +IReadOnlyList~string~ Semua
    +void Catat(string pesan)
}

Anggota <|-- Mahasiswa
Anggota <|-- Dosen
Mahasiswa <|-- Asisten

Anggota *-- Alamat
Anggota *-- LogAktivitas
```
