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

        [HttpPut] //UpdateContact
        public async Task<ActionResult<ContactInfo>> UpdateContactInfo(ContactInfo updateContact)
        {
            try
            {
                var contactToUpdate = await GetContacts();

                if (contactToUpdate == null)
                {
                    return NotFound($"Contact not found");
                }

                return await UpdateContactInfo(updateContact);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
