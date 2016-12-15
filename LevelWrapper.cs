///////////////////////////////////////////////////////////////////////////////
//  LevelWrapper.cs : File defines a wrapper class for level of difficulty.  // 
//  ver 1.0                                                                  //  
//  Language:    C#                                                          //
//  Application: Table Fable - Tables in mathematics made easy               //
//  Author:      Infinite Loop Apps - iMagic Ventures Company                //
//  (c)Copyright Infinite Loop Apps - iMagic Ventures Company                //
///////////////////////////////////////////////////////////////////////////////

namespace Tables
{
    #region Class LevelWrapper

    /// <summary>
    /// Wrapper class for level of difficulty.
    /// </summary>
    internal class LevelWrapper
    {
        #region Private Variables

        private Levels levelValue = Levels.Easy;   // Level of difficulty

        #endregion 

        #region Properties

        #region LevelValue

        /// <summary>
        /// Gets/Sets value of the difficulty level
        /// </summary>
        internal Levels LevelValue
        {
            get
            {
                return this.levelValue;
            }

            set
            {
                this.levelValue = value;
            }
        }

        #endregion

        #endregion
    }

    #endregion 
}
