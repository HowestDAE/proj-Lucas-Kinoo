using Newtonsoft.Json;
using System.Linq;

namespace GameGrabber.Model
{
    internal class Game
    {
        [JsonProperty(PropertyName = "image")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "platforms")]
        public string Platforms { get; set; }

        [JsonProperty(PropertyName = "title")]
        private string TitleRaw { get; set; }

        [JsonProperty(PropertyName = "worth")]
        public string OriginalPrice { get; set; }

        public string Title
        {
            get
            {
                // Most titles are int the format "Title (Store) givaway"
                // We only want the title, so we remove the rest
                return TitleRaw?.Split('(')?.First()?.Trim() ?? TitleRaw;
            }
        }
    }
}
