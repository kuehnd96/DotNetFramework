using DK.Framework.Core;
using System;
using System.Windows.Input;

namespace DK.Framework.Store.Commands
{
    /// <summary>
    /// Implementation of <see cref="ICommand"/> that takes delegates.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        Func<object, bool> _canExecute;
        Action<object> _executeAction;
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a command that can or can't be executed.
        /// </summary>
        /// <param name="executeAction">The <see cref="Action"/> to run when the command is executed. Cannot be null.</param>
        /// <param name="canExecute">The <see cref="Func"/> to run to check whether this command can execute.</param>
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            Requires.IsNotNull(executeAction, "Execute action is null.");
            
            _executeAction = executeAction;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Creates a command that can always be executed.
        /// </summary>
        /// <param name="executeAction">The <see cref="Action"/> to run when the command is executed. Cannot be null.</param>
        public DelegateCommand(Action<object> executeAction)
            : this(executeAction, null)
        {
        }

        /// <summary>
        /// Checks whether this command can execute.
        /// </summary>
        /// <param name="parameter">The parameter used to check execution.</param>
        /// <returns>True if the command can run; Otherwise false.</returns>
        public bool CanExecute(object parameter)
        {
            bool result = true;
            Func<object, bool> canExecuteHandler = _canExecute;

            if (canExecuteHandler != null)
            {
                result = canExecuteHandler(parameter);
            }

            return result;
        }

        /// <summary>
        /// Raises the event that checks whether this command can execute.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChanged;

            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Executes this command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
