using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Auth.Encryption
{
    public interface IEncryption
    {
        string Encypt(string data);
        string Decrypt(string data);
    }
}
