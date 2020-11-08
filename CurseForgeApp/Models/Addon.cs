using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using CurseForgeApp.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurseForgeApp.Models
{
    public static class AddonService
    {
        static readonly HttpClient Client = new HttpClient();

        public static async Task<IEnumerable<Addon>> GetAddonsAsync(Game game = Game.Minecraft, int sectionId = 6, int categoryId = 0, int pageSize = 30, string filter = default)
        {
            string url = string.Format("https://addons-ecs.forgesvc.net/api/v2/addon/search?" +
                "gameId={0}&sectionId={1}&categoryId={2}&pageSize={3}&isSortDecending=1&index=0",
                (int)game, sectionId, categoryId, pageSize);

            if (!string.IsNullOrEmpty(filter))
                url = string.Concat(url, "&searchFilter=", HttpUtility.UrlEncode(filter));

            var result = new List<Addon>();

            try
            {
                string json = await Client.GetStringAsync(url);
                JArray array = JArray.Parse(json);

                foreach (var obj in array.Values<JObject>())
                    result.Add(obj.ToObject<Addon>());
            }
            catch { }

            return result;
        }

        public static AddonUserControl GetControl(this Addon a)
            => new AddonUserControl(a);
    }

    public class Addon
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("authors")]
        public IEnumerable<Author> Authors { get; set; }

        [JsonProperty("attachments")]
        public IEnumerable<Attachment> Attachments { get; set; }

        [JsonProperty("websiteUrl")]
        public string WebsiteUrl { get; set; }

        [JsonProperty("gameId")]
        public Game Game { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("defaultFileId")]
        public long DefaultFileId { get; set; }

        [JsonProperty("downloadCount")]
        public long DownloadCount { get; set; }

        [JsonProperty("categories")]
        public IEnumerable<Category> Categories { get; set; }

        [JsonProperty("primaryCategoryId")]
        public long PrimaryCategoryId { get; set; }

        [JsonProperty("status")]
        public AddonStatus Status { get; set; }

        [JsonProperty("categorySection")]
        public CategorySection CategorySection { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public class CategorySection
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("packageType")]
        public int PackageType { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("initialInclusionPattern")]
        public string InitialInclusionPattern { get; set; }

        [JsonProperty("extraIncludePattern", NullValueHandling = NullValueHandling.Include)]
        public string ExtraIncludePattern { get; set; }
    }

    public enum Game
    {
        Minecraft = 432
    }

    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("userId", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        [JsonProperty("twitchId", NullValueHandling = NullValueHandling.Ignore)]
        public long? TwitchId { get; set; }
    }


    public enum AddonStatus
    {
        Unknown4 = 4,
    }

    public class Attachment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isDefault")]
        public bool IsDefault { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("status")]
        public AttachmentStatus Status { get; set; }
    }

    public enum AttachmentStatus
    {
        Unknown1 = 1
    }

    public class Category
    {
        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("parentId")]
        public long ParentId { get; set; }

        [JsonProperty("rootId")]
        public long RootId { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }
    }
}
