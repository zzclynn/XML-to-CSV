using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FormatConversion.Convertor;
using FormatConversion.Problems;

namespace XmltoCsv
{
    class Program
    {
        private static string mainPath = AppDomain.CurrentDomain.BaseDirectory;
        private static XmlToCsvConversion convertor;

        static void Main(string[] args)
        {
            try
            {
                // Test if the input arguments were supplied.
                if (args.Length == 0)
                {
                    Console.WriteLine("Please enter the input xml file name and output csv file name as arguments.");
                    Console.WriteLine("Usage: XmltoCsv <xml input file name> <csv output file name>");
                    return;
                }

                // Test if the input xml file existed in the folder
                if (!File.Exists(mainPath + @"\" + args[0] + ".xml"))
                {
                    Console.WriteLine("Please double check whether your input xml name is \"" + args[0] + 
                                      ".xml\", and make sure copy this file to the folder " + mainPath);
                    return;
                }

                // Initialize the convertor
                if (args.Length < 2)
                {
                    // The output file would use same name as input file name if missed
                    convertor = new XmlToCsvConversion(mainPath, args[0]);
                }
                else
                {
                    convertor = new XmlToCsvConversion(mainPath, args[0], args[1]);
                }

                // Initialize the problem
                StudentEnrollment bomboraAssignment = new StudentEnrollment();

                // Sign the problem to the convertor
                convertor.Problem = bomboraAssignment;

                // Execute the conversion
                convertor.Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Exception: " + e);
            }
            Console.WriteLine("Done!");
            
            

        }
    }
}
