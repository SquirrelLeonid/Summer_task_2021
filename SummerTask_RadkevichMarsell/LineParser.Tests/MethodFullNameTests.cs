using NUnit.Framework;
using SummerTask_RadkevichMarsell;
using SummerTask_RadkevichMarsell.fileReading;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LineParser.Tests
{
    public class MethodFullNameTests
    {
        private static readonly string CASES_DIRECTORY = "C:\\Users\\serge\\Desktop\\Summer_task\\SummerTask_RadkevichMarsell\\LineParser.Tests\\lineParser.TestCases";
        private SummerTask_RadkevichMarsell.LineParser lineParser;

        [SetUp]
        public void InitLineParser()
        {
            lineParser = new SummerTask_RadkevichMarsell.LineParser();
        }

        [Test]
        public void Test_SingleClass_SingleMethod()
        {
            var caseFileName = "Case_SingleClass_SingleMethod.cs";
            var testData = ReadSelectedFiles(Path.Combine(CASES_DIRECTORY, caseFileName));

            var parseResult = lineParser.ParseListings(testData);

            var actualMethodFullName = parseResult[0].Name;
            var expectedMethodFullName = @"LineParser.Tests.lineParser.TestCases\Case_SingleClass_SingleMethod\DoSomething";

            Assert.AreEqual(expectedMethodFullName, actualMethodFullName);
        }

        [Test]
        public void Test_SingleClass_ManyMethods()
        {
            var caseFileName = "Case_SingleClass_ManyMethods.cs";

            var testData = ReadSelectedFiles(Path.Combine(CASES_DIRECTORY, caseFileName));

            var parseResult = lineParser.ParseListings(testData);

            var actualMethodFullName = parseResult[2].Name;
            var expectedMethodFullName = @"LineParser.Tests.lineParser.TestCases\Case_SingleClass_ManyMethods\Delete";

            Assert.AreEqual(expectedMethodFullName, actualMethodFullName);
        }

        [Test]
        public void Test_SingleClass_SingleMethodWithBody()
        {
            var caseFileName = "Case_SingleClass_SingleMethodWithBody.cs";

            var testData = ReadSelectedFiles(Path.Combine(CASES_DIRECTORY, caseFileName));

            var parseResult = lineParser.ParseListings(testData);

            var actualMethodFullName = parseResult[0].Name;
            var expectedMethodFullName = @"LineParser.Tests.lineParser.TestCases\Case_SingleClass_SingleMethodWithBody\Compute";

            Assert.AreEqual(expectedMethodFullName, actualMethodFullName);
        }

        [Test]
        public void Test_SingleClassWithProvokeFields_SingleMethod()
        {
            var caseFileName = "Case_SingleClassWithProvokeFields_SingleMethod.cs";

            var testData = ReadSelectedFiles(Path.Combine(CASES_DIRECTORY, caseFileName));

            var parseResult = lineParser.ParseListings(testData);

            var actualMethodFullName = parseResult[0].Name;
            var expectedMethodFullName = @"LineParser.Tests.lineParser.TestCases\Case_SingleClassWithProvokeFields_SingleMethod\DoWork";

            Assert.AreEqual(expectedMethodFullName, actualMethodFullName);
        }

        private List<Listing> ReadSelectedFiles(params string[] selectedFiles)
        {
            var listings = new List<Listing>();
            foreach (string file in selectedFiles)
            {
                var content = new List<string>();
                using (StreamReader reader = new StreamReader(file, Encoding.UTF8))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        content.Add(line);
                        line = reader.ReadLine();
                    }
                    listings.Add(new Listing(file, content));
                }
            }

            return listings;
        }
    }
}