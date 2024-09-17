namespace SimpleEncrypt;

public class EncryptManager
{
    Hellman hellman;
    Encrypter encrypt;
    int[] PrivateKey;
    string PublicKey;
    string SharedKey;
    public EncryptManager(int keyLenght) {
        encrypt = new Encrypter();
        hellman = new Hellman(keyLenght);
        PrivateKey = hellman.initPrivateKey();
        PublicKey = hellman.generatePublicKey(PrivateKey, encrypt.GetLetters());
    }
    public string GetPublicKey() { return PublicKey; }
    public void InitSharedKey(string partnerPublicKey) 
    {
        SharedKey = hellman.getSharedKey(partnerPublicKey, PrivateKey, encrypt.GetLetters());
    }
    public string EncryptMessage(string message)
    {
        if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(SharedKey))
        {
            return new string(encrypt.encodeKey(message, SharedKey));
        }
        else { return message; }
    }
    public string DecryptMessage(string message)
    {
        if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(SharedKey))
        {
            return new string(encrypt.decodeKey(message, SharedKey));
        }
        else { return message; } 
    }
}