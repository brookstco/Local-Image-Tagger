using System;
using System.Windows.Input;
using System.Windows.Navigation;

namespace LocalImageTagger
{
    // Modified from various stackoverflow posts
    //Create an ICommand or RelayCommand and set it to = new RelayCommand(func) or = new RelayCommand(func, condFunc) or = new RelayCommand<Parameter>(func) or = new RelayCommand<Parameter>(func, CondFunc)

    /// <summary>
    /// A command that runs an Action.
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        #region Fields

        /// <summary>
        /// The action to run.
        /// </summary>
        private readonly Action<T> execute = null;

        /// <summary>
        /// The condition for running.
        /// </summary>
        private readonly Func<T, bool> canExecute;
        //Was originally a predicate, but MDSN recommends func instead
        //readonly Predicate<T> canExecute = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="DelegateCommand{T}"/>.
        /// </summary>
        /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute) //public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        ///<summary>
        ///Defines the method that determines whether the command can execute in its current state.
        ///</summary>
        ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        ///<returns>
        ///true if this command can be executed; otherwise, false.
        ///</returns>
        public bool CanExecute(object parameter)
        {
            //Simplified, but kept the old to make it more clear
            //return canExecute == null ? true : canExecute((T)parameter);
            return canExecute == null || canExecute((T)parameter);
        }

        ///<summary>
        ///Occurs when changes occur that affect whether or not the command should execute.
        ///</summary>
        public event EventHandler CanExecuteChanged
        {
            //Apparently can fire more often than needed, so it can cause problems when using CommandManager.RequerySuggested if your canExecute functions are complex
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        ///<summary>
        ///Defines the method to be called when the command is invoked.
        ///</summary>
        ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter)
        {
            execute((T)parameter);
        }

        #endregion
    }
}
