using System.Text.Json.Serialization;

namespace webapi.Kafka;

public class KafkaMessage
{
    [JsonIgnore]
    public Guid Id { get ;set; } = Guid.CreateVersion7();
    public string Text { get; set; } = string.Empty;
}