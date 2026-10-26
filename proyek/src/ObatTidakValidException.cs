namespace Proyek;

public class ObatTidakValidException : Exception
{
    public ObatTidakValidException(string pesan)
        : base(pesan)
    {
    }
}
