using Aquilo.MAUI.ViewModels;
using Aquilo.MAUI.Views;

namespace Aquilo.MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StartView), typeof(StartView));
        }
    }
}
