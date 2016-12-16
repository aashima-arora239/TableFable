/////////////////////////////////////////////////////////////////////////////////////////
//  Command.cs : Commands like next and previous are implemented using this class      // 
//  ver 1.0                                                                            //  
//  Language:    C#                                                                    //
//  Application: Table Fable - Tables in mathematics made easy                         //
/////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Windows.Input;

namespace Tables
{
    #region Command

    /// <summary>
    /// Class implements ICommand interface. The command class is used to track operations like Next, Previous etc.
    /// </summary>
    class Command : ICommand
    {

        #region Private Members

        private Action callBack = null; 

        #endregion

        #region Constructor

        public Command(Action callBack)
        {
            this.callBack = callBack;
        } 

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged; 

        #endregion

        #region Methods

        #region CanExecute

        /// <summary>
        /// Implementation of Interface Method ICommand
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        #endregion 

        #region Execute

        /// <summary>
        /// Implementation of Interface Method ICommand
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.callBack();
        }
        #endregion 

        #endregion
    }

    #endregion 
}

