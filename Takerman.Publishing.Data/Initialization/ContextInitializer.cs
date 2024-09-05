using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Takerman.Publishing.Data.Initialization
{
    public class ContextInitializer(ILogger<ContextInitializer> _logger, DefaultContext _context) : IContextInitializer
    {
        private const string ApplicationName = "publishing";

        public async Task InitializeAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }
    }
}