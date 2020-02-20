using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data;
using models;
using Microsoft.AspNetCore.Authorization;
using business.WSTeacher;
using business.WSUser.interfaces;
using business.WSTeacher.HeadTeacher;
using business.WSUser;
using System.Security.Claims;

namespace CRMDevEducation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private UserManager _manager;

        // GET: api/Leads
        [HttpGet]
        public ActionResult GetLeads()
        {
            _manager = new UserManager(User);
            return Ok(_manager.GetLeads());
        }

        //// GET: api/Leads/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Lead>> GetLead(int id)
        //{
        //    var lead = await _context.Leads.FindAsync(id);

        //    if (lead == null)
        //    {
        //        return NotFound();
        //    }

        //    return lead;
        //}

        //// PUT: api/Leads/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutLead(int id, Lead lead)
        //{
        //    if (id != lead.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(lead).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LeadExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Leads
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Lead>> PostLead(Lead lead)
        //{
        //    _context.Leads.Add(lead);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetLead", new { id = lead.Id }, lead);
        //}

        //// DELETE: api/Leads/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Lead>> DeleteLead(int id)
        //{
        //    var lead = await _context.Leads.FindAsync(id);
        //    if (lead == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Leads.Remove(lead);
        //    await _context.SaveChangesAsync();

        //    return lead;
        //}

        //private bool LeadExists(int id)
        //{
        //    return _context.Leads.Any(e => e.Id == id);
        //}
    }
}
