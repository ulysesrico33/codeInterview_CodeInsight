using CodingChallengeInsight.Business;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        /*
         *TEST REFERENCE
         
        TEST A:{}, score of 1.
        TEST B:{{{}}}, score of 1 + 2 + 3 = 6.
        TEST C:{{},{}}, score of 1 + 2 + 2 = 5.
        TEST D:{{{},{},{{}}}}, score of 1 + 2 + 3 + 3 + 3 + 4 = 16.
        TEST E:{<a>,<a>,<a>,<a>}, score of 1.
        TEST F: {{<ab>},{<ab>},{<ab>},{<ab>}}, score of 1 + 2 + 2 + 2 + 2 = 9.
        TEST G:{{<!!>},{<!!>},{<!!>},{<!!>}}, score of 1 + 2 + 2 + 2 + 2 = 9.
        TEST H:{{<a!>},{<a!>},{<a!>},{<ab>}}, score of 1 + 2 = 3.


             */
        string inputTestA = "{}";
        int resultTestA = 1;
        string inputTestB = "{{{}}}";
        int resultTestB = 6;
        string inputTestC = "{{},{}}";
        int resultTestC = 5;
        string inputTestD = "{{{},{},{{}}}}";
        int resultTestD = 16;

        string inputTestE = "{<a>,<a>,<a>,<a>}";
        int resultTestE = 1;
        string inputTestF = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
        int resultTestF = 9;
        string inputTestG = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
        int resultTestG = 9;
        string inputTestH = "{{<a!>},{<a!>},{<a!>},{<ab>}}";
        int resultTestH = 3;



        Challenge challenge = new Challenge();

        [SetUp]
        public void Setup()
        {
            

        }

        
        [Test]
        public void TestA()
        {
    

            int numberGroups = challenge.getScore(inputTestA);

            Assert.AreEqual(numberGroups,resultTestA);
        }

        [Test]
        public void TestB()
        {
            
            int numberGroups = challenge.getScore(inputTestB);

            Assert.AreEqual(numberGroups,resultTestB);
        }

        [Test]
        public void TestC()
        {
            
            int numberGroups = challenge.getScore(inputTestC);

            Assert.AreEqual(numberGroups, resultTestC);
        }

        [Test]
        public void TestD()
        {
            
            int numberGroups = challenge.getScore(inputTestD);

            Assert.AreEqual(numberGroups, resultTestD);
        }

        [Test]
        public void TestE()
        {
            int numberGroups = challenge.getScore(inputTestE);

            Assert.AreEqual(numberGroups, resultTestE);
        }

        [Test]
        public void TestF()
        {
            
            int numberGroups = challenge.getScore(inputTestF);

            Assert.AreEqual(numberGroups, resultTestF);
        }

        [Test]
        public void TestG()
        {
            
            int numberGroups = challenge.getScore(inputTestG);

            Assert.AreEqual(numberGroups, resultTestG);
        }

        [Test]
        public void TestH()
        {
            
            int numberGroups = challenge.getScore(inputTestH);

            Assert.AreEqual(numberGroups, resultTestH);
        }
    }
}