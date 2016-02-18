using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InkRecordAndPlayBack
{
    public class DelegateCommand:ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;
        public DelegateCommand(Action<object> execute)
        {
            this.execute = execute;
        }
        public DelegateCommand(Action<object> execute,Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (this.canExecute != null)
            {
                return this.CanExecute(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
