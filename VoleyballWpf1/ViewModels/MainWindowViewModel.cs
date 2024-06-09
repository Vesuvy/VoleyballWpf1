using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VoleyballWpf1.Infrastructure.Commands;
using VoleyballWpf1.ViewModels.Base;

namespace VoleyballWpf1.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region ЗАГОЛОВОК ОКНА

        private string _Title = "Организация Турниров По Волейболу";
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        #region КОМАНДЫ

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}
