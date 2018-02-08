using System;
using GlobalXTest;
using Xunit;

namespace NameSorterTests
{
    public class NameSorterTests
    {

        [Fact]
        public void SameNames_MissingLastGiven()
        {
            FullName name1 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbledore" });
            FullName name2 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Dumbledore" });
            Assert.True(name1.CompareTo(name2) > 0);
        }

        [Fact]
        public void SameNames_OneLetterOff()
        {
            FullName name1 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbledore" });
            FullName name2 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Briana", "Dumbledore" });
            Assert.True(name1.CompareTo(name2) < 0);
        }

        [Fact]
        public void SameNames()
        {
            FullName name1 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbledore" });
            FullName name2 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbledore" });
            Assert.True(name1.CompareTo(name2) == 0);
        }

        [Fact]
        public void DifferentLastNames()
        {
            FullName name1 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbleda" });
            FullName name2 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbledb" });
            Assert.True(name1.CompareTo(name2) < 0);
        }

        [Fact]
        public void SameLastName_OneNoFirst()
        {
            FullName name1 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbledore" });
            FullName name2 = new FullName("Dumbledore");
            Assert.True(name1.CompareTo(name2) > 0);
        }

        [Fact]
        public void SameLastName_BothNoFirst()
        {
            FullName name1 = new FullName("Dumbledore");
            FullName name2 = new FullName("Dumbledore");
            Assert.True(name1.CompareTo(name2) == 0);
        }

        [Fact]
        public void ToString_LastOnly()
        {
            FullName name1 = new FullName("Dumbledore");
            Assert.True(name1.ToString() == "Dumbledore");
        }

        [Fact]
        public void ToString_FullName()
        {
            FullName name1 = new FullName(new string[] { "Albus", "Percival", "Wulfric", "Brian", "Dumbledore" });
            Assert.True(name1.ToString() == "Albus Percival Wulfric Brian Dumbledore");
        }

        [Fact]
        public void CompileNameList()
        {
            var absoluteList = new System.Collections.Generic.List<FullName>();
            for(int i = 0; i < 10; i++)
            {
                absoluteList.Add(new FullName(i.ToString()));
            }
            absoluteList.Add(new FullName(new string[] { "Sterling", "Malory", "Archer" }));
            string testData = @"0
1


2
3
4
5
6

7
8
9

Sterling Malory Archer
";
            var result = NameSorter.CompileNamesListFromString(testData);

            
            Assert.Equal(absoluteList, result);
        }

        [Fact]
        public void CompileOutputTest()
        {
            string expected = @"Alice Within Wonderland
Bert Cunningham
Carol Winters
David Smalls
Reggie";

            var absoluteList = new System.Collections.Generic.List<FullName>();
            absoluteList.Add(new FullName(new string[] { "Alice", "Within", "Wonderland" }));
            absoluteList.Add(new FullName(new string[] { "Bert", "Cunningham" }));
            absoluteList.Add(new FullName(new string[] { "Carol", "Winters" }));
            absoluteList.Add(new FullName(new string[] { "David", "Smalls" }));
            absoluteList.Add(new FullName(new string[] { "Reggie" }));

            var result = NameSorter.CompileOutput(absoluteList);


            Assert.Equal(expected, result);
        }
    }
}
