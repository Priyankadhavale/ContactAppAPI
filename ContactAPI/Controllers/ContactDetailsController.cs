using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ContactAPI.Models;

namespace ContactAPI.Controllers
{
    public class ContactDetailsController : ApiController
    {
        private ContactEntities db = new ContactEntities();

        // GET: api/ContactDetails
        public IQueryable<ContactDetail> GetContactDetails()
        {
            return db.ContactDetails;
        }

        // GET: api/ContactDetails/5
        [ResponseType(typeof(ContactDetail))]
        public async Task<IHttpActionResult> GetContactDetail(int id)
        {
            ContactDetail contactDetail = await db.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            return Ok(contactDetail);
        }

        // PUT: api/ContactDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContactDetail(ContactDetail contactDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(contactDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailExists(contactDetail.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ContactDetails
        [ResponseType(typeof(ContactDetail))]
        public async Task<IHttpActionResult> PostContactDetail(ContactDetail contactDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactDetails.Add(contactDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contactDetail.ID }, contactDetail);
        }

        // DELETE: api/ContactDetails/5
        [ResponseType(typeof(ContactDetail))]
        public async Task<IHttpActionResult> DeleteContactDetail(int id)
        {
            ContactDetail contactDetail = await db.ContactDetails.FindAsync(id);
            if (contactDetail == null)
            {
                return NotFound();
            }

            db.ContactDetails.Remove(contactDetail);
            await db.SaveChangesAsync();

            return Ok(contactDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactDetailExists(int id)
        {
            return db.ContactDetails.Count(e => e.ID == id) > 0;
        }
    }
}