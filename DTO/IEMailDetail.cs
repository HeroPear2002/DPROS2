namespace DTO
{
    public interface IEMailDetail
    {
        string AppPass { get; set; }
        string Email { get; set; }
        long Id { get; set; }
        int Port { get; set; }
        string SMTP { get; set; }
    }
}