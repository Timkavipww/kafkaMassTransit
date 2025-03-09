using MassTransit;
using Microsoft.AspNetCore.Mvc;
using webapi.Kafka;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(ITopicProducer<string, KafkaMessage> _producer) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] KafkaMessage message, CancellationToken cts)
    {
        if (message == null)
            return BadRequest("Message content is required");


        await _producer.Produce(Guid.NewGuid().ToString(), new KafkaMessage
        {
            Id = message.Id,
            Text = message.Text
        },cts);

        return Ok(new { message = "Сообщение отправлено!" });
    }

}
