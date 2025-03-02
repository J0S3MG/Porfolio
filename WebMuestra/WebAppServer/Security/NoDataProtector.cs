using Microsoft.AspNetCore.DataProtection;

namespace WebAppServer.Security
{
    public class NoDataProtectionProvider : IDataProtectionProvider
    {
        public IDataProtector CreateProtector(string purpose)
        {
            return new NoDataProtector();
        }

        private class NoDataProtector : IDataProtector
        {
            public byte[] Protect(byte[] plaintext)
            {
                return plaintext; // Sin cifrado
            }

            public byte[] Unprotect(byte[] protectedData)
            {
                return protectedData; // Sin descifrado
            }

            public IDataProtector CreateProtector(string purpose)
            {
                return this;
            }
        }
    }
}
