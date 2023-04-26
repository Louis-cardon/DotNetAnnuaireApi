using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DotNetAnnuaireClient.ViewModel;


public class CommandViewModel<T> : ICommand
{

    private readonly Action<T> _executeAction;
    private readonly Predicate<T> _canExecuteAction;

    public CommandViewModel(Action<T> executeAction)
    {
        _executeAction = executeAction;
        _canExecuteAction = null;
    }

    public CommandViewModel(Action<T> executeAction, Predicate<T> canExecuteAction)
    {
        _executeAction = executeAction;
        _canExecuteAction = canExecuteAction;
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        return _canExecuteAction == null ? true : _canExecuteAction((T)parameter);
    }

    public void Execute(object parameter)
    {
        _executeAction((T)parameter);
    }
}
