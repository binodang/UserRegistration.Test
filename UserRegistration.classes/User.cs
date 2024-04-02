using System;

namespace UserRegistration.classes
{
    public class User
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User(string userName, string password, string email)
        {
            ValidateEmail(email);
            ValidateUserName(userName);
            ValidatePassword(password);

            UserName = userName;
            Password = password;
            Email = email;
        }

        private void ValidateEmail(string email)
        {
            if (email is null || !email.EndsWith("@Gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Email must not be null and must end with '@Gmail.com'.");
            }
        }

        private void ValidateUserName(string userName)
        {
            if (userName is null || userName.Length < 5 || userName.Length > 20)
            {
                throw new ArgumentException("UserName must be between 5 and 20 characters long.");
            }
        }

        private void ValidatePassword(string password)
        {
            if (password is null || password.Length < 8 || !ContainsSpecialCharacter(password))
            {
                throw new ArgumentException("Password length must be at least 8 characters and contain at least one special character.");
            }
        }

        private bool ContainsSpecialCharacter(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
