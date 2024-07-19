namespace Categories.API.Utils;

public class RequestException : Exception
{

    public RequestException(string message = "Default error message", Exception? inner = null)
        : base($"Request Error: {message}", inner) { }
}

public class DatabaseException : Exception
{
    public DatabaseException(string message = "Default error message", Exception? inner = null)
        : base($"Database Error: {message}", inner) { }
}