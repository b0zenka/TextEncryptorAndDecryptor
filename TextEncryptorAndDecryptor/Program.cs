using TextEncryptorAndDecryptor;

var caesarCipher = new CaesarCipher();
var breaker = new CaesarCipherBreaker();

var vigenereCipher = new VigenereCipher();


Console.Write("Podaj tekst zaszyfrowany szyfrem Cezara: ");
string ciphertext = Console.ReadLine();
var decrypts = breaker.GetDecrypts(ciphertext);

Console.WriteLine("Możliwe rozszyfrowania:");
int i = 0;
foreach (var decrypt in decrypts)
{
    Console.WriteLine($"{++i}: {decrypt}");
}