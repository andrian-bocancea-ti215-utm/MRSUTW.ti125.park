using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using parkTrumpet.Domain.Entities;

namespace parkTrumpet.BusinessLogic.DBModel
{
    class TestingParkInitializer :DropCreateDatabaseAlways<ParkingSystemContext>
    {
        protected override void Seed(ParkingSystemContext context)
        {
            var car = new carDbTable 
            { Brand = "Ford", Color = "#004C80", ModelName = "Fiesta Mk7", RegistrationPlate = "YLY923" };
            var client = new clientDbTable
            { Username = "the.keybord", Password = "1111", PhoneNumber = "+37368799090", RegistrationDate = DateTime.UtcNow};
            car.Client = client;
            context.Cars.Add(car);

            var owner = new ownerDbTable
            { Name = "Tekwill" };
            var parking = new parkingDbTable
            { Name = "Tekwill Front", Owner = owner, FreeTime = 60, DayPrice = 0.3F , NightPrice = 0.1F , MapURL = "/content/"};
            var adminAccount = new adminAccountDbTable
            { Username = "root", Password = "1111", Owner = owner , Permissions="AP"};
            var lot1 = new lotDbTable
            { IsActive = true, Number = 1, Parking = parking, Type=1 , X = 30, Y=50 };
            var lot2 = new lotDbTable
            { IsActive = true, Number = 2, Parking = parking, Type = 1, X = 100, Y = 50 };
            var lot3 = new lotDbTable
            { IsActive = true, Number = 3, Parking = parking, Type = 2, X = 170, Y = 50 };
            var lot4 = new lotDbTable
            { IsActive = true, Number = 4, Parking = parking, Type = 3, X = 50, Y = 160 };
            context.Lots.Add(lot1);
            context.Lots.Add(lot2);
            context.Lots.Add(lot3);
            context.Lots.Add(lot4);
            context.AdminAccounts.Add(adminAccount);
            context.Parkings.Add(parking);
            context.SaveChanges();
        }
    }
}
