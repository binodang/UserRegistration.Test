using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.classes
{
    public class UserBank // Klassen 'UserBank' agerar som en behållare för användarobjekt.
    {
         
        List<User> Users = new List<User>(); // En lista som håller 'User'-objekt. Privat och inte tillgänglig utanför klassen.

        public string AddUser(User user)  // Metod för att lägga till en ny användare i listan 'Users'.
        {

            if (Users.Exists(u => u.UserName == user.UserName)) // Kontrollerar om användarnamnet redan finns i listan. Kastar undantag om det gör det.
            {
                throw new ArgumentException("Username already exists.");
            }

            Users.Add(user); // Lägger till den nya användaren i listan om användarnamnet inte redan finns.
            return $"{user.UserName} has been sucessfully created!"; // Returnerar ett meddelande som bekräftar att användaren har skapats.
        }
    }
}
