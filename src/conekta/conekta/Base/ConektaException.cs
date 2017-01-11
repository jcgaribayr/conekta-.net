using Newtonsoft.Json;
using System;

namespace Conekta
{
	public class ConektaException : Exception
	{
        [JsonProperty("message_to_purchaser")]
		public String MessageToPurchaser;
        [JsonProperty("message")]
        new public String Message;
        [JsonProperty("_type")]
        public String Type;

		public ConektaException()
		{
		}

		public ConektaException(string message) : base(message)
		{
			this.Message = message;
		}
	}
}

