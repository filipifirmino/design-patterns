 //See https://aka.ms/new-console-template for more information
 
 using StrategyPattern.Models;
 using StrategyPattern.Services;
 using StrategyPattern.Strategies;
 
 var calculatorService = new ShippingService(new EconomyStrategy());
 
    var package = new Package
    {
        Weight = 10,
        Height = 20,
        Width = 15,
        Depth = 5
    };
 
 calculatorService.SetStrategy(new EconomyStrategy());
 var value = calculatorService.Calculate(package);
 
 Console.WriteLine($"The values of shipping this is package: R${value}");
 
 
 
 