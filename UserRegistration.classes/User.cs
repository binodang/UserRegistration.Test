using System;

namespace UserRegistration.classes
{
    // Klassen 'User' representerar en användare med användarnamn, lösenord och e-postadress.
    public class User
    {
        // Egenskaper för användarens användarnamn, lösenord och e-post. Dessa är publika för läsning men kan bara sättas privat inom klassen.
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        // Konstruktor för att skapa en ny användare. Kräver ett användarnamn, lösenord och e-postadress som input.
        public User(string userName, string password, string email)
        {
            // Validera e-post, användarnamn och lösenord med privata metoder innan de tilldelas.
            ValidateEmail(email);
            ValidateUserName(userName);
            ValidatePassword(password);

            // Tilldelar klassens egenskaper med de validerade värdena.
            UserName = userName;
            Password = password;
            Email = email;
        }

        // Privat metod för att validera e-postadressen. Kastar ett undantag om e-postadressen inte är giltig.
        private void ValidateEmail(string email)
        {
            if (email is null || !email.EndsWith("@Gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Email must not be null and must end with '@Gmail.com'.");
            }
        }

        // Privat metod för att validera användarnamnet. Kastar ett undantag om det inte uppfyller kraven.
        private void ValidateUserName(string userName)
        {
            if (userName is null || userName.Length < 5 || userName.Length > 20)
            {
                throw new ArgumentException("UserName must be between 5 and 20 characters long.");
            }
        }

        // Privat metod för att validera lösenordet. Kastar ett undantag om det inte uppfyller kraven.
        private void ValidatePassword(string password)
        {
            if (password is null || password.Length < 8 || !ContainsSpecialCharacter(password))
            {
                throw new ArgumentException("Password length must be at least 8 characters and contain at least one special character.");
            }
        }

        // Hjälpmetod för att kontrollera om en sträng innehåller minst ett specialtecken.
        private bool ContainsSpecialCharacter(string password)
        {
            foreach (char c in password)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    return true; // Returnerar sant om lösenordet innehåller ett specialtecken.
                }
            }
            return false; // Returnerar falskt om inga specialtecken hittas.
        }
    }
}
