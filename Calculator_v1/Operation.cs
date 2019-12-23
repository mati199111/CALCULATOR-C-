using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_v1
{
    /// <summary>
    /// holds information about a single calculator operation
    /// </summary>
    public class Operation : Form1
    {
        #region Public properites
        /// <summary>
        /// left side operation
        /// </summary>
        public string LeftSide { get; set; }
        // <summary>
        /// right side operation
        /// </summary>
        public string RightSide { get; set; }
        /// <summary>
        /// type of operattion to perform
        /// </summary>
        public OperationType OperationType { get; set; }
        /// <summary>
        /// the inner operation to be performed initially before this operation
        /// </summary>
        public Operation InnerOperation { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public Operation()
        {
            //create empty strings
            this.LeftSide = string.Empty;
            this.RightSide = string.Empty;
        }
        #endregion
    }
}
