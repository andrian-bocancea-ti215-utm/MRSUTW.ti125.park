using parkTrumpet.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using parkTrumpet.Domain.Entities.Test;
using parkTrumpet.Domain.Entities;
using parkTrumpet.BusinessLogic.DBModel;
using System.Text.Json;
using Newtonsoft.Json;

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

        public string RetrieveParkingList()
        {
            var x = new List<parkingDbTable>();
            using (var db = new ParkingSystemContext())
            {
                x = db.Parkings.ToList();
                return (JsonConvert.SerializeObject(x));
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

        public int ReportCarDeparture(string ParkingName, string PlateNumber)
        {
            carDbTable currentCar;
            parkingDbTable currentParking;
            parkingSessionDbTable currentSession;
            using (var db = new ParkingSystemContext())
            {
                currentSession = db.ParkingSessions.FirstOrDefault(
                    c => c.Parking.Name == ParkingName && c.Car.RegistrationPlate == PlateNumber && c.DepartureTime == null);
                if(currentSession!=null)
                {
                    currentSession.DepartureTime = DateTime.UtcNow;
                    db.SaveChanges();
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
        public string RetrieveParkingSessionList()
        {
            using (var db = new ParkingSystemContext())
            {
                return JsonConvert.SerializeObject(db.ParkingSessions.Include("Car").Include("Parking").ToList());
            }
        }
    }
}
