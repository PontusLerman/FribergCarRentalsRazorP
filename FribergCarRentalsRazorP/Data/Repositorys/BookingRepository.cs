﻿using FribergCarRentalsRazorP.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRentalsRazorP.Data.Repositorys
{
    public class BookingRepository : IBooking
    {
        private readonly FribergCarRentalsRazorPContext fribergCarRentalsRazorPContext;

        public BookingRepository(FribergCarRentalsRazorPContext fribergCarRentalsRazorPContext)
        {
            this.fribergCarRentalsRazorPContext = fribergCarRentalsRazorPContext;
        }
        public void Add(Booking booking)
        {
            fribergCarRentalsRazorPContext.Add(booking);
            fribergCarRentalsRazorPContext.Entry(booking.Customer).State = EntityState.Unchanged;
            fribergCarRentalsRazorPContext.Entry(booking.Vehicle).State = EntityState.Unchanged;
            fribergCarRentalsRazorPContext.SaveChanges();
        }

        public void Delete(Booking booking)
        {
            fribergCarRentalsRazorPContext.Remove(booking);
            fribergCarRentalsRazorPContext.SaveChanges();
        }
        public IEnumerable<Booking> GetAll()
        {
            return fribergCarRentalsRazorPContext.Bookings.OrderBy(b => b.BookingStart);
        }

        public Booking GetById(int id)
        {
            return fribergCarRentalsRazorPContext.Bookings.FirstOrDefault(b => b.Id == id);
        }
        public void Update(Booking booking)
        {
            fribergCarRentalsRazorPContext.Update(booking);
            fribergCarRentalsRazorPContext.SaveChanges();
        }
    }
}
