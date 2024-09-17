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
        PrivateKey = hellman.initPrivateKey(encrypt.GetLetters());
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
            return encrypt.encodeKey(message, SharedKey).ToString();
        }
        else { return "Invalid or empty entrys"; }
    }
    public string DecryptMessage(string message)
    {
        if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(SharedKey))
        {
            return encrypt.decodeKey(message, SharedKey).ToString();
        }
        else { return "Invalid or empty entrys"; } 
    }
}