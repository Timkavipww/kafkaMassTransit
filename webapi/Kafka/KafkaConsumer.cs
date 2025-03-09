namespace webapi.Kafka;

public class KafkaConsumer : IConsumer<KafkaMessage>
{
    public Task Consume(ConsumeContext<KafkaMessage> context)
    {
        var message = context.Message;
        var changedmessage = $"THIS MESSAGE IS ENCRYPTED {message.Text.ToUpper()}";
        Console.WriteLine($"Received: {changedmessage} with id {message.Id}");
        return Task.CompletedTask;
    }
}
