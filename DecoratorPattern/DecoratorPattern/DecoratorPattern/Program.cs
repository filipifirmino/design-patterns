// See https://aka.ms/new-console-template for more information

using DecoratorPattern.Interfaces;
using DecoratorPattern.Models;
using DecoratorPattern.Services;

INotifier notifier = new EmailNotifier();
notifier = new SmsNotifier(notifier);
notifier = new PushNotifier(notifier);

notifier.send(new Message {Body = "Hello World", Subject = "teste@exemple.com", PhoneNumber = "81 99999-9999"});