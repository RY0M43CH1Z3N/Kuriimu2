using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Kuriimu.ViewModels
{
    class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ShellViewModel()
        {
            DisplayName = "Kuriimu";
            OpenButton();
        }

        public void OpenMenu()
        {
            ActivateItem(new TextEditorViewModel { DisplayName = "Opened from Menu!" });
        }

        public void OpenButton()
        {
            ActivateItem(new TextEditorViewModel());
        }

        public void CloseItem(TextEditorViewModel vm)
        {
            vm.TryClose();
        }
    }
}
