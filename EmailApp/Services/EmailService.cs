using EmailApp.Data;
using EmailApp.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ILogger = Serilog.ILogger;

namespace EmailApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailDbContext _context;
        private readonly ILogger _logger;

        public EmailService(EmailDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<EmailService>();
        }

        public async Task CreateEmailAsync(Email email)
        {
            try
            {
                _logger.Information("Creating email");
                email.CreatedDate = DateTime.Now;
                _context.Emails.Add(email);
                await _context.SaveChangesAsync();
                _logger.Information("Email created successfully");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error creating email");
                throw;
            }
        }

        public async Task<List<Email>> GetEmailsAsync()
        {
            try
            {
                _logger.Information("Getting emails");
                var emails = await _context.Emails.ToListAsync();
                _logger.Information("Retrieved {EmailCount} emails", emails.Count);
                return emails;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error getting emails");
                throw;
            }
        }
    }
}
