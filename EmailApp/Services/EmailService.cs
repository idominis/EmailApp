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
        private readonly LocalDbContext _context;

        public EmailService(LocalDbContext context)
        {
            _context = context;
        }

        public async Task CreateEmailAsync(Email email)
        {
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Email>> GetEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }
    }
}
