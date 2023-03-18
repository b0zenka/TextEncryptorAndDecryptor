using TextEncryptorAndDecryptor;
var caesarCipher = new CaesarCipher();
var e = caesarCipher.Encrypt("Text1",120);
var de = caesarCipher.Decrypt(e, 120);
Console.WriteLine(e);
Console.WriteLine(de);

e = caesarCipher.Encrypt("Ala ma kota", 400);
de = caesarCipher.Decrypt(e, 400);
Console.WriteLine(e);
Console.WriteLine(de);

e = caesarCipher.Encrypt("I like cats and dogs", -400);
de = caesarCipher.Decrypt(e, -400);
Console.WriteLine(e);
Console.WriteLine(de);

var vigenereCipher = new VigenereCipher();
String str = "Text1";
String key = "text";

String cipher_text = vigenereCipher.Encrypt(str, key);

Console.WriteLine("Ciphertext : "
    + cipher_text + "\n");

Console.WriteLine("Original/Decrypted Text : "
    + vigenereCipher.Decrypt(cipher_text, key));