using Orders.Shared.Entities;

namespace Orders.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesAsync();
        await CheckCategoriesAsync();
    }

    private async Task CheckCategoriesAsync()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Compresores" });
            _context.Categories.Add(new Category { Name = "Evaporadores" });
            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country
            {
                Name = "Mexico",
                States = [
                new State()
                {
                    Name= "Sonora" ,
                    Cities = [
                        new City(){Name="Hermosillo" },
                        new City(){Name="Cd Obregón"},
                        new City(){Name="Nogales"},
                        new City(){Name="Navojoa"},
                        new City(){Name="Guaymas"},
                        new City(){Name="San Luis Rio Colorado"},
                        ]
                },
                new State()
                {
                    Name= "Baja California" ,
                    Cities = [
                        new City(){Name="Tijuana" },
                        new City(){Name="Mexicali"},
                        new City(){Name="Ensenada"},
                        new City(){Name="Playas de Rosarito"},
                        new City(){Name="Tecate"},
                        new City(){Name="San Felipe"},
                        new City(){Name="San Quintin"},
                        ]
                },
                ]
            });
            _context.Countries.Add(new Country
            {
                Name = "Estados Unidos",
                States = [
                new State()
                {
                    Name= "California" ,
                    Cities = [
                        new City(){Name="Los Angeles" },
                        new City(){Name="San Diego"},
                        new City(){Name="San Francisco"},
                        new City(){Name="Sacramento"},
                        new City(){Name="San Jose"},
                        new City(){Name="Oakland"},
                        ]
                },
                new State()
                {
                    Name= "Texas" ,
                    Cities = [
                        new City(){Name="Dallas" },
                        new City(){Name="Austin"},
                        new City(){Name="Houston"},
                        new City(){Name="San Antonio"},
                        new City(){Name="El Paso"},
                        new City(){Name="Fort Worth"},
                        new City(){Name="Midland"},
                        ]
                },
                ]
            });
            await _context.SaveChangesAsync();
        }
    }
}