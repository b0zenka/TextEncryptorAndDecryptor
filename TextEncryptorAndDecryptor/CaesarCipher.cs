using System.Text;

namespace TextEncryptorAndDecryptor;

public class CaesarCipher : CipherBase<int>
{
    /// <summary>
    /// Encrypts the given text using a shift
    /// </summary>
    /// <param name="text"></param>
    /// <param name="shift"></param>
    /// <returns></returns>
    public override string Encrypt(string text, int shift)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        StringBuilder result = new StringBuilder();

        foreach (char ch in text)
        {
            if (!char.IsLetter(ch))
            {
                result.Append(ch);
                continue;
            }

            // converting shift in range 0-25
            shift %= numberOfLetters;

            var firstLetterOfAlphabet = char.IsUpper(ch) ? 'A' : 'a';

            var letter = (char)((ch - firstLetterOfAlphabet + shift + numberOfLetters) 
                % numberOfLetters + firstLetterOfAlphabet);

            result.Append(letter);
        }

        return result.ToString();
    }

    /// <summary>
    /// Decrypts the given text using a shift
    /// </summary>
    /// <param name="text"></param>
    /// <param name="shift"></param>
    /// <returns></returns>
    public override string Decrypt(string text, int shift)
    {
        // Using encrypt method with negative shift
        return Encrypt(text, -shift);
    }
}
