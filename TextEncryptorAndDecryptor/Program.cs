using DetectLanguage;
using TextEncryptorAndDecryptor;

internal class Program
{
    // Before using Detect Language API client you have to setup your personal API key.
    // You can get it for free by signing up at https://detectlanguage.com
    private const string apiKey = "YOUR API KEY";

    private static async Task Main(string[] args)
    {
        // Caesar Cipher and Vigenere Cipher
        CaesarVigenereCipherMenu();

        // Manual Caesar cipher breaker.
        Console.Write("Podaj tekst zaszyfrowany szyfrem Cezara: ");
        string ciphertext = Console.ReadLine();

        var breaker = new CaesarCipherBreaker();
        var decrypts = breaker.GetDecrypts(ciphertext);

        Console.WriteLine("Możliwe rozszyfrowania:");
        int i = 0;
        foreach (var decrypt in decrypts)
        {
            Console.WriteLine($"{++i}: {decrypt}");
        }

        // Automatic Caesar Cipher Breaker 
        var client = new DetectLanguageClient(apiKey);

        var detectResults = await client.BatchDetectAsync(decrypts.ToArray());

        var best = CaesarCipherBestMatcher.GetBest(decrypts.ToArray(), detectResults);

        Console.WriteLine($"Najlepszy możliwy traf to: " + best);
    }

    private static void CaesarVigenereCipherMenu()
    {
        var caesarCipher = new CaesarCipher();
        var vigenereCipher = new VigenereCipher();

        Console.WriteLine("Wybierz opcję: ");
        Console.WriteLine("1 - Szyfr Cezara");
        Console.WriteLine("2 - Deszyfr Cezara");
        Console.WriteLine("3 - Szyfr Vigenere'a");
        Console.WriteLine("4 - Deszyfr Vigenere'a");
        int option = Convert.ToInt32(Console.ReadLine());
        string text = string.Empty;
        int shift = 0;
        string key = string.Empty;
        string result = string.Empty;

        switch (option)
        {
            case 1:
                Console.WriteLine("Podaj tekst do zaszyfrowania:");
                text = Console.ReadLine();
                Console.WriteLine("Podaj klucz (liczbę):");
                shift = Convert.ToInt32(Console.ReadLine());
                result = caesarCipher.Encrypt(text, shift);
                Console.WriteLine("Zaszyfrowany tekst: " + result);
                break;
            case 2:
                Console.WriteLine("Podaj tekst do odszyfrowania:");
                text = Console.ReadLine();
                Console.WriteLine("Podaj klucz (liczbę):");
                shift = Convert.ToInt32(Console.ReadLine());
                result = caesarCipher.Decrypt(text, shift);
                Console.WriteLine("Odszyfrowany tekst: " + result);
                break;
            case 3:
                Console.WriteLine("Podaj tekst do zaszyfrowania:");
                text = Console.ReadLine();
                Console.WriteLine("Podaj klucz (słowo):");
                key = Console.ReadLine();
                result = vigenereCipher.Encrypt(text, key);
                Console.WriteLine("Zaszyfrowany tekst: " + result);
                break;
            case 4:
                Console.WriteLine("Podaj tekst do odszyfrowania:");
                text = Console.ReadLine();
                Console.WriteLine("Podaj klucz (słowo):");
                key = Console.ReadLine();
                result = vigenereCipher.Decrypt(text, key);
                Console.WriteLine("Odszyfrowany tekst: " + result);
                break;
            default:
                Console.WriteLine("Nieprawidłowa opcja.");
                break;
        }
    }
}