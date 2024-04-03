using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UserRegistration.Test
{
    // Den h�r klassen inneh�ller enhetstester f�r att validera funktionaliteten i anv�ndarregistreringssystemet.
    [TestClass]
    public class UnitTest1
    {
        // Testar att varje nyregistrerad anv�ndare m�ste ha ett unikt anv�ndarnamn.
        [TestMethod]
        public void Check_If_User_Added_Is_Unique()
        {
            // Arrange: Skapar tv� anv�ndarobjekt med samma anv�ndarnamn och e-postadress f�r att testa unikheten.
            var user1 = new UserRegistration.classes.User("Luffy", "12@34567a", "test@Gmail.com");
            var user2 = new UserRegistration.classes.User("Luffy", "12@34567a", "test@Gmail.com");
            var userBank = new UserRegistration.classes.UserBank();

            // Act: F�rs�ker l�gga till den f�rsta anv�ndaren i UserBank.
            userBank.AddUser(user1);

            // Assert: F�rs�ker l�gga till den andra anv�ndaren och f�rv�ntar sig ett ArgumentException eftersom anv�ndarnamnet redan finns.
            var exception = Assert.ThrowsException<ArgumentException>(() => userBank.AddUser(user2));
            Assert.AreEqual("Username already exists.", exception.Message);
        }

        // Testar att anv�ndarnamn m�ste f�lja specifika l�ngdkrav.
        [DataTestMethod]
        [DataRow("Jag�r�ver20Karakt�rer1234")]
        [DataRow("4Let")]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception(string userName)
        {
            // Arrange & Act: Skapar en ny anv�ndare med ett ogiltigt anv�ndarnamn och f�rv�ntar sig ett ArgumentException.

            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User(userName, "pas!sword", "whatever@Gmail.com"));

            // Assert: Kontrollerar att felmeddelandet matchar f�rv�ntningarna.
            Assert.AreEqual("UserName must be between 5 and 20 characters long.", exception.Message);
        }

        // Testar att e-postadresser m�ste f�lja ett specifikt format.
        [TestMethod]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act: F�rs�ker skapa en ny anv�ndare med en ogiltig e-postadress och f�rv�ntar sig ett ArgumentException.

            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User("Luffy", "12345@67aa", "D�ligEmail"));

            // Assert: Verifierar att felmeddelandet �r korrekt.
            Assert.AreEqual("Email must not be null and must end with '@Gmail.com'.", exception.Message);
        }

        // Testar att ett framg�ngsrikt meddelande returneras n�r en anv�ndare l�ggs till korrekt.
        [TestMethod]
        public void Check_If_User_Message_When_Successfull_Works()
        {
            // Act: Skapar en ny anv�ndarbank och l�gger till en anv�ndare.

            var userbank = new UserRegistration.classes.UserBank();
            var user = new UserRegistration.classes.User("UserTest", "JagheterSan@ji1", "Sanji.Onepiece@Gmail.com");

            // Arrange: F�rs�ker l�gga till anv�ndaren och f� ett framg�ngsmeddelande.

            string success = userbank.AddUser(user);

            // Assert: Kontrollerar att meddelandet som returneras matchar f�rv�ntningarna.
            Assert.AreEqual($"{user.UserName} has been sucessfully created!", success);
        }

        // Testar att l�senord m�ste f�lja specifika formatkrav.
        [DataTestMethod]
        [DataRow("JagR�ttL�ngdMenUtanSpecialTecken")]
        [DataRow("KortM!")]
        [DataRow("Nospec")]
        public void Check_If_Added_Users_Password_Contains_The_Right_Formatting(string password)
        {
            // Arrange: Skapar en ny anv�ndarbank.

            var userbank = new UserRegistration.classes.UserBank();

            // Act and Arrange: F�rs�ker skapa en ny anv�ndare med ett ogiltigt l�senord och f�rv�ntar sig ett ArgumentException.

            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User("Luffy", password, "Sanji.Onepiece@Gmail.com"));

            // Assert: Kontrollerar att felmeddelandet matchar f�rv�ntningarna.
            Assert.AreEqual("Password length must be at least 8 characters and contain at least one special character.", exception.Message);
        }
    }
}
