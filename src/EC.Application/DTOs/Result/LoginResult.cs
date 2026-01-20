namespace EC.Application.DTOs.Result;

public sealed record LoginResult
{
    public bool Success { get; }
    public string? Token { get; }
    public string? Error { get; }

    private LoginResult(bool success, string? token, string? error)
    {
        Success = success;
        Token = token;
        Error = error;
    }

    public static LoginResult Ok(string token)
        => new(true, token, null);

    public static LoginResult Failure(string error)
        => new(false, null, error);
}