using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UserRegistration.Test
{
    // Den här klassen innehåller enhetstester för att validera funktionaliteten i användarregistreringssystemet.
    [TestClass]
    public class UnitTest1
    {
        // Testar att varje nyregistrerad användare måste ha ett unikt användarnamn.
        [TestMethod]
        public void Check_If_User_Added_Is_Unique()
        {
            // Arrange: Skapar två användarobjekt med samma användarnamn och e-postadress för att testa unikheten.
            var user1 = new UserRegistration.classes.User("Luffy", "12@34567a", "test@Gmail.com");
            var user2 = new UserRegistration.classes.User("Luffy", "12@34567a", "test@Gmail.com");
            var userBank = new UserRegistration.classes.UserBank();

            // Act: Försöker lägga till den första användaren i UserBank.
            userBank.AddUser(user1);

            // Assert: Försöker lägga till den andra användaren och förväntar sig ett ArgumentException eftersom användarnamnet redan finns.
            var exception = Assert.ThrowsException<ArgumentException>(() => userBank.AddUser(user2));
            Assert.AreEqual("Username already exists.", exception.Message);
        }

        // Testar att användarnamn måste följa specifika längdkrav.
        [DataTestMethod]
        [DataRow("JagÄrÖver20Karaktärer1234")]
        [DataRow("4Let")]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception(string userName)
        {
            // Arrange & Act: Skapar en ny användare med ett ogiltigt användarnamn och förväntar sig ett ArgumentException.

            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User(userName, "pas!sword", "whatever@Gmail.com"));

            // Assert: Kontrollerar att felmeddelandet matchar förväntningarna.
            Assert.AreEqual("UserName must be between 5 and 20 characters long.", exception.Message);
        }

        // Testar att e-postadresser måste följa ett specifikt format.
        [TestMethod]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act: Försöker skapa en ny användare med en ogiltig e-postadress och förväntar sig ett ArgumentException.

            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User("Luffy", "12345@67aa", "DåligEmail"));

            // Assert: Verifierar att felmeddelandet är korrekt.
            Assert.AreEqual("Email must not be null and must end with '@Gmail.com'.", exception.Message);
        }

        // Testar att ett framgångsrikt meddelande returneras när en användare läggs till korrekt.
        [TestMethod]
        public void Check_If_User_Message_When_Successfull_Works()
        {
            // Act: Skapar en ny användarbank och lägger till en användare.

            var userbank = new UserRegistration.classes.UserBank();
            var user = new UserRegistration.classes.User("UserTest", "JagheterSan@ji1", "Sanji.Onepiece@Gmail.com");

            // Arrange: Försöker lägga till användaren och få ett framgångsmeddelande.

            string success = userbank.AddUser(user);

            // Assert: Kontrollerar att meddelandet som returneras matchar förväntningarna.
            Assert.AreEqual($"{user.UserName} has been sucessfully created!", success);
        }

        // Testar att lösenord måste följa specifika formatkrav.
        [DataTestMethod]
        [DataRow("JagRättLängdMenUtanSpecialTecken")]
        [DataRow("KortM!")]
        [DataRow("Nospec")]
        public void Check_If_Added_Users_Password_Contains_The_Right_Formatting(string password)
        {
            // Arrange: Skapar en ny användarbank.

            var userbank = new UserRegistration.classes.UserBank();

            // Act and Arrange: Försöker skapa en ny användare med ett ogiltigt lösenord och förväntar sig ett ArgumentException.

            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User("Luffy", password, "Sanji.Onepiece@Gmail.com"));

            // Assert: Kontrollerar att felmeddelandet matchar förväntningarna.
            Assert.AreEqual("Password length must be at least 8 characters and contain at least one special character.", exception.Message);
        }
    }
}
