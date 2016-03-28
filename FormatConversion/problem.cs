using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatConversion.Enums;

namespace FormatConversion
{
    /// <summary>
    /// Base-class for a file format problem
    /// </summary>
    public abstract class Problem
    {

        /// <summary>
        /// Create a base problem
        /// </summary>
        protected Problem()
        {
        }

        #region public field
        public string columnDelimit { get; set; }
        public string rowDelimit { get; set; }
        public string inputFileName { get; set; }
        public string outputFileName { get; set; }
        public string path { get; set; }
        public string inputFileFormat { get; set; }
        public string outputFileFormat { get; set; }
        public string[] Header { get; set; }
        public string inputfullpath { get; set; }
        public string outputfullpath { get; set; }
        public StringBuilder stringbuilder { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Execute the method for the given parameters
        /// </summary>
        public virtual void Execute()
        {
            this.stringbuilder = new StringBuilder();
        }

        /// <summary>
        /// Execute the method for the given parameters
        /// </summary>
        public virtual void Execute(StringBuilder stringbuilder)
        {
            this.stringbuilder = stringbuilder;
        }

        /// <summary>
        /// Execute the method for the given parameters
        /// </summary>
        public virtual void Execute(StringBuilder stringbuilder, string inputfullpath)
        {
            this.stringbuilder = stringbuilder;
            this.inputfullpath = inputfullpath;
        }

        /// <summary>
        /// Fetch the column delimt by name
        /// </summary>
        /// <param name="columnDelimit"></param>
        /// <returns></returns>
        public virtual string FetchColumnDelimt(ColumnDelimit columnDelimit)
        {
            var delimit = string.Empty;
            switch (columnDelimit)
            {
                case ColumnDelimit.Comma:
                    delimit = ",";
                    break;
                case ColumnDelimit.TabSpace:
                    delimit = "\t";
                    break;
                default:
                    delimit = ",";
                    break;
            }
            return delimit;
        }

        /// <summary>
        ///  Fetch the row delimt by name
        /// </summary>
        /// <param name="RowDelimit"></param>
        /// <returns></returns>
        public virtual string FetchRowDelimt(RowDelimit RowDelimit)
        {
            var delimit = string.Empty;
            switch (RowDelimit)
            {
                case RowDelimit.NewLine:
                    delimit = "\r\n";
                    break;
                case RowDelimit.Space:
                    delimit = " ";
                    break;
                default:
                    delimit = "\r\n";
                    break;
            }
            return delimit;
        }
        #endregion
    }
}
