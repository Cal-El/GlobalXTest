using System;
using System.IO;
using System.Collections.Generic;

namespace GlobalXTest
{
    public class NameSorter
    {
        public static string SortNamesList(string unsortedListFilePath)
        {
            List<FullName> namesList = CompileNamesListFromString(ReadFileContents(unsortedListFilePath));
            namesList.Sort();
            SaveNamesList(namesList);
            return CompileOutput(namesList);
        }

        public static string ReadFileContents(string path)
        {
            StreamReader sr = new StreamReader(path);
            string rawData = sr.ReadToEnd();
            sr.Close();

            return rawData;
        }

        public static List<FullName> CompileNamesListFromString(string rawData)
        {
            List<FullName> compiledList = new List<FullName>();

            rawData = rawData.Replace('\r', '\n');
            foreach (string line in rawData.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.Contains(" "))
                {
                    //Multiple Names on the Line
                    string[] names = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    compiledList.Add(new FullName(names));
                }
                else
                {
                    //Last Name only
                    compiledList.Add(new FullName(line));
                }
            }

            return compiledList;
        }

        public static void SaveNamesList(List<FullName> list)
        {
            StreamWriter sw = new StreamWriter(@"./sorted-names-list.txt");
            sw.Write(CompileOutput(list));
            sw.Close();
        }

        public static string CompileOutput(List<FullName> list)
        {
            string compiledPrint = "";
            foreach (FullName fn in list)
            {
                compiledPrint += fn.ToString() + "\r\n";
            }
            //remove the last newline
            compiledPrint = compiledPrint.Remove(compiledPrint.Length - 2);

            return compiledPrint;
        }
    }
}
