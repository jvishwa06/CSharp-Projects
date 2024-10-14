using MongoDB.Driver;
using MongoDB.Bson;
using BCrypt.Net;
using System.Threading.Tasks;

public class MongoUserService
{
    private readonly IMongoCollection<BsonDocument> _userCollection;

    public MongoUserService()
    {
        var client = new MongoClient("mongodb://localhost:27017"); 
        var database = client.GetDatabase("AuthDB"); 
        _userCollection = database.GetCollection<BsonDocument>("Users"); 
    }

    // Register a new user
    public async Task<bool> RegisterUser(string username, string password)
    {
        // Check if the username already exists
        var filter = Builders<BsonDocument>.Filter.Eq("Username", username);
        var existingUser = await _userCollection.Find(filter).FirstOrDefaultAsync();

        if (existingUser != null)
        {
            return false; // User already exists
        }

        // Hash the password using BCrypt
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        var userDocument = new BsonDocument
        {
            { "Username", username },
            { "PasswordHash", passwordHash }
        };

        await _userCollection.InsertOneAsync(userDocument);
        return true;
    }

    // Verify login credentials
    public async Task<bool> VerifyUser(string username, string password)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("Username", username);
        var userDocument = await _userCollection.Find(filter).FirstOrDefaultAsync();

        if (userDocument == null)
        {
            return false; // User does not exist
        }

        // Verify the password
        string storedPasswordHash = userDocument["PasswordHash"].AsString;
        return BCrypt.Net.BCrypt.Verify(password, storedPasswordHash);
    }
}
