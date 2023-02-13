using PlantHere.Application.Interfaces.Services;

namespace PlantHere.Infrastructure.EmailServices
{
    public class EmailService : IEmailService
    {
        public async Task<bool> Send(string to, string message)
        {
            return true;
        }
    }
}
