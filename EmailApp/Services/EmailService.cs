using EmailApp.Data;
using EmailApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmailApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailDbContext _context;

        public EmailService(EmailDbContext context)
        {
            _context = context;
        }

        public async Task CreateEmailAsync(Email email)
        {
            email.CreatedDate = DateTime.Now;
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Email>> GetEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }
    }
}
