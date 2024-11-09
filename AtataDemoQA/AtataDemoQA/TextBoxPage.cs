using Atata;
using _ = AtataDemoQA.TextBoxPage;

namespace AtataDemoQA
{
    [Url("/text-box")]
    //using _ = TextBoxPage;

    public sealed class TextBoxPage : BasePage<_>

    {
        // public FullNameInput<_> FullName { get; set; }

        [FindById("userName")]
        public TextInput<_> UserName { get; set; }

        [FindById("userEmail")]
        public EmailInput<_> UserEmail { get; set; }

        [FindById("currentAddress")]
        public TextArea<_> CurrentAddress { get; set; }

        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddress { get; set; }

        [ScrollTo, FindById("submit")]

        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> OutputName { get; set; }

        [FindById("email")]
        public Text<_> OutputEmail { get; set; }

        [FindByCss("#output  #currentAddress")]
        public Text<_> OutputCurrentAddress { get; set; }

        [FindByCss("#output  #permanentAddress")]
        public Text<_> OutputPermanentAddress { get; set; }

    }


}
