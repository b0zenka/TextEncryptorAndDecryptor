using TextEncryptorAndDecryptor;

namespace TextEncryptorAndDecryptorTest;

public class VigenereCipherTest
{
    private VigenereCipher vigenereCipher;

    [SetUp]
    public void Init()
    {
        vigenereCipher = new VigenereCipher();
    }

    [TestCase("ALA")]
    [TestCase("DONTKONW")]
    [TestCase("ILOVEPROGRAMMING")]
    public void Encrypt_TextIsEmpty_ReturnStringEmpty(string key)
    {
        // Arrange
        var text = string.Empty;

        // Act
        var result = vigenereCipher.Encrypt(text, key);

        // Assert
        Assert.IsTrue(result == string.Empty);
    }

    [TestCase("ALA")]
    [TestCase("DONT KONW")]
    [TestCase("I LOVE PROGRAMMING")]
    public void Encrypt_KeyIsEmpty_ReturnStringEmpty(string text)
    {
        // Arrange
        var key = string.Empty;

        // Act
        var result = vigenereCipher.Encrypt(text, key);

        // Assert
        Assert.IsTrue(result == string.Empty);
    }

    [TestCase("Text1", "Text", "MIUM1")]
    [TestCase("Ala ma kota", "kotek", "KZT WK DSDK")]
    [TestCase("I like cats and dogs", "ILOVEPROGRAMMING", "Q ZDOT QGKS MVQ LZUN")]
    public void Encrypt_TextAndKeyIsCorrect_ReturnEncryptedText(string text, string key, string expected)
    {
        // Arrange

        // Act
        var result = vigenereCipher.Encrypt(text, key);

        // Assert
        Assert.IsTrue(expected.Equals(result));
    }

    [TestCase("Text1", "TextText", "MIUM1")]
    [TestCase("Ala ma kota", "kotekkotekkotek", "KZT WK DSDK")]
    [TestCase("I like cats and dogs", "ILOVEPROGRAMMINGILOVEPROGRAMMING", "Q ZDOT QGKS MVQ LZUN")]
    public void Encrypt_KeyLengthIsLongerThenText_ReturnEncryptedText(string text, string key, string expected)
    {
        // Arrange

        // Act
        var result = vigenereCipher.Encrypt(text, key);

        // Assert
        Assert.IsTrue(expected.Equals(result));
    }

    [TestCase("ALA")]
    [TestCase("DONTKONW")]
    [TestCase("ILOVEPROGRAMMING")]
    public void Decrypt_TextIsEmpty_ReturnStringEmpty(string key)
    {
        // Arrange
        var text = string.Empty;

        // Act
        var result = vigenereCipher.Decrypt(text, key);

        // Assert
        Assert.IsTrue(result == string.Empty);
    }

    [TestCase("ALA")]
    [TestCase("DONT KONW")]
    [TestCase("I LOVE PROGRAMMING")]
    public void Decrypt_KeyIsEmpty_ReturnStringEmpty(string text)
    {
        // Arrange
        var key = string.Empty;

        // Act
        var result = vigenereCipher.Decrypt(text, key);

        // Assert
        Assert.IsTrue(result == string.Empty);
    }

    [TestCase("MIUM1", "Text", "TEXT1")]
    [TestCase("KZT WK DSDK", "kotek", "ALA MA KOTA")]
    [TestCase("Q ZDOT QGKS MVQ LZUN", "ILOVEPROGRAMMING", "I LIKE CATS AND DOGS")]
    public void Decrypt_TextAndKeyIsCorrect_ReturnDecryptedText(string text, string key, string expected)
    {
        // Arrange

        // Act
        var result = vigenereCipher.Decrypt(text, key);

        // Assert
        Assert.IsTrue(expected.Equals(result));
    }

    [TestCase("MIUM1", "TextText", "TEXT1")]
    [TestCase("KZT WK DSDK", "kotekkotekkotek", "ALA MA KOTA")]
    [TestCase("Q ZDOT QGKS MVQ LZUN", "ILOVEPROGRAMMINGILOVEPROGRAMMING", "I LIKE CATS AND DOGS")]
    public void Decrypt_KeyLengthIsLongerThenText_ReturnDecryptedText(string text, string key, string expected)
    {
        // Arrange

        // Act
        var result = vigenereCipher.Decrypt(text, key);

        // Assert
        Assert.IsTrue(expected.Equals(result));
    }
}
