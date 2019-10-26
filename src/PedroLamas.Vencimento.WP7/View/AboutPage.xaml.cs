using Cimbalino.Phone.Toolkit.Extensions;
using Microsoft.Phone.Controls;

namespace PedroLamas.Vencimento.View
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            this.ResetLanguageWithCurrentCulture();

            InitializeComponent();
        }
    }
}