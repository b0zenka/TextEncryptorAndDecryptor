using DetectLanguage;

namespace TextEncryptorAndDecryptor;

public static class CaesarCipherBestMatcher
{
    /// <summary>
    /// Getting best match to language from decrypts using detect result from DetectLanguage
    /// </summary>
    /// <param name="decrypts"></param>
    /// <param name="detectResult"></param>
    /// <returns></returns>
    public static string GetBest(string[] decrypts, DetectResult[][] detectResult)
    {
        Dictionary<string, float> resultDic = new Dictionary<string, float>();

        if (decrypts.Length != detectResult.Length)
            return string.Empty;

        for (int i = 0; i < detectResult.Length; i++)
        {
            foreach (var item in detectResult[i])
            {
                if (item == null || !item.reliable) 
                    continue;

                if (!resultDic.ContainsKey(decrypts[i]))
                    resultDic.Add(decrypts[i], item.confidence);
                else if (resultDic[decrypts[i]] < item.confidence)
                    resultDic[decrypts[i]] = item.confidence;
            }
        }

        return resultDic.OrderByDescending(x => x.Value).First().Key;
    }
}
