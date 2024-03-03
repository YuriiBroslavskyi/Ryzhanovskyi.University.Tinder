using Newtonsoft.Json;


namespace Ryzhanovskiy.University.Tinder.Core.Services
{
    public partial class GoogleAuthService
    {
        public class TokenResult
            {
                [JsonProperty("access_token")]
                public string AccessToken { get; set; }

                [JsonProperty("expepires_in")]
                public string ExperisIn { get; set; }

                [JsonProperty("scope")]
                public string Scope { get; set; }

                [JsonProperty("token_type")]
                public string TokenType { get; set; }
           
                [JsonProperty("refresh_token")]
                public string RefreshToken { get; set; }

            }
    }


}
