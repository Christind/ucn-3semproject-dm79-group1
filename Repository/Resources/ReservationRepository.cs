using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class ReservationRepository
    {
        private BPDbContext db;

        public ReservationRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Reservation> GetAllReservations()
        {
            return db.Reservations;
        }

        public Reservation GetReservationById(int id)
        {
            return db.Reservations.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Reservation> GetReservationsByUserId(int userId)
        {
            return db.Reservations.Where(x => x.UserId == userId);
        }

        public void Insert(Reservation reservation)
        {
            db.Reservations.Add(reservation);
            db.SaveChanges();
        }

        public void Update(Reservation reservation)
        {
            Reservation rReservation = GetReservationById(reservation.ID);
            if (rReservation == null)
                return;

            rReservation.CompletedDate = reservation.CompletedDate;

            db.SaveChanges();
        }

        public void Delete(Reservation reservation)
        {
            if (GetReservationById(reservation.ID) == null)
                return;
            db.Reservations.Remove(reservation);
            db.SaveChanges();
        }
    }
}