using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_v1
{
    /// <summary>
    /// a type of operation the calculator can perform
    /// </summary>
    public enum OperatorType
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
        Multiply
    }
}
