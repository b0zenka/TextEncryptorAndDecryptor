namespace TextEncryptorAndDecryptor
{
    public abstract class CipherBase<T>
    {
        // number of letters in alphabet(ASCII)
        protected const int numberOfLetters = 26;

        public abstract string Decrypt(string text, T key);

        public abstract string Encrypt(string text, T key);
    }
}