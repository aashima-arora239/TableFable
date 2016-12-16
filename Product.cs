///////////////////////////////////////////////////////////////////////////////
//  Product.cs : File defines class representing product of two numbers.     // 
//  ver 1.0                                                                  //  
//  Language:    C#                                                          //
//  Application: Table Fable - Tables in mathematics made easy               //
///////////////////////////////////////////////////////////////////////////////

using System.Collections;

namespace Tables
{
    #region Product

    /// <summary>
    /// Class representing product of two numbers.
    /// </summary>
    public class Product 
    {

        #region Constructor

        public Product() 
        { 
        }

        public Product(int multiplier, int multiplicand, int productValue)
        {
            this.Multiplier = multiplier;
            this.Multiplicand = multiplicand;
            this.ProductValue = productValue;
        } 

        #endregion

        #region Properties

        #region Multiplier

        /// <summary>
        /// Value of the multiplier
        /// </summary>
        public int Multiplier
        {
            get;
            set;
        }

        #endregion

        #region Multiplicand

        /// <summary>
        /// Value of the multiplicand
        /// </summary>
        public int Multiplicand
        {
            get;
            set;
        }

        #endregion

        #region ProductValue

        /// <summary>
        /// Value of the product
        /// </summary>
        public int ProductValue
        {
            get;
            set;
        }

        #endregion

        #endregion

        #region Override Methods

        #region ToString

        /// <summary>
        /// Returns product in Multiplier X Multiplicand = Product format
        /// </summary>
        /// <returns>Returns product as string with fixed format</returns>
        public override string ToString()
        {
            return Multiplier + "  X  " + Multiplicand + "  =  " + ProductValue;
        }

        #endregion

        #region Equals

        /// <summary>
        /// Used for comparing two Product Objects for equality and generate distinct questions.
        /// </summary>
        /// <param name="expectedProductObj">Value being comapred to this product object.</param>
        /// <returns></returns>
        public override bool Equals(object expectedProductObj)
        {
            Product expectedProduct = expectedProductObj as Product;

            if (expectedProduct != null)
            {
                if ((this.Multiplier == expectedProduct.Multiplier && this.Multiplicand == expectedProduct.Multiplicand) ||
                    (this.Multiplier == expectedProduct.Multiplicand && this.Multiplicand == expectedProduct.Multiplier))
                {
                    return true;
                }
            }

            return base.Equals(expectedProductObj);
        }

        #endregion 

        #region GetHashCode

        /// <summary>
        /// Gives hashcode for the object.
        /// </summary>
        /// <returns>Hashcode value.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion GetHashCode

        #endregion

    }

    #endregion 
}

