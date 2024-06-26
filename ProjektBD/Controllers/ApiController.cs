using Microsoft.AspNetCore.Mvc;
using ProjektBD.Data;
using ProjektBD.Data.Entities;
using System.Reflection.Metadata.Ecma335;

namespace ProjektBD.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        private PrimaryContext PrimaryContext { get; set; }
        public ApiController(PrimaryContext primaryContext)
        {
            PrimaryContext = primaryContext;
        }
        [HttpGet("books")]
        public ActionResult<List<Book>> GetBooks()
        {
            return PrimaryContext.Books.ToList();
        }
        [HttpGet("books/{id}")]
        public ActionResult<Book> GetBooks(int id)
        {
            if (PrimaryContext.Books.FirstOrDefault(f => f.Id == id) is Book book)
                return book;
            return NotFound();
        }
        [HttpGet("overdue/rentals")]
        public ActionResult<List<Rental>> GetOverdueRentals()
        {
            return PrimaryContext.Rentals.Where(f => f.DueDate <= DateTime.Today && !f.Returned).ToList();
        }
        [HttpGet("overdue/fees")]
        public ActionResult<List<Fee>> GetUnpaidFees()
        {
            return PrimaryContext.Fees.Where(f => f.StatusDateChange <= DateTime.Today && f.Status == Fee.FeeStatus.Pending).ToList();
        }
        [HttpGet("overdue/fees/generate")]
        public ActionResult<List<Fee>> GenerateFees()
        {
            List<Fee> fees = new();
            foreach(Rental r in PrimaryContext.Rentals.Where(f => f.DueDate <= DateTime.Today && !f.Returned).ToList())
            {
                var fee = new Fee() { Rental = r};
                fees.Add(fee);
                PrimaryContext.Fees.Add(fee);
            }
            PrimaryContext.SaveChanges();
            return fees;
        }
        [HttpGet("overdue/fees/{id}/due")]
        public ActionResult<double> GetFeeAmount(int id)
        {
            if (PrimaryContext.Fees.FirstOrDefault(f => f.Id == id) is Fee fee)
                return fee.GetDueAmount();
            return NotFound();
        }
        [HttpGet("overdue/fees/{id}")]
        public ActionResult<Fee> GetFee(int id)
        {
            if (PrimaryContext.Fees.FirstOrDefault(f => f.Id == id) is Fee fee)
                return fee;
            return NotFound();
        }
        [HttpGet("fees/status/{id}")]
        public ActionResult<string> GetStatusName(int id) => id switch
        {
            0 => "Pending",
            1 => "Waived",
            2 => "Paid",
            _ => "Unknown",
        };
    }
}
