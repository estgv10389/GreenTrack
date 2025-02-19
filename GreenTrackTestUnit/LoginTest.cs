using GreenTrackTestUnit.Helper;

namespace GreenTrackTestUnit
{
    [TestFixture, NonParallelizable]
    public class LoginTest : BaseTest
    {
        [Test, Order(1)]
        public void LoginStep1TestUnit()
        {
            // Arrange
            var email = "joao@example.com";
            var password = "minhasenha123";

            // Act
            var emailField = FindUIElement("GTEmail");
            emailField.SendKeys(email);
            var passwordField = FindUIElement("GTPassword");
            passwordField.SendKeys(password);
            var loginButton = FindUIElement("GTLogin");
            loginButton.Click();

            // Wait for login to complete
            System.Threading.Thread.Sleep(5000); // Wait for 5 seconds

            // Assert
            var completeInformationElement = FindUIElement("GTCompleteInformation");
            if (completeInformationElement.Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test, Order(2)]
        public void LoginStep2TestUnit()
        {
            // Arrange
            string targetEmission = "100";
            DateTime deadline = new DateTime(2023, 12, 31, 23, 59, 59); ;
            string description = "My goal";

            // Act
            var targetEmissionField = FindUIElement("GTTargetEmission");
            targetEmissionField.SendKeys(targetEmission);
            var deadlineField = FindUIElement("GTDeadline");
            deadlineField.SendKeys(deadline.ToString());
            var descriptionField = FindUIElement("GTDescription");
            descriptionField.SendKeys(description);
            var confirmButton = FindUIElement("GTConfirm");
            confirmButton.Click();

            // Wait for confirmation to complete
            System.Threading.Thread.Sleep(5000); // Wait for 5 seconds
            var completeInformationElement = FindUIElement("GTHomePage");
            if (completeInformationElement.Displayed)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
