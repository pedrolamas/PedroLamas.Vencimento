using Microsoft.Phone.Controls;
using Cimbalino.Phone.Toolkit.Extensions;

namespace PedroLamas.Vencimento.View
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            this.ResetLanguageWithCurrentCulture();

            InitializeComponent();
        }
    }
}