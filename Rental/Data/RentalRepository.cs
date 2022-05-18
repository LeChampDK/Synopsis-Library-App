using Rental.Data.Facade;
using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rental.Data
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalContext _db;

        public RentalRepository(RentalContext db)
        {
            _db = db;
        }

        public List<RentalStatus> GetAllRentalStatus()
        {
            return new List<RentalStatus>(_db.RentalStatus);
        }

        public List<RentalStatus> GetAllRentalStatusOnBook(int bookId)
        {
            return new List<RentalStatus>(_db.RentalStatus.Where(x => x.BookId == bookId && x.Rented == true));
        }

        public List<RentalStatus> GetAllReservedStatusOnBook(int bookId)
        {
            return new List<RentalStatus>(_db.RentalStatus.Where(x => x.BookId == bookId && x.Reserve == true));
        }

        public void ReserveBook(int bookId, int userId)
        {
            var newReservation = new RentalStatus
            {
                BookId = bookId,
                UserId = userId,
                Rented = false,
                Reserve = true,
                ReservedTime = System.DateTime.Now
            };

            _db.RentalStatus.Add(newReservation);
            _db.SaveChanges();
        }

        public void RentBook(int bookId, int userId)
        {
            var newReservation = new RentalStatus
            {
                BookId = bookId,
                UserId = userId,
                Rented = true,
                Reserve = false
            };

            _db.RentalStatus.Add(newReservation);
            _db.SaveChanges();
        }

        public void ReturnBook(int bookId, int userId)
        {
            var y = _db.RentalStatus.FirstOrDefault(y => y.BookId == bookId && y.UserId == userId);
            if (y == null)
            {
                throw new Exception("Rental entry does not exist.");
            }

            _db.RentalStatus.Remove(y);
            _db.SaveChanges();
        }
    }
}
