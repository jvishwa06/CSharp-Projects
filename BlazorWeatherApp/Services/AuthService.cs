public class AuthService
{
    public bool IsAuthenticated { get; private set; } = false;

    public void Login()
    {
        IsAuthenticated = true;
    }

    public void Logout()
    {
        IsAuthenticated = false;
    }
}
