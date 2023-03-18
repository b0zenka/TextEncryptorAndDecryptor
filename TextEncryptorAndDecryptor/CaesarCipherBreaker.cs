namespace TextEncryptorAndDecryptor;

public class CaesarCipherBreaker
{
    private readonly CaesarCipher caesarCipher = new();

    /// <summary>
    /// Returns list of possible text decipherments
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public List<string> GetDecrypts(string text)
    {
        var results = new List<string>();

        if (string.IsNullOrEmpty(text))
            return results;

        for (int shift = 0; shift < 26; shift++)
        {
            string decryptedText = caesarCipher.Decrypt(text, shift);
            results.Add(decryptedText);
        }
        return results;
    }
}
