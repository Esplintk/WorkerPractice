namespace shared;

public record Location(int row, int column);
public record EnlistRequest(string host, int port);
public record Password (string password);
public interface IToken
{
    public string Token {get; set;}
}