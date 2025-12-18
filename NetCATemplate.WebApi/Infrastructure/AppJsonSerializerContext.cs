using NetCATemplate.Application.Todos.Get;
using System.Text.Json.Serialization;

namespace NetCATemplate.WebApi.Infrastructure
{
    [JsonSerializable(typeof(List<TodoResponse>))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }
}
