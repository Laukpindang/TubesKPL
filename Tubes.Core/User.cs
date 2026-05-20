namespace Tubes.Core
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
    public static class Session
    {
        public static User CurrentUser { get; private set; }
        public static void SetCurrentUser(User user)
        {
            CurrentUser = user;
        }
        public static void logout()
        {
            CurrentUser = null;
        }
    }
}
