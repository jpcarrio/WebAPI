using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly DBContext _context;

        public ReservationsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
            return _context.Reservations;
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation([FromRoute] int id, [FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservations
        [HttpPost]        
        public IActionResult PostReservation([FromBody] ContactReservation contactReservation)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@contactName", contactReservation.contactName));
            parameters.Add(new SqlParameter("@contactType", contactReservation.contactType));
            parameters.Add(new SqlParameter("@contactPhone", contactReservation.contactPhone));
            parameters.Add(new SqlParameter("@birthday", contactReservation.birthday));
            parameters.Add(new SqlParameter("@reservationPlace", contactReservation.reservationPlace));
            parameters.Add(new SqlParameter("@reservationDate", contactReservation.reservationDate));
            parameters.Add(new SqlParameter("@reservationId", 1));
                       
            var result = _context.Database.ExecuteSqlCommand("exec AddReservation @contactName, @contactType, @contactPhone, @birthday, @reservationPlace, @reservationDate, @reservationId out", parameters);
                        
            return Ok(result);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return Ok(reservation);
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}