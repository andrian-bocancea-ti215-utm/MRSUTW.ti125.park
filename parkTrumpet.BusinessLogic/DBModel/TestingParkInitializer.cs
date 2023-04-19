﻿using System;
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
            { Name = "Tekwill Front", Owner = owner };
            var adminAccount = new adminAccountDbTable
            { Username = "root", Password = "1111", Owner = owner };

            context.AdminAccounts.Add(adminAccount);
            context.Parkings.Add(parking);
            context.SaveChanges();
        }
    }
}