using System;

public static class Crypto
{
    public static string CryptoXOR(string text)
    {
        string result = String.Empty;

        foreach (var simbol in text)
        {
            result += (char)(simbol ^ 42);
        }
        return result;
    }
}