using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace API_TESTER_UI.ViewModels
{
    public class MainNavigationBarViewModel : ViewModelBase
    {

        public ICommand NavigateApiChoiceCommand { get; }
        public ICommand NavigateUserManagementCommand { get; }

        public MainNavigationBarViewModel()
        {
            //NavigateApiChoiceCommand = new NavigationCommands();
        }

    }
}
