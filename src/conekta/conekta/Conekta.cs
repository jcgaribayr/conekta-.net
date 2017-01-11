using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conekta
{
    public abstract class Api
    {
        public const string BaseUri = "https://api.conekta.io";
        public static string Version { get; set; }
        public static string Locale { get; set; }
        public static string ApiKey { get; set; }
    }
}
