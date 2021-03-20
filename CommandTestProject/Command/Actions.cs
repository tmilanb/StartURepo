using CommandTestProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandTestProject.Command
{
    public class Actions : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _ex;

        public Actions(Action<object> ex)
        {
            _ex = ex;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _ex.Invoke(parameter);
        }
    }
}
