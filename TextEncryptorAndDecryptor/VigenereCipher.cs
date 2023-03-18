using System.Text;

namespace TextEncryptorAndDecryptor;

public class VigenereCipher : CipherBase<string>
{
    /// <summary>
    /// Encrypts the given text using a key
    /// </summary>
    /// <param name="text"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public override string Encrypt(string text, string key)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            return string.Empty;

        StringBuilder result = new StringBuilder();
        text = text.ToUpper();
        key = GenerateKey(text.Length, key.ToUpper());

        for (int i = 0; i < text.Length; i++)
        {
            // if is not letter and to result
            if (!char.IsLetter(text[i]))
            {
                result.Append(text[i]);
                continue;
            }

            // converting in range 0-25
            int letter = (text[i] + key[i]) % numberOfLetters;

            // convert into alphabets(ASCII)
            letter += 'A';

            result.Append((char)(letter));
        }
        return result.ToString();
    }

    /// <summary>
    /// Decrypts the given text using a key
    /// </summary>
    /// <param name="text"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public override string Decrypt(string text, string key)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(key))
            return string.Empty;

        StringBuilder result = new StringBuilder();

        text = text.ToUpper();
        key = GenerateKey(text.Length, key.ToUpper());

        for (int i = 0; i < text.Length && i < key.Length; i++)
        {
            // if is not letter and to result
            if (!char.IsLetter(text[i]))
            {
                result.Append(text[i]);
                continue;
            }

            // converting in range 0-25
            int letter = (text[i] - key[i] + numberOfLetters) % numberOfLetters;

            // convert into alphabets(ASCII)
            letter += 'A';

            result.Append((char)(letter));
        }
        return result.ToString();
    }

    /// <summary>
    /// Generates the key in a cyclic until key length isn't equal text length
    /// </summary>
    /// <param name="textLength"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    private static string GenerateKey(int textLength, string key)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; ; i++)
        {
            if (key.Length == i)
                i = 0;

            if (result.Length == textLength)
                break;

            result.Append(key[i]);
        }
        return result.ToString();
    }
}
