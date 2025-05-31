
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProdavnicaObuce.Interface;
using ProdavnicaObuce.Models;
using ProdavnicaObuce.Settings;

namespace ProdavnicaObuce.HostedServices
{
    public class ProdajaCleanupHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public ProdajaCleanupHostedService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ProdavnicaDbContext>();

            var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                try
                {
                    Console.WriteLine($"Running at {DateTime.Now}");
                    await dbContext.StavkeProdaje.Where(x => x.Prodaja.NacinPlacanja == NacinPlacanja.Kartica && !x.Prodaja.Placeno && x.Prodaja.VremeProdaje < DateTime.Now.AddMinutes(-1)).ExecuteDeleteAsync(stoppingToken);
                    await dbContext.Prodaje.Where(x => x.NacinPlacanja == NacinPlacanja.Kartica && !x.Placeno && x.VremeProdaje < DateTime.Now.AddMinutes(-1)).ExecuteDeleteAsync(stoppingToken);
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
