using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactManagerAPI.Data;
using ContactManagerAPI.Models;

namespace ContactManagerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactManagerController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactManagerController(ApiContext context)
        {
            _context = context;
        }

        // POST
        [HttpPost]
        public JsonResult CreateEdit(Contact contact)
        {
            if(contact == null)
            {
                return new JsonResult(new { success = false, message = "Contact is null" });
            }

            if(contact.Id == 0)
            {
                _context.Add(contact);
            }
            else
            {
                var contactFromContext = _context.Contacts.Find(contact.Id);
                if(contactFromContext == null)
                {
                    return new JsonResult(new { success = false, message = "Contact not found" });
                }

                contactFromContext.Name = contact.Name;
                contactFromContext.Email = contact.Email;
                contactFromContext.PhoneNumber = contact.PhoneNumber;
            }

            _context.SaveChanges();

            return new JsonResult(new { success = true, data = contact });
        }

        // GET
        [HttpGet]
        public JsonResult GetById(int id)
        {
            var contact = _context.Contacts.Find(id);

            if(contact == null)
            {
                return new JsonResult(new { success = false, message = "Contact not found" });
            }

            return new JsonResult(new { success = true, data = contact });
        }

        // GET
        [HttpGet]
        public JsonResult GetAll()
        {
            var contacts = _context.Contacts.ToList();
            return new JsonResult(new { success = true, data = contacts });
        }

        // DELETE
        [HttpDelete]
        public JsonResult DeleteById(int id)
        {
            try
            {
                var contact = _context.Contacts.Find(id);
                if (contact == null)
                {
                    return new JsonResult(new { success = false, message = "Contact not found" });
                }

                _context.Contacts.Remove(contact);
                _context.SaveChanges();

                return new JsonResult(new { success = true, message = "Contact deleted successfully" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new JsonResult(new { success = false, message = "Internal server error" });
            }
        }
    }
}
