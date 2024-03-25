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

     public async Task UpdateIntegrationSourceAsync(IntegrationSource updatedIntegrationSource)
    {
        var existingIntegrationSource = await _dbContext.IntegrationSource.FindAsync(updatedIntegrationSource.Id);

        if (existingIntegrationSource == null)
        {
            throw new ArgumentException("Integration source not found");
        }

        // Update properties of existingIntegrationSource with updatedIntegrationSource
        existingIntegrationSource.Name = updatedIntegrationSource.Name;
        existingIntegrationSource.Type = updatedIntegrationSource.Type;
        existingIntegrationSource.Value = updatedIntegrationSource.Value;
        existingIntegrationSource.Path = updatedIntegrationSource.Path;
        existingIntegrationSource.FileExtension = updatedIntegrationSource.FileExtension;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteIntegrationSourceAsync(int integrationSourceId)
    {
        var integrationSource = await _dbContext.IntegrationSource.FindAsync(integrationSourceId);

        if (integrationSource != null)
        {
            _dbContext.IntegrationSource.Remove(integrationSource);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Integration source not found");
        }
    }
}
