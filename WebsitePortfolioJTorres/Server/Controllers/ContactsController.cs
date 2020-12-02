using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsitePortfolioJTorres.Server.Data;
using WebsitePortfolioJTorres.Shared.Models;

namespace WebsitePortfolioJTorres.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ContactsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        //GET: api/contacts
        [HttpGet] //GetsContactList
        public async Task<ActionResult<IEnumerable<ContactInfo>>> GetContacts()
        {
            return await db.Contacts.ToListAsync();
        }

        //POST: api/contacts 
        [HttpPost] //AddsNewContact
        public async Task<ActionResult<ContactInfo>> AddNewContact(ContactInfo addContact)
        {
            db.Contacts.Add(addContact);
            await db.SaveChangesAsync();

            return CreatedAtAction("GetContacts", new { id = addContact.ContactId }, addContact);
        }

        // PUT: api/contacts
        [HttpPut]
        public async Task<ActionResult<ContactInfo>> UpdateContact(ContactInfo contactUpdated)
        {
            db.Entry(contactUpdated).State = EntityState.Modified;

            var expToUpdate = await GetContacts();
            try
            {
                await db.SaveChangesAsync();

                return await UpdateContact(contactUpdated);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        //DELETE: api/contacts
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactInfo>> DeleteExperience(int id)
        {
            var contactInfo = await db.Contacts.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contactInfo);
            await db.SaveChangesAsync();

            return contactInfo;
        }
    }
}
