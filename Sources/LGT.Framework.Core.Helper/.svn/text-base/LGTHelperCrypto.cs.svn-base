using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LGT.Framework.Core.Helper
{
    public static class LGTHelperCrypto
    {
        private const string CryptoSymetricKeyComplement = @"Das*93432[[-__2109><</??oi34043))=jh56";
        private const int PasswordIterations = 2; // can be any number
        private const int KeySize = 256; // can be 192 or 128

        private static string PassPhrase
        {
            get { return CryptoSymetricKeyComplement; }
        }

        private static string Saltvalue
        {
            get { return LGTHelperConfiguraton.CryptoSymetricKeyBase; }
        }

        private static string InitVector
        {
            get { return CryptoSymetricKey.Substring(0, 16); }
        }


        private static string CryptoSymetricKey
        {
            get { return string.Format("{0}{1}", CryptoSymetricKeyComplement, LGTHelperConfiguraton.CryptoSymetricKeyBase); }
        }

        public static string Encrypt(string value)
        {
            byte[] keyBytes;
            ICryptoTransform encryptor;
            byte[] cipherTextBytes;

            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            // encoding.
            var initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(Saltvalue);

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            var plainTextBytes = Encoding.UTF8.GetBytes(value);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            using (var password = new Rfc2898DeriveBytes(PassPhrase, saltValueBytes, PasswordIterations))
            {
                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                keyBytes = password.GetBytes(KeySize/8);
            }

            // Create uninitialized Rijndael encryption object.
            using (var symmetricKey = new RijndaelManaged())
            {
                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate encryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            }


            // Define memory stream which will be used to hold encrypted data.
            using (var memoryStream = new MemoryStream())
            {
                // Define cryptographic stream (always use Write mode for encryption).
                using (var cryptoStream = new CryptoStream(memoryStream,
                                                           encryptor,
                                                           CryptoStreamMode.Write))
                {
                    // Start encrypting.
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                    // Finish encrypting.
                    cryptoStream.FlushFinalBlock();

                    // Convert our encrypted data from a memory stream into a byte array.
                    cipherTextBytes = memoryStream.ToArray();

                    // Close both streams.
                    memoryStream.Close();
                    cryptoStream.Close();
                }
            }

            // Convert encrypted data into a base64-encoded string.
            var cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }


        public static string Decrypt(string value)
        {
            byte[] keyBytes;
            byte[] plainTextBytes;
            ICryptoTransform decryptor;
            int decryptedByteCount;

            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            var initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            var saltValueBytes = Encoding.ASCII.GetBytes(InitVector);

            // Convert our ciphertext into a byte array.
           var cipherTextBytes = Convert.FromBase64String(value);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            using (var password = new Rfc2898DeriveBytes(PassPhrase, saltValueBytes, PasswordIterations))
            {
                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                keyBytes = password.GetBytes(KeySize/8);
            }

            // Create uninitialized Rijndael encryption object.
            using (var symmetricKey = new RijndaelManaged())
            {
                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate encryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            }


            // Define memory stream which will be used to hold encrypted data.
            using (var memoryStream = new MemoryStream())
            {
                // Define cryptographic stream (always use Write mode for encryption).
                using (var cryptoStream = new CryptoStream(memoryStream,
                                                           decryptor,
                                                           CryptoStreamMode.Read))
                {
                    // Since at this point we don't know what the size of decrypted data
                    // will be, allocate the buffer long enough to hold ciphertext;
                    // plaintext is never longer than ciphertext.
                    plainTextBytes = new byte[cipherTextBytes.Length];


                    // Start decrypting.
                    decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);


                    // Close both streams.
                    memoryStream.Close();
                    cryptoStream.Close();
                }
            }

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            var plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

            // Return decrypted string.   
            return plainText;
        }
    }
}