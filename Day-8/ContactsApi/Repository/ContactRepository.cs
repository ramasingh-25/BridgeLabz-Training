using ContactApp.Model;
using Microsoft.Data.SqlClient;

namespace ContactApp.Repository;

public class ContactRepository
{
    private readonly string connectionString;

    public ContactRepository(IConfiguration configuration)
    {
        connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string not found.");
    }


    // =====================================================
    // GET ALL CONTACTS
    // =====================================================

    public List<Contact> GetAll()
    {
        List<Contact> contacts = new List<Contact>();

        using SqlConnection connection =
            new SqlConnection(connectionString);

        string query =
            "SELECT Id, Name, Email, Phone FROM Contacts";

        using SqlCommand command =
            new SqlCommand(query, connection);

        connection.Open();

        using SqlDataReader reader =
            command.ExecuteReader();

        while (reader.Read())
        {
            Contact contact = new Contact
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString() ?? "",
                Email = reader["Email"].ToString() ?? "",
                Phone = reader["Phone"].ToString() ?? ""
            };

            contacts.Add(contact);
        }

        return contacts;
    }


    // =====================================================
    // GET CONTACT BY ID
    // =====================================================

    public Contact? GetById(int id)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        string query = @"
            SELECT Id, Name, Email, Phone
            FROM Contacts
            WHERE Id = @Id";

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        using SqlDataReader reader =
            command.ExecuteReader();

        if (reader.Read())
        {
            return new Contact
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString() ?? "",
                Email = reader["Email"].ToString() ?? "",
                Phone = reader["Phone"].ToString() ?? ""
            };
        }

        return null;
    }


    // =====================================================
    // ADD CONTACT
    // =====================================================

    public Contact Add(Contact contact)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        string query = @"
            INSERT INTO Contacts
            (Name, Email, Phone)

            OUTPUT INSERTED.Id

            VALUES
            (@Name, @Email, @Phone)";

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Name", contact.Name);
        command.Parameters.AddWithValue("@Email", contact.Email);
        command.Parameters.AddWithValue("@Phone", contact.Phone);

        connection.Open();

        int newId =
            Convert.ToInt32(command.ExecuteScalar());

        contact.Id = newId;

        return contact;
    }


    // =====================================================
    // UPDATE CONTACT
    // =====================================================

    public bool Update(int id, Contact updatedContact)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        string query = @"
            UPDATE Contacts
            SET
                Name = @Name,
                Email = @Email,
                Phone = @Phone
            WHERE Id = @Id";

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);
        command.Parameters.AddWithValue("@Name", updatedContact.Name);
        command.Parameters.AddWithValue("@Email", updatedContact.Email);
        command.Parameters.AddWithValue("@Phone", updatedContact.Phone);

        connection.Open();

        int rowsAffected =
            command.ExecuteNonQuery();

        return rowsAffected > 0;
    }


    // =====================================================
    // DELETE CONTACT
    // =====================================================

    public bool Delete(int id)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        string query =
            "DELETE FROM Contacts WHERE Id = @Id";

        using SqlCommand command =
            new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();

        int rowsAffected =
            command.ExecuteNonQuery();

        return rowsAffected > 0;
    }
}