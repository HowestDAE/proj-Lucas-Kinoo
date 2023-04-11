using Newtonsoft.Json;

namespace GameGrabber.Model
{
    internal class Game
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string ImageUrl { get; set; }
    }
}
