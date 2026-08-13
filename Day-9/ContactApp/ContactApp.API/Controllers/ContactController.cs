using ContactApp.BLL.Interfaces;
using ContactApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService service;

    public ContactController(IContactService service)
    {
        this.service = service;
    }


    // =====================================================
    // GET ALL CONTACTS
    // =====================================================

    [HttpGet]
    public IActionResult GetAllContacts()
    {
        var contacts = service.GetAllContacts();

        return Ok(contacts);
    }


    // =====================================================
    // GET CONTACT BY ID
    // =====================================================

    [HttpGet("{id}")]
    public IActionResult GetContactById(int id)
    {
        var contact = service.GetContactById(id);

        if (contact == null)
        {
            return NotFound(new
            {
                message = "Contact not found"
            });
        }

        return Ok(contact);
    }


    // =====================================================
    // POST CONTACT
    // =====================================================

    [HttpPost]
    public IActionResult CreateContact(
        [FromBody] Contact contact)
    {
        if (string.IsNullOrWhiteSpace(contact.Name))
        {
            return BadRequest(new
            {
                message = "Name is required"
            });
        }

        if (string.IsNullOrWhiteSpace(contact.Email))
        {
            return BadRequest(new
            {
                message = "Email is required"
            });
        }

        if (string.IsNullOrWhiteSpace(contact.Phone))
        {
            return BadRequest(new
            {
                message = "Phone is required"
            });
        }

        var newContact =
            service.AddContact(contact);

        return CreatedAtAction(
            nameof(GetContactById),
            new
            {
                id = newContact.Id
            },
            newContact
        );
    }


    // =====================================================
    // PUT CONTACT
    // =====================================================

    [HttpPut("{id}")]
    public IActionResult UpdateContact(
        int id,
        [FromBody] Contact contact)
    {
        var existingContact =
            service.GetContactById(id);

        if (existingContact == null)
        {
            return NotFound(new
            {
                message = "Contact not found"
            });
        }

        if (string.IsNullOrWhiteSpace(contact.Name))
        {
            return BadRequest(new
            {
                message = "Name is required"
            });
        }

        if (string.IsNullOrWhiteSpace(contact.Email))
        {
            return BadRequest(new
            {
                message = "Email is required"
            });
        }

        if (string.IsNullOrWhiteSpace(contact.Phone))
        {
            return BadRequest(new
            {
                message = "Phone is required"
            });
        }

        service.UpdateContact(id, contact);

        var updatedContact =
            service.GetContactById(id);

        return Ok(updatedContact);
    }


    // =====================================================
    // DELETE CONTACT
    // =====================================================

    [HttpDelete("{id}")]
    public IActionResult DeleteContact(int id)
    {
        var existingContact =
            service.GetContactById(id);

        if (existingContact == null)
        {
            return NotFound(new
            {
                message = "Contact not found"
            });
        }

        service.DeleteContact(id);

        return Ok(new
        {
            message = "Contact deleted successfully"
        });
    }
}