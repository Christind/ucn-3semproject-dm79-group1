using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class ReservationRepository
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

        public void Disable(int value)
        {
            Reservation rReservation = GetReservationById(value);

            if (rReservation == null)
                return;

            rReservation.IsActive = false;
            db.SaveChanges();
        }
    }
}