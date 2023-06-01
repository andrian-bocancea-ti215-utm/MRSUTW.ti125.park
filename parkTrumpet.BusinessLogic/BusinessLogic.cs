using Newtonsoft.Json;
using parkTrumpet.BusinessLogic.DBModel;
using parkTrumpet.BusinessLogic.Interfaces;
using parkTrumpet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace parkTrumpet.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
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

        public string RetrieveClientCarList(int id)
        {
            using (var db = new ParkingSystemContext())
            {
                return JsonConvert.SerializeObject(
                    db.Cars.Include("Client").Where(c => c.Client.Id == id).ToList());
            }
        }
        public string RetrieveCarData(int id)
        {
            using (var db = new ParkingSystemContext())
            {
                return JsonConvert.SerializeObject(
                    db.Cars.FirstOrDefault(c=>c.Id==id));
            }
        }
        public string RetrieveParkingLotList(int pId)
        {
            using (var db = new ParkingSystemContext())
            {
                return JsonConvert.SerializeObject(
                    db.Lots.Include("Parking").Where(l => l.Parking.Id == pId).ToList());
            }
        }
        public int SaveCarData(string carJson, int userId)
        {
            var car = JsonConvert.DeserializeObject<carDbTable>(carJson);
            using (var db = new ParkingSystemContext())
            {
                var x = db.Cars.FirstOrDefault(c => c.Id == car.Id);
                if (x != null)
                {
                    x.Brand = car.Brand;
                    x.Color = car.Color;
                    x.ModelName = car.ModelName;
                }
                else
                {
                    car.Client = db.Clients.FirstOrDefault(c => c.Id == userId);
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
            return 0;
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
        public string RetrievePSListByUserId(int id)
        {
            using (var db = new ParkingSystemContext())
            {

                return JsonConvert.SerializeObject(db.ParkingSessions.Include("Car").Include("Parking").Include("Car.").ToList());
            }
        }
        public string RetrievePListFromAdKey(string adkey)
        {
            int adId = GetAdIdByKey(adkey);
            if (adId != 0)
            {
                using (var db = new ParkingSystemContext())
                {
                    int owId = db.AdminAccounts.Include("Owner").FirstOrDefault(c => c.Id == adId).Owner.Id;
                    var pList = db.Parkings.Include("Owner").Where(p => p.Owner.Id == owId).ToList();
                    return JsonConvert.SerializeObject(pList);
                }
            }
            else
                return JsonConvert.SerializeObject(new List<parkingDbTable>());
        }
        public string RetrieveUserData(int id)
        {
            using (var db = new ParkingSystemContext())
            {
                return JsonConvert.SerializeObject(db.Clients.FirstOrDefault(c => c.Id == id));
            }
        }
        public string GetAdminAccountKey(string username,string password)
        {
            using (var db = new ParkingSystemContext())
            {
                var cAccount = db.AdminAccounts.FirstOrDefault(a => a.Username == username && a.Password == password);
                if (cAccount != null)
                    return cAccount.Id.ToString();
                else
                    return "0";
            }
        }
        internal int GetAdIdByKey(string key)
        {
            using (var db = new ParkingSystemContext())
            {
                if(Int32.TryParse(key,out int id))
                {
                    var account = db.AdminAccounts.FirstOrDefault(a=>a.Id==id);
                    if (account != null)
                        return account.Id;
                }
                return 0;
            }
        }
        public int AddPLot(int pId,int x,int y,int t)
        {
            using (var db = new ParkingSystemContext())
            {
                var parking = db.Parkings.FirstOrDefault(p => p.Id == pId);
                var lots = db.Lots.Include("Parking").Where(l => l.Parking.Id == pId);
                var newLot = new lotDbTable() { IsActive = true, Number = 0, Parking = parking, Type = t, X = x, Y = y };
                db.Lots.Add(newLot);
                db.SaveChanges();
                int n = 1;
                lots = db.Lots.Include("Parking").Where(l => l.Parking.Id == pId);
                foreach (var lot in lots)
                {
                    lot.Number = n;
                    n++;
                }
                db.SaveChanges();
            }
            return 0;
        }
        public int RemovePLot(int pId,int lNumber)
        {
            using (var db = new ParkingSystemContext())
            {
                db.Lots.Remove(db.Lots.Include("Parking").FirstOrDefault(l => l.Parking.Id == pId && l.Number==lNumber )) ;
                db.SaveChanges();
            }
            return 0;
        }
        public int GetUserAccountKey(string username, string password)
        {
            using (var db = new ParkingSystemContext())
            {
                var cAccount = db.Clients.FirstOrDefault(a => a.Username == username && a.Password == password);
                if (cAccount != null)
                    return cAccount.Id;
                else
                    return 0;
            }
        }
        public int RegisterUser(string userJson)
        {
            using (var db = new ParkingSystemContext())
            {
                var client = JsonConvert.DeserializeObject<clientDbTable>(userJson);
                client.RegistrationDate = DateTime.UtcNow;
                db.Clients.Add(client);
                db.SaveChanges();
            }
            return 0;
        }
        public int AddNewCar(string carJson,int clientId)
        {
            using (var db = new ParkingSystemContext())
            {
                carDbTable newCar = JsonConvert.DeserializeObject<carDbTable>(carJson);
                newCar.Client.Id = clientId;
                db.Cars.Add(newCar);
                db.SaveChanges();
                return 0;
            }
        }
    }
}
