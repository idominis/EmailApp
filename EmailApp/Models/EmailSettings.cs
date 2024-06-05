namespace EmailApp.Models
{
    public class EmailSettings
    {
        public int ItemsPerPage { get; set; }
        public List<string>? AllowedDomains { get; set; }
        public List<string>? BlacklistedWords { get; set; }
    }
    
}
