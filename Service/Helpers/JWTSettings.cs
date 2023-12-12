using System;
namespace Service.Helpers
{
	public class JWTSettings
	{
		public string Key { get; set; }
		public string Issuer { get; set; }
		public string ExpireDays { get; set; }
	}
}

