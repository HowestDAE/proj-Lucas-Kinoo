using Newtonsoft.Json;
using System.Linq;

namespace GameGrabber.Model
{
    internal class Game
    {
        // Set the maximum number of characters for the title
        private readonly int maxTitleLength = 35;

        // Set the maximum number of characters for the platforms
        private readonly int maxPlatformsLength = 45;

        [JsonProperty(PropertyName = "image")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "platforms")]
        public string PlatformsRaw { get; set; }

        public string Platforms
        {
            get
            {
                return TruncateStringWithEllipsis(PlatformsRaw, maxPlatformsLength);
            }
        }

        [JsonProperty(PropertyName = "title")]
        private string TitleRaw { get; set; }

        [JsonProperty(PropertyName = "worth")]
        public string OriginalPrice { get; set; }

        public string Title
        {
            get
            {
                // Most titles are in the format "Title (Store) giveaway"
                // We only want the title, so we remove the rest
                string title = TitleRaw?.Split('(')?.First()?.Trim() ?? TitleRaw;

                return TruncateStringWithEllipsis(title, maxTitleLength);
            }
        }

        /// <summary>
        /// Truncates a string with an ellipsis at the end, with an optional space before the ellipsis.
        /// </summary>
        /// <param name="text">The input string to truncate.</param>
        /// <param name="maxLength">The maximum length of the truncated string.</param>
        /// <returns>The truncated string with an ellipsis at the end.</returns>
        private string TruncateStringWithEllipsis(string text, int maxLength)
        {
            if (text == null)
            {
                return null;
            }

            if (text.Length > maxLength)
            {
                string dots = " ...";
                if (text[maxLength - 1] == ' ')
                {
                    dots = "...";
                }
                text = text.Substring(0, maxLength) + dots;
            }

            return text;
        }
    }
}
