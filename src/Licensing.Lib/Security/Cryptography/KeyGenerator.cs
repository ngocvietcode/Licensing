using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;

namespace Licensing.Client.Security.Cryptography
{
    public class KeyGenerator
    {
        private readonly IAsymmetricCipherKeyPairGenerator keyGenerator;


        public KeyGenerator()
            : this(256)
        {
        }


        public KeyGenerator(int keySize)
            : this(keySize, SecureRandom.GetSeed(32))
        {
        }


        public KeyGenerator(int keySize, byte[] seed)
        {
            var secureRandom = SecureRandom.GetInstance("SHA256PRNG");
            secureRandom.SetSeed(seed);

            var keyParams = new KeyGenerationParameters(secureRandom, keySize);
            keyGenerator = new ECKeyPairGenerator();
            keyGenerator.Init(keyParams);
        }


        public static KeyGenerator Create()
        {
            return new KeyGenerator();
        }


        public KeyPair GenerateKeyPair()
        {
            return new KeyPair(keyGenerator.GenerateKeyPair());
        }
    }
}