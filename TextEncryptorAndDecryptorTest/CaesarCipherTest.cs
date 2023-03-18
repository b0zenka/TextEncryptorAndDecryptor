using TextEncryptorAndDecryptor;

namespace TextEncryptorAndDecryptorTest
{
    public class CaesarCipherTest
    {
        private CaesarCipher caesarCipher;

        [SetUp]
        public void Init()
        {
            caesarCipher = new CaesarCipher();
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(-2)]
        public void Encrypt_TextIsEmpty_ReturnStringEmpty(int shift)
        {
            // Arrange
            var text = string.Empty;

            // Act
            var result = caesarCipher.Encrypt(text, shift);

            // Assert
            Assert.IsTrue(result == string.Empty);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(-2)]
        public void Encrypt_TextIsNull_ReturnStringEmpty(int shift)
        {
            // Arrange
            string? text = null;

            // Act
            var result = caesarCipher.Encrypt(text, shift);

            // Assert
            Assert.IsTrue(result == string.Empty);
        }

        [TestCase("Text1")]
        [TestCase("Ala ma kota")]
        [TestCase("I like cats and dogs")]
        public void Encrypt_ShiftIsZero_ReturnGivenText(string text)
        {
            // Arrange
            var shift = 0;

            // Act
            var result = caesarCipher.Encrypt(text, shift);

            // Assert
            Assert.IsTrue(text.Equals(result));
        }

        [TestCase("Text1", 12, "Fqjf1")]
        [TestCase("Ala ma kota", 4, "Epe qe osxe")]
        [TestCase("I like cats and dogs", -4, "E hega ywpo wjz zkco")]
        public void Encrypt_ShiftIsNotZero_ReturnEncryptedText(string text, int shift, string expected)
        {
            // Arrange

            // Act
            var result = caesarCipher.Encrypt(text, shift);

            // Assert
            Assert.IsTrue(expected.Equals(result));
        }

        [TestCase("12 34 56", 12)]
        [TestCase("?/'\";=)(-:", 4)]
        [TestCase("@# \n\t$%^&* !", -4)]
        public void Encrypt_TextHasNoLetter_ReturnGivenText(string text, int shift)
        {
            // Arrange

            // Act
            var result = caesarCipher.Encrypt(text, shift);

            // Assert
            Assert.IsTrue(text.Equals(result));
        }

        [TestCase("Text1", 120, "Junj1")]
        [TestCase("Ala ma kota", 400, "Kvk wk uydk")]
        [TestCase("I like cats and dogs", -400, "Y byau sqji qdt tewi")]
        public void Encrypt_ShiftIsMoreThenNumberOfLetters_ReturnEncryptedText(string text, int shift, string expected)
        {
            // Arrange

            // Act
            var result = caesarCipher.Encrypt(text, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(-2)]
        public void Decrypt_TextIsEmpty_ReturnStringEmpty(int shift)
        {
            // Arrange
            var text = string.Empty;

            // Act
            var result = caesarCipher.Decrypt(text, shift);

            // Assert
            Assert.IsTrue(result == string.Empty);
        }

        [TestCase(5)]
        [TestCase(10)]
        [TestCase(-2)]
        public void Decrypt_TextIsNull_ReturnStringEmpty(int shift)
        {
            // Arrange
            string? text = null;

            // Act
            var result = caesarCipher.Decrypt(text, shift);

            // Assert
            Assert.IsTrue(result == string.Empty);
        }

        [TestCase("Text1")]
        [TestCase("Ala ma kota")]
        [TestCase("I like cats and dogs")]
        public void Decrypt_ShiftIsZero_ReturnGivenText(string text)
        {
            // Arrange
            var shift = 0;

            // Act
            var result = caesarCipher.Decrypt(text, shift);

            // Assert
            Assert.IsTrue(text.Equals(result));
        }

        [TestCase("Fqjf1", 12, "Text1")]
        [TestCase("Epe qe osxe", 4, "Ala ma kota")]
        [TestCase("E hega ywpo wjz zkco", -4, "I like cats and dogs")]
        public void Decrypt_ShiftIsNotZero_ReturnDecryptedText(string text, int shift, string expected)
        {
            // Arrange

            // Act
            var result = caesarCipher.Decrypt(text, shift);

            // Assert
            Assert.IsTrue(expected.Equals(result));
        }

        [TestCase("12 34 56", 12)]
        [TestCase("?/'\";=)(-:", 4)]
        [TestCase("@# \n\t$%^&* !", -4)]
        public void Decrypt_TextHasNoLetter_ReturnGivenText(string text, int shift)
        {
            // Arrange

            // Act
            var result = caesarCipher.Decrypt(text, shift);

            // Assert
            Assert.IsTrue(text.Equals(result));
        }

        [TestCase("Junj1", 120, "Text1")]
        [TestCase("Kvk wk uydk", 400, "Ala ma kota")]
        [TestCase("Y byau sqji qdt tewi", -400, "I like cats and dogs")]
        public void Decrypt_ShiftIsMoreThenNumberOfLetters_ReturnDecryptText(string text, int shift, string expected)
        {
            // Arrange

            // Act
            var result = caesarCipher.Decrypt(text, shift);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
