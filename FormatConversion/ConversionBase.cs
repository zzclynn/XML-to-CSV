using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FormatConversion
{
    /// <summary>
    /// Base class for conversion function
    /// </summary>
    public abstract class ConversionBase : Problem
    {
        /// <summary>
        /// Define the conversion problem by the parameters of path, input/output filenames and format
        /// </summary>
        /// <param name="path"></param>
        /// <param name="inputFileName"></param>
        /// <param name="outputFileName"></param>
        /// <param name="inputFileFormat"></param>
        /// <param name="outputFileFormat"></param>
        protected ConversionBase(string path, string inputFileName, string outputFileName,
                                 string inputFileFormat, string outputFileFormat)
        {
            this.path = path;
            this.inputFileFormat = inputFileFormat;
            this.outputFileFormat = outputFileFormat;
            this.inputFileName = inputFileName;
            this.outputFileName = outputFileName;
        }

        /// <summary>
        /// Problem to be converted
        /// </summary>
        public Problem Problem { get; set; }


    }
}
