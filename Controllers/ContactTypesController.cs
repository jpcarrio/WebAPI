using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypesController : ControllerBase
    {
        private readonly DBContext _context;

        public ContactTypesController(DBContext context)
        {
            _context = context;
        }

        // GET: api/ContactTypes
        [HttpGet]
        public IEnumerable<ContactType> GetContactTypes()
        {
            return _context.ContactTypes;
        }

        // GET: api/ContactTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactType = await _context.ContactTypes.FindAsync(id);

            if (contactType == null)
            {
                return NotFound();
            }

            return Ok(contactType);
        }       
    }
}