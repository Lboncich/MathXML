using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MathXML
{
    internal static class Functions
    {
        //Read the XML File and convert it Operation Class using LINQ
        internal static IEnumerable<Operation> ParseXmlDocument(string path)
        {
            XDocument xDoc = XDocument.Load(Path.GetFullPath(path));
            IEnumerable<XElement> operations = xDoc.Descendants("Operations").Elements();
            //Linq to convert
            IEnumerable<Operation> xmlOperations = from op in operations
                                                   let description = op.Element("Description").Value.Split(';')
                                                   select new Operation
                                                   {
                                                       UserName = description[0],
                                                       OperationName = description[1],
                                                       Miscellaneous = description[2],
                                                       Value1 = op.Element("Value1").Value,
                                                       Value2 = op.Element("Value2").Value,
                                                   };

            return xmlOperations;
        }

        internal static void ParseJsonDocument(string path)
        {
            throw new NotImplementedException();
            //string json = File.ReadAllText(Path.GetFullPath(path));
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
        }

        //Execute the Operations and output to console
        internal static void ExecuteOperations(IEnumerable<Operation> operations)
        {

            foreach (Operation op in operations)
            {
                try
                {
                    double value1 = Double.Parse(op.Value1);
                    double value2 = Double.Parse(op.Value2);
                    double result;
                    string operationOperator;
                    switch (op.OperationName)
                    {

                        case "SUM":
                            result = value1 + value2;
                            operationOperator = "+";
                            break;
                        case "SUB":
                            result = value1 - value2;
                            operationOperator = "-";
                            break;
                        case "MULTIPLY":
                            result = value1 * value2;
                            operationOperator = "*";
                            break;
                        case "DIVIDE":
                            result = value1 / value2;
                            operationOperator = "/";
                            break;
                        default:
                            Console.WriteLine($"Operation '{op.OperationName}' is invalid");
                            continue;
                    }
                    Console.WriteLine($"{op.UserName} - {op.OperationName} - {op.Value1} {operationOperator} {op.Value2} = {result}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Values are of the incorrect format");

                }
            }
        }
    }
}

