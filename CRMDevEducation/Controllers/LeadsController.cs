using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using data;
using models;
using Microsoft.AspNetCore.Authorization;
using business.WSTeacher;
using business.WSUser.interfaces;
using business.WSTeacher.HeadTeacher;
using business.WSUser;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using business;
using Microsoft.AspNetCore.Mvc;
using business.Models;
using System.Text.Json;
using CRMDevEducation.Models.Output;
using CRMDevEducation.Models.Mapping;

namespace CRMDevEducation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private IUserManager _manager;


       
        [HttpGet]
        public string Get(int id)
        {
            _manager = StorageToken.GetManager(Request.Headers["Authorization"]);
            string json = "";
            if (StorageToken.Check(Request.Headers["Authorization"]))
            {
                json += JsonSerializer.Serialize<OutputLeadModel>(LeadMappingBusinessToOutput.Map((LeadBusinessModel)_manager.GetLead(id))); 
            }
            else
            {
                return "You do not have access to this page :(";
            }
            return json;
           

        }

        // PUT: api/Leads/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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
