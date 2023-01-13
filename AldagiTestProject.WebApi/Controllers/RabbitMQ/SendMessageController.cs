using Application.Queries.Region;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Infrastructure;

namespace WebApi.Controllers.RabbitMQ;

public class SendMessageController : ApiControllerBase
{
    [HttpPost("PostMessage")]
    public void PostMessage(string message)
    {
        Send.SendMessage(message);
    }

}
