using TextEncryptorAndDecryptor;

namespace TextEncryptorAndDecryptorTest
{
    public class CaesarCipherBreakerTest
    {
        private CaesarCipherBreaker caesarCipherBreaker;

        [SetUp]
        public void Init()
        {
            caesarCipherBreaker = new CaesarCipherBreaker();
        }

        [Test]
        public void GetDecrypts_TextIsEmpty_ReturnEmptyList()
        {
            // Arrange
            var text = string.Empty;

            // Act
            var result = caesarCipherBreaker.GetDecrypts(text);

            // Assert
            Assert.IsFalse(result.Any());
        }

        [TestCase("Text1")]
        [TestCase("Ala ma kota")]
        [TestCase("I like cats and dogs")]
        public void GetDecrypts_TextIsNotEmpty_ReturnListOf26Elements(string text)
        {
            // Arrange

            // Act
            var result = caesarCipherBreaker.GetDecrypts(text);

            // Assert
            Assert.IsTrue(result.Any());
            Assert.IsTrue(result.Count() == 26);
        }

        [Test]
        public void GetDecrypts_TextIsNotEmpty_ReturnListOfPossibleTextDecipherments()
        {
            // Arrange
            var text = "E hega ywpo wjz zkco";
            var expected = GetExpectedList();

            // Act
            var result = caesarCipherBreaker.GetDecrypts(text);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        private List<string> GetExpectedList()
        {
            return new List<string>()
            {
                "E hega ywpo wjz zkco",
                "D gdfz xvon viy yjbn",
                "C fcey wunm uhx xiam",
                "B ebdx vtml tgw whzl",
                "A dacw uslk sfv vgyk",
                "Z czbv trkj reu ufxj",
                "Y byau sqji qdt tewi",
                "X axzt rpih pcs sdvh",
                "W zwys qohg obr rcug",
                "V yvxr pngf naq qbtf",
                "U xuwq omfe mzp pase",
                "T wtvp nled lyo ozrd",
                "S vsuo mkdc kxn nyqc",
                "R urtn ljcb jwm mxpb",
                "Q tqsm kiba ivl lwoa",
                "P sprl jhaz huk kvnz",
                "O roqk igzy gtj jumy",
                "N qnpj hfyx fsi itlx",
                "M pmoi gexw erh hskw",
                "L olnh fdwv dqg grjv",
                "K nkmg ecvu cpf fqiu",
                "J mjlf dbut boe epht",
                "I like cats and dogs",
                "H khjd bzsr zmc cnfr",
                "G jgic ayrq ylb bmeq",
                "F ifhb zxqp xka aldp",
            };
        }
    }
}
