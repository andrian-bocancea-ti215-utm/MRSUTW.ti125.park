using parkTrumpet.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parkTrumpet.Domain.Entities.Test;
using parkTrumpet.Domain.Entities;
using parkTrumpet.BusinessLogic.DBModel;

namespace parkTrumpet.BusinessLogic
{ 
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
        public int DoTest()
        {
            using (var db = new ParkingSystemContext())
            {
                ownerDbTable x = new ownerDbTable
                {
                    Name = "Kaufland"
                };
                db.Owners.Add(x);
                db.SaveChanges();
            }
            return 0;
        }

        public List<parkingDbTable> RetrieveParkingList()
        {
            System.Diagnostics.Debug.WriteLine("aici");
            using (var db = new ParkingSystemContext())
            {
                return db.Parkings.ToList();
            }
            
        }

        public int ReportCarArrival(string ParkingName,string PlateNumber)
        {
            carDbTable currentCar;
            parkingDbTable currentParking;
            parkingSessionDbTable currentSession;
            using (var db = new ParkingSystemContext())
            {
                currentCar = db.Cars.FirstOrDefault(c => c.RegistrationPlate == PlateNumber);
                currentParking = db.Parkings.FirstOrDefault(p => p.Name == ParkingName);
                currentSession = new parkingSessionDbTable
                {
                    Car = currentCar,
                    Parking = currentParking,
                    ArrivalTime = DateTime.UtcNow
                };
                db.ParkingSessions.Add(currentSession);
                db.SaveChanges();
            }
            return 0;
        }
    }
}
