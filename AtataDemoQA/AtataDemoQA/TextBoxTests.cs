namespace AtataDemoQA
{
    public sealed class TextBoxTests : UITestFixture
    {
        [Test]
        public void CreateSubmitFormTest()
        {
            Go.To<TextBoxPage>()
                .PageTitle.Should.Contain("DEMOQA")
                .UserName.Type("Anna Kanunnikova")
                .UserEmail.Type("test@test.com")
                .CurrentAddress.Type("Portugal")
                .PermanentAddress.Type("USA")
                .ScrollDown()
                .Submit.Click()
                .OutputName.Should.Be("Name:Anna Kanunnikova")
                .OutputEmail.Should.Be("Email:test@test.com")
                .OutputCurrentAddress.Should.Be("Current Address :Portugal")
                .OutputPermanentAddress.Should.Be("Permananet Address :USA");

        }
    }
}


