///////////////////////////////////////////////////////////////////////////////
//  LevelWrapper.cs : File defines class representing option for a question. // 
//  ver 1.0                                                                  //  
//  Language:    C#                                                          //
//  Application: Table Fable - Tables in mathematics made easy               //
///////////////////////////////////////////////////////////////////////////////

namespace Tables
{
    #region Option

    /// <summary>
    /// Class representing option for a question.
    /// </summary>
    class Option
    {

        #region Constructors

        /// <summary>
        /// Creates option of a question
        /// </summary>
        public Option()
        {
        }

        /// <summary>
        /// Creates option of a question
        /// </summary>
        /// <param name="optionValue">Value of the option.</param>
        /// <param name="optionIndex">Index of the option.</param>
        /// <param name="checkStatus">Status of radio button.</param>
        public Option(int optionValue, int optionIndex, bool checkStatus)
        {
            this.OptionValue = optionValue;
            this.OptionIndex = optionIndex;
            this.CheckStatus = checkStatus;
        }

        #endregion

        #region Properties

        #region OptionValue

        /// <summary>
        /// Gets/Sets Value of the option that will display on the UI
        /// </summary>
        public int OptionValue 
        { 
            get; 
            set; 
        }

        #endregion

        #region OptionIndex

        /// <summary>
        /// Gets/Sets index of the option on the UI
        /// </summary>
        public int OptionIndex 
        { 
            get; 
            set; 
        }
        #endregion

        #region CheckStatus

        /// <summary>
        /// Gets/Sets check status of the option on the UI
        /// </summary>
        public bool CheckStatus 
        { 
            get; 
            set; 
        }
        #endregion

        #endregion
    }

    #endregion 

}
