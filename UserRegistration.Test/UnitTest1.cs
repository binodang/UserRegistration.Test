using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UserRegistration.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Check_If_User_Added_Is_Unique()
        {
            // Arrange
            var user1 = new UserRegistration.classes.User("Josef", "12@34567a", "test@Gmail.com");
            var user2 = new UserRegistration.classes.User("Josef", "12@34567a", "test@Gmail.com");
            var userBank = new UserRegistration.classes.UserBank();

            // Act
            userBank.AddUser(user1);

            // Assert
            var exception = Assert.ThrowsException<ArgumentException>(() => userBank.AddUser(user2));
            Assert.AreEqual("Username already exists.", exception.Message);
        }

        [DataTestMethod]
        [DataRow("JagÄrÖver20Karaktärer1234")]
        [DataRow("4Let")]
        public void Check_If_User_Created_With_Invalid_Username_Throws_Exception(string userName)
        {
            // Arrange & Act
            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User(userName, "pas!sword", "whatever@Gmail.com"));

            // Assert
            Assert.AreEqual("UserName must be between 5 and 20 characters long.", exception.Message);
        }

        [TestMethod]
        public void Check_If_User_Has_Right_Formatting_For_Email()
        {
            // Arrange & Act
            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User("Josef", "12345@67aa", "DåligEmail"));

            // Assert
            Assert.AreEqual("Email must not be null and must end with '@Gmail.com'.", exception.Message);
        }

        [TestMethod]
        public void Check_If_User_Message_When_Successfull_Works()
        {
            // Act
            var userbank = new UserRegistration.classes.UserBank();
            var user = new UserRegistration.classes.User("UserTest", "Jagheterst@efan1", "Stefan.kureljusic@Gmail.com");

            // Arrange
            string success = userbank.AddUser(user);

            // Assert
            Assert.AreEqual($"{user.UserName} has been sucessfully created!", success);
        }

        [DataTestMethod]
        [DataRow("JagRättLängdMenUtanSpecialTecken")]
        [DataRow("KortM!")]
        [DataRow("Nospec")]
        public void Check_If_Added_Users_Password_Contains_The_Right_Formatting(string password)
        {
            // Arrange
            var userbank = new UserRegistration.classes.UserBank();

            // Act and Arrange
            var exception = Assert.ThrowsException<ArgumentException>(() => new UserRegistration.classes.User("Josef", password, "stefan@Gmail.com"));

            // Assert
            Assert.AreEqual("Password length must be at least 8 characters and contain at least one special character.", exception.Message);
        }
    }
}
