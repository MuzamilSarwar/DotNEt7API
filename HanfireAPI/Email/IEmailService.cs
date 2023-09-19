namespace HanfireAPI.Email
{
    public interface IEmailService
    {
        void SendEmail(string email, string content, string title);
    }
}
