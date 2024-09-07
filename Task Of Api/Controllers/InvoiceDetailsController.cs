using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Of_Api.Data;
using Task_Of_Api.DTO;
using Task_Of_Api.Model;

namespace Task_Of_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public InvoiceDetailsController(ApplicationDBContext context ,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/InvoiceDetails
        [HttpGet]
        public async Task<IEnumerable<InvoiceDetailsDTO>> GetinvoiceDetails()
        {
            var invoiceDetails=  await _context.invoiceDetails.ToListAsync();
            return _mapper.Map<IEnumerable<InvoiceDetailsDTO>>(invoiceDetails);
        }

        // GET: api/InvoiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetailsDTO>> GetInvoiceDetails(int id)
        {
            var invoiceDetails = await _context.invoiceDetails.FindAsync(id);

            if (invoiceDetails == null)
            {
                return NotFound();
            }

            return _mapper.Map<InvoiceDetailsDTO>(invoiceDetails); 
        }

        // PUT: api/InvoiceDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceDetails(int id, InvoiceDetailsDTO invoiceDetails)
        {
            if (id != invoiceDetails.lineNo)
            {
                return BadRequest();
            }

            _context.Entry(_mapper.Map<InvoiceDetails>(invoiceDetails)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailsExists(id))
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

        // POST: api/InvoiceDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceDetails>> PostInvoiceDetails(InvoiceDetailsDTO invoiceDetails)
        {
            _context.invoiceDetails.Add(_mapper.Map<InvoiceDetails>(invoiceDetails));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceDetails", new { id = invoiceDetails.lineNo }, invoiceDetails);
        }

        // DELETE: api/InvoiceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceDetails(int id)
        {
            var invoiceDetails = await _context.invoiceDetails.FindAsync(id);
            if (invoiceDetails == null)
            {
                return NotFound();
            }

            _context.invoiceDetails.Remove(invoiceDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceDetailsExists(int id)
        {
            return _context.invoiceDetails.Any(e => e.lineNo == id);
        }
    }
}
