namespace PlantHere.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> Send(string to, string message);
    }
}
