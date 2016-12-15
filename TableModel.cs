//-----------------------------------------------------------------------
// <copyright file="TableModel.cs" Company="iMagic Ventures">
//     Copyright (c) iMagic Ventures.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace Tables
{
    #region 

    /// <summary>
    /// 
    /// </summary>
    internal class TableModel
    {
        #region Private Members

        List<int> digitList = new List<int>(); // Holds a list of table range.
        int pos = 0;                           // Increments or decrements by 10 based on navigation. 

        #endregion

        #region Properties

        #region Digits

        /// <summary>
        /// Holds the dynamic data context for each view.
        /// </summary>
        public ObservableCollection<int> Digits 
        { 
            get; 
            set; 
        }
        #endregion 

        #region MoveNextCommand
        /// <summary>
        /// 
        /// </summary>
        public ICommand MoveNextCommand 
        { 
            get; 
            set; 
        }

        #endregion 

        #region MovePrevCommand

        /// <summary>
        /// 
        /// </summary>
        public ICommand MovePrevCommand 
        {
            get; 
            set; 
        }

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public TableModel(int size)
        {
            MoveNextCommand = new Command(new Action(MoveNext));
            MovePrevCommand = new Command(new Action(MovePrev));

            this.Digits = new ObservableCollection<int>();

            for (int i = 1; i <= size; i++)
            {
                digitList.Add(i);
            }
            this.UpdateItems();
        } 

        #endregion

        #region Methods

        #region MoveNext

        /// <summary>
        /// Moves to next 10 digits for table display.
        /// </summary>
        public void MoveNext()
        {
            pos += 10;

            if (pos > digitList.Count - 10)
                pos = digitList.Count - 10;

            this.UpdateItems();
        }

        #endregion

        #region MovePrev

        /// <summary>
        /// Moves to previous 10 digits for table display.
        /// </summary>
        public void MovePrev()
        {
            pos -= 10;

            if (pos < 0)
                pos = 0;

            this.UpdateItems();
        }
        #endregion 

        #region UpdateItems

        /// <summary>
        /// Update the Collection for each view.
        /// </summary>
        private void UpdateItems()
        {
            this.Digits.Clear();

            foreach (var i in digitList.Skip(pos).Take(10))
            {
                this.Digits.Add(i);
            }

        }

        #endregion 

        #endregion

    }

    #endregion

}
