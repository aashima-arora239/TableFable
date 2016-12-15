////////////////////////////////////////////////////////////////////////////////////////
//  TestCase.cs : File defines the class representing a test case                     //
//  ver 1.0                                                                           //  
//  Language:    C#                                                                   //
//  Application: Table Fable - Tables in mathematics made easy                        //
//  Author:      Infinite Loop Apps - iMagic Ventures Company                         //
//  (c)Copyright Infinite Loop Apps - iMagic Ventures Company                         //
////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.ComponentModel;

namespace Tables
{
    #region Class TestCase

    /// <summary>
    /// 
    /// </summary>
    internal class TestCase : INotifyPropertyChanged
    {
        #region Private Members 

        private string remark =" Select an Option";
        private string answer = "?";

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public TestCase()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="question"></param>
        /// <param name="options"></param>
        public TestCase(Product question, List<Option> options)
        {
            this.Question = question;
            this.Options = options;

        }

        #endregion

        #region Properties

        #region Question
        /// <summary>
        /// 
        /// </summary>
        public Product Question 
        { 
            get; 
            set; 
        }
        #endregion 

        #region Options

        /// <summary>
        /// 
        /// </summary>
        public List<Option> Options 
        { 
            get; 
            set; 
        }
        #endregion 

        #region Remark

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set
            {
                if (value != remark)
                {
                    remark = value;
                    RaisePropertyChanged("Remark");
                }
            }
        }
        #endregion

        #region Answer

        /// <summary>
        /// 
        /// </summary>
        public string Answer
        {
            get
            {
                return this.answer;
            }
            set
            {
                if (value != answer)
                {
                    answer = value;
                    RaisePropertyChanged("Answer");
                }
            }
        }
        #endregion 

        #endregion

        #region Events

        #region PropertyChanged

        /// <summary>
        /// 
        /// </summary>
        
       public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region RaisePropertyChanged

       /// <summary>
        /// Invoked when a property changes and updates the view with the value.
        /// </summary>
        /// <param name="propertyName"></param>

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       #endregion 

        #endregion
    }

    #endregion 

}
