using JabulaniRubiblueAss.Auth.Encryption;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Auth
{
    public class AuthModules
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IEncryption, Encryption.Encryption>();
        }
    }
}
