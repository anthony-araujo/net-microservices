using System.Threading.Tasks;
using araujo.Domain.Entities;

namespace araujo.Domain.Services.Interfaces;

public interface IMailService
{
    Task SendPasswordResetMail(User user);
    Task SendActivationEmail(User user);
    Task SendCreationEmail(User user);
}
