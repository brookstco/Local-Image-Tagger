using System;
using System.Windows.Input;
using System.Windows.Navigation;

namespace LocalImageTagger
{
    //TODO: Combine with RelayCommand<parameter>?

    /// <summary>
    /// Basic command that runs an Action
    /// Does not require a parameter. I doubt this is a good way, but it ended up working like this, so leaving for now.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action action;

        #endregion

        #region Public Events

        /// <summary>
        /// Fired when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => {};

        #endregion

        #region Constructor

        public RelayCommand(Action relayedAction)
        {
            this.action = relayedAction;
        }


        #endregion

        #region Commands

        /// <summary>
        /// Relay Commands can always execute
        /// </summary>
        /// <returns>True</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute the command's Action
        /// </summary>
        public void Execute(object parameter)
        {
            action();
        }

        #endregion
    }
}
