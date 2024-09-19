# SimpleEncrypt
**SimpleEncrypt** is a lightweight .NET library that implements symmetric encryption using a Diffie-Hellman key exchange. It allows two parties to securely encrypt and decrypt messages by generating a shared key.

## Installation:
To integrate SimpleEncrypt into your project, you can install the NuGet package using either the NuGet Package Manager Console or the .NET CLI.

## Usage:
### Example of Using EncryptManager
The EncryptManager class handles key generation, key exchange, and message encryption/decryption.

**Example**:

```csharp
using SimpleEncrypt;
class Program
{
	static void Main(string[] args)
        {
        	// Create two instances of EncryptManager (e.g., for two communication partners)
                EncryptManager encrypt = new EncryptManager(1024); // Key length in charakters

                // User1 sends their public key to User2 and vice versa
                string publicKey= encrypt.GetPublicKey();

		//Implement a function to get the public key of user 2 e.g with TcpClient
		//In this Example we just create a new EncryptManager to Simulate a second user
		EncryptManager user2 = new EncryptManager(1024);
		string publicKeyUser2 = user2.GetPublicKey(); 

        	// Initialize the shared key on both sides
        	encrypt.InitSharedKey(publicKeyUser2);

        	// Encrypt a message (from User1 to User2)
        	string message = "Secret message";
        	string encryptedMessage = encrypt.EncryptMessage(message);
        	Console.WriteLine($"Encrypted Message: {encryptedMessage}");

        	// Decrypt the message (on User2's side)
        	string decryptedMessage = encrypt.DecryptMessage(encryptedMessage);
        	Console.WriteLine($"Decrypted Message: {decryptedMessage}");
    	}
}
```

## Key Features:
- **EncryptManager(int keyLength)**: Initializes the key generator with the specified key length (e.g., 1024 as Array Length ).
- **GetPublicKey()**: Retrieves the public key that can be shared with the communication partner.
- **InitSharedKey(string partnerPublicKey)**: Initializes the shared key using the partner's public key.
- **EncryptMessage(string message)**: Encrypts a message using the shared key.
- **DecryptMessage(string message)**: Decrypts a received message using the shared key.

## Key Exchange and Message Encryption Example
Two parties (e.g., user1 and user2) generate their own private and public keys.
The public keys are exchanged between the two parties.
Each party initializes the shared key using the public key of the other party.
Now both parties can securely encrypt and decrypt messages using the shared key.

## Requirements:
**.NET 8.0**

## License
This project is licensed under the MIT License. See the LICENSE file for details.

