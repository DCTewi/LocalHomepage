using System.Text.Json.Serialization;

namespace LocalHomepage.Models
{
    [JsonSerializable(typeof(NavigationItem))]
    [JsonSourceGenerationOptions(WriteIndented = true)]
    internal partial class JsonSourceContext : JsonSerializerContext
    {
    }
}
