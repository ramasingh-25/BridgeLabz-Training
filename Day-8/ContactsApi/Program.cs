using ContactApp.Model;
using ContactApp.Repository;
using ContactApp.Service;

var builder = WebApplication.CreateBuilder(args);


// =====================================================
// SWAGGER CONFIGURATION
// =====================================================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


// =====================================================
// DEPENDENCY INJECTION
// =====================================================

builder.Services.AddScoped<ContactRepository>();

builder.Services.AddScoped<ContactService>();


var app = builder.Build();


// =====================================================
// SWAGGER
// =====================================================

app.UseSwagger();

app.UseSwaggerUI();


// =====================================================
// HOME
// =====================================================

app.MapGet("/", () =>
{
    return Results.Redirect("/swagger");
});


// =====================================================
// GET ALL CONTACTS
// =====================================================

app.MapGet("/api/contacts",
    (ContactService service) =>
{
    var contacts = service.GetAllContacts();

    return Results.Ok(contacts);
})
.WithName("GetAllContacts");


// =====================================================
// GET CONTACT BY ID
// =====================================================

app.MapGet("/api/contacts/{id:int}",
    (int id, ContactService service) =>
{
    var contact = service.GetContactById(id);

    if (contact == null)
    {
        return Results.NotFound(new
        {
            message = "Contact not found"
        });
    }

    return Results.Ok(contact);
})
.WithName("GetContactById");


// =====================================================
// ADD CONTACT
// =====================================================

app.MapPost("/api/contacts",
    (Contact contact, ContactService service) =>
{
    if (string.IsNullOrWhiteSpace(contact.Name))
    {
        return Results.BadRequest(new
        {
            message = "Name is required"
        });
    }

    if (string.IsNullOrWhiteSpace(contact.Email))
    {
        return Results.BadRequest(new
        {
            message = "Email is required"
        });
    }

    if (string.IsNullOrWhiteSpace(contact.Phone))
    {
        return Results.BadRequest(new
        {
            message = "Phone is required"
        });
    }

    var newContact =
        service.AddContact(contact);

    return Results.Created(
        $"/api/contacts/{newContact.Id}",
        newContact
    );
})
.WithName("CreateContact");


// =====================================================
// UPDATE CONTACT
// =====================================================

app.MapPut("/api/contacts/{id:int}",
    (int id,
     Contact contact,
     ContactService service) =>
{
    var existingContact =
        service.GetContactById(id);

    if (existingContact == null)
    {
        return Results.NotFound(new
        {
            message = "Contact not found"
        });
    }

    if (string.IsNullOrWhiteSpace(contact.Name))
    {
        return Results.BadRequest(new
        {
            message = "Name is required"
        });
    }

    if (string.IsNullOrWhiteSpace(contact.Email))
    {
        return Results.BadRequest(new
        {
            message = "Email is required"
        });
    }

    if (string.IsNullOrWhiteSpace(contact.Phone))
    {
        return Results.BadRequest(new
        {
            message = "Phone is required"
        });
    }

    service.UpdateContact(id, contact);

    var updatedContact =
        service.GetContactById(id);

    return Results.Ok(updatedContact);
})
.WithName("UpdateContact");


// =====================================================
// DELETE CONTACT
// =====================================================

app.MapDelete("/api/contacts/{id:int}",
    (int id, ContactService service) =>
{
    var existingContact =
        service.GetContactById(id);

    if (existingContact == null)
    {
        return Results.NotFound(new
        {
            message = "Contact not found"
        });
    }

    service.DeleteContact(id);

    return Results.Ok(new
    {
        message = "Contact deleted successfully"
    });
})
.WithName("DeleteContact");


app.Run();