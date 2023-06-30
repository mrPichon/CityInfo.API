namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@gmail.com";
        private string _mailFrom = "noreply@gmail.com";

        public void Send(string subject, string message)
        {
            // send mail - output console window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo} with {nameof(CloudMailService)}");
            Console.WriteLine($"Subject {subject}");
            Console.WriteLine($"Message {message}");
        }
    }
}
