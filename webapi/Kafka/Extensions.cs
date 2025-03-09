namespace webapi.Kafka;

public static class Extensions
{
    public static WebApplicationBuilder AddMassTransitKafka(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureKafkaTestOptions(x =>
    {
        x.CreateTopicsIfNotExists = true;
        x.CleanTopicsOnStart = true;
    });

    builder.Services.AddMassTransit(x =>
    {
        x.UsingInMemory();
        

        x.AddRider(rider =>
        {
            rider.AddConsumer<KafkaConsumer>();
            rider.AddProducer<string, KafkaMessage>(TopicNames.TOPICNAME, Configs.producerConfig);
            
            rider.UsingKafka((context, k) =>
            {
                k.Acks = Acks.All;
                k.TopicEndpoint<KafkaMessage>(TopicNames.TOPICNAME, Configs.consumerConfig, e =>
                {
                    e.ConfigureConsumer<KafkaConsumer>(context);
                });
            });
        });
        
    });

        return builder;
    }
}
