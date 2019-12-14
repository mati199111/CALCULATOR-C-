using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_v1
{
    #region operationType
    /// <summary>
    /// a type of operation the calculator can perform
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// add two velue together
        /// </summary>
        Add,
        /// <summary>
        /// takes one value from another
        /// </summary>
        Minus,
        /// <summary>
        /// divide one number
        /// </summary>
        Divide,
        /// <summary>
        /// muliplies two numbers
        /// </summary>
        Multiply,
        /// <summary>
        /// number pi
        /// </summary>
        Pow2,
        /// <summary>
        /// pow 3
        /// </summary>
        Pow3,
        /// <summary>
        /// sqrt number
        /// </summary>
        SQT,
        /// <summary>
        /// logarithm 2
        /// </summary>
        Logg
    }
    #endregion
}
