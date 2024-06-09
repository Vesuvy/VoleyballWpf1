using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoleyballWpf1.Infrastructure.Commands.Base;

namespace VoleyballWpf1.Infrastructure.Commands
{
    // как RelayCommand
    internal class LambdaCommand : Command
    {
        // readonly еще чуууть ускоряет работу приложения
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;
        
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null) 
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute ? invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute(parameter);
    }
}
