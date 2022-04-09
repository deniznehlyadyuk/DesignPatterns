namespace State.DocumentPublication
{
    public enum UserRoles
    {
        Admin,
        Author,
        Guest
    }
    
    public class CurrentUser
    {
        private CurrentUser()
        {
        }

        private static CurrentUser _user;
        public UserRoles Role { get; private set; }
        
        public static CurrentUser Get()
        {
            if (_user == null)
            {
                _user = new CurrentUser();
            }

            return _user;
        }

        public void SetRole(UserRoles role)
        {
            Role = role;
        }
    }
}