
using BuilderPattern.Builders;
using BuilderPattern.Model;

var builder = new MessageBuilder();
var message = new DirectorBuilderMessage(builder);

message.MessageConstruct("json", 1, "key", "header");
var jsonMessage = message.Build();

message.MessageConstruct("xml", 2, "key", "header");
var xmlMessage = message.Build();

Publisher(jsonMessage);
Publisher(xmlMessage);

void Publisher(Message msg) => Console.WriteLine($"Publishing the message: {msg.Body}");