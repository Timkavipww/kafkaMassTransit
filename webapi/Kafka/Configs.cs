namespace webapi.Kafka;

public class Configs
{
    public static ConsumerConfig consumerConfig = new ConsumerConfig
    {
        BootstrapServers = "localhost:9092",
        GroupId = "consumer-group",
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = true,
        EnableAutoOffsetStore = true,
    };
    public static ProducerConfig producerConfig = new ProducerConfig
    {
        BootstrapServers = "localhost:9092",
        Acks = Acks.All,
        EnableIdempotence = true,
        MessageTimeoutMs = 1000,
        Partitioner = Partitioner.Consistent,
        CompressionType = CompressionType.Lz4,
        MessageSendMaxRetries = 3,
        RetryBackoffMs = 100,
        LingerMs = 10,
        BatchNumMessages = 100,
        QueueBufferingMaxMessages = 1000,
        QueueBufferingMaxKbytes = 1024,
        AllowAutoCreateTopics = true
    };
}
