using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ColourAPI.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation (IApplicationBuilder app)
        {
            using (var servicerScope =app.ApplicationServices.CreateScope())
            {
                    SeedData(servicerScope.ServiceProvider.GetService<ColourContext>());
            }
        }

        public static void SeedData(ColourContext context)
        {
            System.Console.WriteLine("Apling Migrations ..");
            context.Database.Migrate();
            if(!context.ColourItems.Any())
            {
                System.Console.WriteLine("Adding data - seeding ...");
                context.ColourItems.AddRange(
                    new Colour() {ColourName="Red"},
                    new Colour() {ColourName="Orange"},
                    new Colour() {ColourName="Yellow"},
                    new Colour {ColourName="Green"}
                );
            }else 
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}