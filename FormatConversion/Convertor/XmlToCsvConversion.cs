using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormatConversion.Enums;
using System.IO;

namespace FormatConversion.Convertor
{
    public class XmlToCsvConversion : ConversionBase
    {
        /// <summary>
        /// Create the XmlToCsvConversion Object
        /// </summary>
        /// <param name="path"> The path store the input file and output file</param>
        /// <param name="FileName"> The output file name will be same as input file name</param>
        public XmlToCsvConversion(string path, string FileName) :
            this(path, FileName, FileName)
        {
        }

        /// <summary>
        /// Create the XmlToCsvConversion Object
        /// </summary>
        /// <param name="path"> The path store the input file and output file</param>
        /// <param name="inputFileName"></param>
        /// <param name="outputFileName"></param>
        public XmlToCsvConversion(string path, string inputFileName, string outputFileName) :
            base(path, inputFileName, outputFileName, ".xml", ".csv")
        {
        }

        /// <summary>
        /// To execute the conversion of student enrollment information from xml to csv
        /// </summary>
        public override void Execute()
        {
            this.stringbuilder = new StringBuilder();
            // Get the full path of the input and output file
            this.inputfullpath = path + @"\" + this.inputFileName + this.inputFileFormat;
            this.outputfullpath = path + @"\" + this.outputFileName + this.outputFileFormat;

            // To execute the actual conversion for the problem. 
            this.Problem.Execute(this.stringbuilder, this.inputfullpath);

            //            
            StreamWriter wr = new StreamWriter(this.outputfullpath, false);
            wr.WriteLine(this.stringbuilder.ToString());
            wr.Close();

        }

    }
}
