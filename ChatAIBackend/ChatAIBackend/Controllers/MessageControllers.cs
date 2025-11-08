using ChatAIBackend.DataAccess;
using ChatAIBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace ChatAIBackend.Controllers
{
    [ApiController]
    [Route("api/messages")]

    public class MessageControllers : ControllerBase
    {
        private readonly string _connectionString;
        
        public MessageControllers(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Postgres")!;
        }

        [HttpGet]
        public ActionResult<List<Message>> GetMessage()
        {
            var messages = new List<Message>();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM messages ORDER BY id ASC", connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                messages.Add(new Message
                {
                    Id = reader.GetInt32(0),
                    userName = reader.GetString(1),
                    content = reader.GetString(2),
                    createdAt = reader.GetDateTime(3),
                });
            }

            return Ok(messages);
        }

        [HttpPost]
        public IActionResult AddMessage(Message msg)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var cmd = new NpgsqlCommand("INSERT INTO messages (userName, content, createdAt) VALUES (@_userName, @_content, @_createdAt", connection);

            cmd.Parameters.AddWithValue("_userName", msg.userName);
            cmd.Parameters.AddWithValue("_content", msg.content);
            cmd.Parameters.AddWithValue("_createdAt", msg.createdAt);

            cmd.ExecuteNonQuery();
            return Ok("Message added");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            using var cmd = new NpgsqlCommand("DELETE FROM messages WHERE id = @_id", connection);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();

            return Ok("Deleted");
        }

       
    }
}
