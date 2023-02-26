using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchWalletSDK.Sdk.Models
{
    public partial class AddSupportedNetworkDto
    {
        [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PublicKey { get; set; }

        [Newtonsoft.Json.JsonProperty("networkChain", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public NetworkChain NetworkChain { get; set; }

    }
   
}
