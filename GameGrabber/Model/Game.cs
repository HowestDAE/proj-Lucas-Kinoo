using Newtonsoft.Json;
using System.Linq;

namespace GameGrabber.Model
{
    internal class Game
    {
        public string Title
        {
            get
            {
                // Most titles are int the format "Title (Store) givaway"
                // We only want the title, so we remove the rest
                return TitleRaw?.Split('(')?.First()?.Trim() ?? TitleRaw;
            }
        }

        [JsonProperty(PropertyName = "title")]
        private string TitleRaw { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string ImageUrl { get; }
    }
}
