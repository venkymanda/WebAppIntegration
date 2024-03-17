using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppIntegration.Data;
using WebAppIntegration.Model;

public class IntegrationService
{
    private readonly ApplicationDbContext _dbContext;

    public IntegrationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<IntegrationSource>> GetIntegrationSourcesAsync(string userId)
    {
        return await _dbContext.IntegrationSource
            .Where(s => s.UserId == userId)
            .ToListAsync();
    }

    public async Task AddIntegrationSourceAsync(IntegrationSource integrationSource, string userId)
    {
        integrationSource.UserId = userId; // Set the UserId property
        _dbContext.IntegrationSource.Add(integrationSource);
        await _dbContext.SaveChangesAsync();
    }
}
