using Newtonsoft.Json;
namespace NorthernLight.Auth.Domain.Models.Auth
{
    public class GoogleDeserializedUserInfoResult
    {
        public string Email { get; set; }
        [JsonProperty("family_name")]
        public string FamilyName { get; set; }
        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        public string Id { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public bool VerifiedEmail { get; set; }
    }
}
