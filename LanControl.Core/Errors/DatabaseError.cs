namespace LanControl.Core.Errors;

public class DatabaseError(string message) : Exception(message)
{
}