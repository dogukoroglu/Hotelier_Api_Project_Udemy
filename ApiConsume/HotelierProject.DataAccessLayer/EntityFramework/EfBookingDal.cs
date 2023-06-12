using HotelierProject.DataAccessLayer.Abstract;
using HotelierProject.DataAccessLayer.Concrete;
using HotelierProject.DataAccessLayer.Repositories;
using HotelierProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelierProject.DataAccessLayer.EntityFramework
{
	public class EfBookingDal : GenericRepository<Booking>, IBookingDal
	{
		public EfBookingDal(Context context) : base(context)
		{

		}

		public void BookingStatusChangeApproved(Booking booking)
		{
			var c = new Context();
			var values = c.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
			values.Status = "Onaylandı";
			c.SaveChanges();
		}

		public void BookingStatusChangeApproved2(int id)
		{
			var c = new Context();
			var values = c.Bookings.Find(id);
			values.Status = "Onaylandı";
			c.SaveChanges();
		}

        public void BookingStatusChangeApproved3(int id)
        {
			var context = new Context();
			var values = context.Bookings.Find(id);
			values.Status = "Onaylandı";
			context.SaveChanges();
        }

		public void BookingStatusChangeCancel(int id)
		{
			var context = new Context();
			var values = context.Bookings.Find(id);
			values.Status = "İptal Edildi";
			context.SaveChanges();
		}

		public void BookingStatusChangeWait(int id)
		{
			var context = new Context();
			var values = context.Bookings.Find(id);
			values.Status = "Müşteri Aranacak";
			context.SaveChanges();
		}

		public int GetBookingCount()
        {
			var c = new Context();
			var value = c.Bookings.Count();
			return value;
        }

		public List<Booking> Last6Bookings()
		{
			var context = new Context();
			var values = context.Bookings.OrderByDescending(x => x.BookingID).Take(6).ToList();
			return values;
		}
	}
}
