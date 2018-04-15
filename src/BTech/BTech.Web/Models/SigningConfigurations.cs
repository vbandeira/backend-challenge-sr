using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BTech.Web.Models
{
    public class SigningConfigurations
    {
		public SecurityKey Key { get; }
		public SigningCredentials signingCredentials { get; }

		public SigningConfigurations()
		{
			using (var provider = new RSACryptoServiceProvider(2048))
			{
				Key = new RsaSecurityKey(provider.ExportParameters(true));
			}

			signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
		}
    }
}
