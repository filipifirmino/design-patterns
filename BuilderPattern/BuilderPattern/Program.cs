
using BuilderPattern.Builders;
using BuilderPattern.Model;

var builder = new MessageBuilder();
var message = new DirectorBuilderMessage(builder);

message.MessageConstruct("json", 1, "key", "header");
var jsonMessage = message.Build();

Publisher(jsonMessage);
void Publisher(Message msg) => Console.WriteLine($"Publishing the message: {msg.Priority}");