using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalXTest
{
    public class FullName : IComparable<FullName>
    {
        public string LastName { get; private set; }
        public string[] GivenNames { get; private set; }

        /// <summary>
        /// Constructs FullName Object. Uses last element of array of names as last name.
        /// </summary>
        /// <param name="_names">Array of all names (including last name)</param>
        public FullName(string[] _names)
        {
            LastName = _names[_names.Length - 1];
            Array.Resize<string>(ref _names, _names.Length - 1);
            GivenNames = _names;
        }

        /// <summary>
        /// Constructs FullName Object. For last name only, don't include a list of given names.
        /// </summary>
        /// <param name="_lName">Last Name</param>
        /// <param name="_gNames">Array of other given names</param>
        public FullName(string _lName, string[] _gNames = null)
        {
            LastName = _lName;
            GivenNames = _gNames;
            if (GivenNames == null)
            {
                GivenNames = new string[0];
            }
        }

        /// <summary>
        /// Compiles object into readable string
        /// </summary>
        /// <returns>"[givenName0] [givenName1] ... [lastName]"</returns>
        public override string ToString()
        {
            string compiledName = "";
            foreach (string name in GivenNames)
                compiledName += name + " ";
            compiledName += LastName;

            return compiledName;
        }

        public int CompareTo(FullName other)
        {
            int comparedName = this.LastName.CompareTo(other.LastName);
            if (comparedName != 0)
            {
                return comparedName;
            }
            else
            {
                //loop through, comparing given names and returning if a difference is found
                //stops when the index exceeds the length of the smallest list of given names
                int nameIndex = 0;
                while (nameIndex < this.GivenNames.Length &&
                    nameIndex < other.GivenNames.Length)
                {
                    comparedName = this.GivenNames[nameIndex].CompareTo(other.GivenNames[nameIndex]);
                    if (comparedName != 0)
                        return comparedName;
                    nameIndex++;
                }
                //the given names were found to be equal up until the length of the smallest list of given names
                //the smaller list of names precedes the other
                return this.GivenNames.Length - other.GivenNames.Length;
            }
        }
    }
}
