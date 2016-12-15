////////////////////////////////////////////////////////////////////////////////////////
//  Utils.cs : File defines a class that contains simple utility methods.             //
//  ver 1.0                                                                           //  
//  Language:    C#                                                                   //
//  Application: Table Fable - Tables in mathematics made easy                        //
//  Author:      Infinite Loop Apps - iMagic Ventures Company                         //
//  (c)Copyright Infinite Loop Apps - iMagic Ventures Company                         //
////////////////////////////////////////////////////////////////////////////////////////

namespace Tables
{
    #region Class Utils 

    class Utils
    {

        #region Methods

        #region ValidateProduct

        /// <summary>
        /// Accepts a Product object and validates the multiplication.
        /// </summary>
        /// <param name="Answer"></param>
        /// <returns></returns>
        internal static bool ValidateProduct(Product Answer)
        {
            bool correctAnswer; // Returns true if multiplication is valid.
            int productVal = Answer.Multiplier * Answer.Multiplicand;
            correctAnswer = (Answer.ProductValue == productVal);

            return correctAnswer;
        }

        #endregion 

        #endregion

    } 

    #endregion
}
    

        