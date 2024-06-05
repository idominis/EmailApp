using EmailApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public interface IEmailService
    {
        Task CreateEmailAsync(Email email);
        Task<List<Email>> GetEmailsAsync();
    }
}
