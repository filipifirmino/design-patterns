# 🎨 Design Patterns - Repositório de Estudos

> Um repositório dedicado ao estudo e implementação prática dos principais padrões de projeto (Design Patterns) em C# .NET

## 📚 Sobre o Projeto

Este repositório foi criado com o objetivo de servir como **material de referência e estudo** dos Design Patterns clássicos do Gang of Four (GoF) e outros padrões relevantes no desenvolvimento de software moderno.

### 🎯 Filosofia do Repositório

Cada padrão implementado contém:
- ✅ Código funcional e comentado
- ✅ Exemplo prático de uso
- ✅ Documentação explicativa
- ✅ Implementação focada em simplicidade e clareza

## 🌳 Padrões Implementados

| Padrão | Categoria | Status |
|--------|-----------|--------|
| Builder Pattern | Criacional | ✅ Implementado |
| Observer Pattern | Comportamental | ✅ Implementado |
| Factory Pattern | Criacional | ✅ Implementado |
| Strategy Pattern | Comportamental | ✅ Implementado |
| Facade Pattern | Estrutural | ✅ Implementado |

## 🎯 Padrões Implementados

### 🏗️ Builder Pattern
**Categoria**: Criacional  
**Problema**: Construção de objetos complexos com múltiplos parâmetros  
**Solução**: Builder com Director para construção passo a passo  
**Cenário**: Sistema de mensageria (RabbitMQ/Kafka)  
**Características**:
- ✅ Fluent Interface
- ✅ Director com Dependency Injection
- ✅ Reset automático
- ✅ Namespaces organizados

### 👁️ Observer Pattern
**Categoria**: Comportamental  
**Problema**: Notificar múltiplos objetos sobre mudanças de estado  
**Solução**: Subject notifica Observers automaticamente  
**Cenário**: Sistema de inventário com serviços de notificação  
**Características**:
- ✅ Product como Subject
- ✅ Três serviços como Observers (Analytics, Inventory, Notification)
- ✅ C# 12 collection expressions
- ✅ Interfaces bem definidas (IObserver, ISubject)

### 🎯 Strategy Pattern
**Categoria**: Comportamental  
**Problema**: Algoritmos intercambiáveis em tempo de execução  
**Solução**: Interface Strategy com implementações concretas  
**Cenário**: Sistema de cálculo de frete com diferentes modalidades  
**Características**:
- ✅ Interface IShippingStrategy bem definida
- ✅ Três estratégias concretas (Economy, Express, Sedex)
- ✅ ShippingService como classe Context
- ✅ Troca dinâmica de estratégias via SetStrategy()
- ✅ Estrutura organizada com namespaces separados
- ✅ Cálculo baseado em dimensões e peso do pacote

### 🏭 Factory Pattern
**Categoria**: Criacional  
**Problema**: Criação de objetos sem especificar classes concretas  
**Solução**: Factory Method com classes abstratas e concretas  
**Cenário**: Sistema de pagamento com diferentes métodos e impostos  
**Características**:
- ✅ Factory abstrata `FactoryPayment` com método abstract `CreatePayment()`
- ✅ Três factories concretas (BankSlip, CreditCard, PayPal)
- ✅ Três tipos de impostos intercambiáveis (TaxFree, FlatTax, VariableTax)
- ✅ Injeção de dependência com ITax nas factories
- ✅ Interface IPayment bem definida
- ✅ Cliente desacoplado das classes concretas de pagamento
- ✅ C# 12 primary constructors utilizado

### 🎭 Facade Pattern
**Categoria**: Estrutural  
**Problema**: Simplificar a interação com múltiplos subsistemas complexos  
**Solução**: Interface unificada que esconde a complexidade dos subsistemas  
**Cenário**: Sistema de compra de passagens aéreas com múltiplos serviços  
**Características**:
- ✅ TicketFacade como interface simplificada
- ✅ Quatro subsistemas (CheckFlight, TaxCalculator, PaymentProcess, GenerateTicket)
- ✅ Lógica completa de validação e processamento
- ✅ Tratamento de erros integrado
- ✅ Geração de tickets formatados com informações completas
- ✅ Cálculo de taxas variáveis por destino
- ✅ Validação de pagamento com limites e regras de negócio

## 🚀 Como Usar Este Repositório

### Explorando um Padrão Específico

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/design-patterns.git

# Navegue até a pasta
cd design-patterns

# Explore a implementação desejada
cd BuilderPattern
# ou
cd ObserverPattern
# ou
cd StrategyPattern
# ou
cd FactoryPattern
# ou
cd FacadePattern
```

### Exemplos de Uso

#### Builder Pattern
```csharp
var builder = new MessageBuilder();
var director = new DirectorBuilderMessage(builder);

director.MessageConstruct("json payload", 1, "unique-key", "application/json");
var message = director.Build();
```

#### Observer Pattern
```csharp
var product = new Product { Name = "Notebook", Price = 1000, Quantity = 0 };

product.Attach(new AnalyticsService());
product.Attach(new InventoryService());
product.Attach(new NotificationService());

product.Restock(100); // Notifica todos os observers automaticamente
```

#### Strategy Pattern
```csharp
var package = new Package 
{ 
    Weight = 10, 
    Height = 20, 
    Width = 15, 
    Depth = 5 
};

var shippingService = new ShippingService(new EconomyStrategy());
var cost = shippingService.Calculate(package);

// Troca para estratégia expressa
shippingService.SetStrategy(new ExpressStrategy());
var expressCost = shippingService.Calculate(package);
```

#### Factory Pattern
```csharp
// Criar taxas
var freeTax = new TaxFree();
var flatTax = new FlatTax();
var variableTax = new VariableTax();

// Criar pagamentos através de factories
var paypalFactory = new FactoryPaymentPaypal(freeTax);
var paypalClient = new Client(paypalFactory);
paypalClient.Pay(1000m);

var cardFactory = new FactoryPaymentCreditCard(flatTax);
var cardClient = new Client(cardFactory);
cardClient.Pay(500m);
```

#### Facade Pattern
```csharp
// Criar instâncias dos serviços
var services = CreateServices();
var ticketFacade = new TicketFacade(
    services.GenerateTicket,
    services.CheckFlight,
    services.TaxCalculator,
    services.PaymentProcess
);

// Criar voo e processar compra
var flight = new Flight(
    flightNumber: 123,
    destination: "London",
    departure: "12:00",
    arrival: "13:00",
    price: 100m
);

// Facade simplifica toda a complexidade
var purchaseSuccessful = ticketFacade.BuyTicket(flight);
if (purchaseSuccessful)
{
    Console.WriteLine(ticketFacade.PrintTicket(flight));
}
```

## 📖 Categorias de Padrões

### 🏗️ Padrões Criacionais
Focados na criação de objetos de forma flexível e reutilizável.
- **Builder** - Construção de objetos complexos passo a passo (✅ Implementado)
- **Factory Method** - Interface para criar objetos (✅ Implementado)
- **Singleton** - Garante única instância de uma classe
- **Prototype** - Clonagem de objetos
- **Abstract Factory** - Famílias de objetos relacionados

### 🔧 Padrões Estruturais
Focados na composição de classes e objetos.
- **Adapter** - Compatibilidade entre interfaces
- **Decorator** - Adicionar funcionalidades dinamicamente
- **Facade** - Interface simplificada para subsistemas (✅ Implementado)
- **Proxy** - Controle de acesso a objetos
- **Composite** - Estruturas de árvore

### 🎭 Padrões Comportamentais
Focados na comunicação entre objetos.
- **Observer** - Notificação de mudanças (✅ Implementado)
- **Strategy** - Algoritmos intercambiáveis (✅ Implementado)
- **Command** - Encapsular requisições
- **State** - Comportamento baseado em estado
- **Template Method** - Estrutura de algoritmo

## 💡 Estrutura do Projeto

```
design-patterns/
  ├── BuilderPattern/      (implementação do Builder)
  ├── ObserverPattern/     (implementação do Observer)
  ├── StrategyPattern/     (implementação do Strategy)
  ├── FactoryPattern/       (implementação do Factory)
  └── FacadePattern/       (implementação do Facade)
```

**Vantagens:**
- 🎯 **Isolamento**: Cada padrão em seu próprio diretório
- 📦 **Simplicidade**: Sem interferência entre implementações
- 🔍 **Foco**: Estude um padrão por vez
- 📚 **Organização**: Fácil navegação e localização dos padrões

## 🛠️ Tecnologias Utilizadas

- **Linguagem**: C# 12.0+
- **Framework**: .NET 9.0
- **IDE**: JetBrains Rider / Visual Studio
- **Controle de Versão**: Git
- **Features Modernas**: Collection expressions, Primary constructors, Pattern matching

## 📝 Convenções do Código

- Nomenclatura em inglês para código
- Comentários e documentação em português
- Seguindo princípios SOLID
- Código limpo e autoexplicativo

## 🎓 Recursos de Estudo

### Livros Recomendados
- 📘 "Design Patterns: Elements of Reusable Object-Oriented Software" - GoF
- 📗 "Head First Design Patterns" - Freeman & Robson
- 📙 "Refactoring: Improving the Design of Existing Code" - Martin Fowler

### Links Úteis
- [Refactoring Guru - Design Patterns](https://refactoring.guru/design-patterns)
- [Source Making - Design Patterns](https://sourcemaking.com/design_patterns)
- [Microsoft Docs - Cloud Design Patterns](https://docs.microsoft.com/en-us/azure/architecture/patterns/)

## 🤝 Contribuindo

Este é um repositório de estudos pessoais, mas sugestões são bem-vindas!

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/NovoPattern`)
3. Commit suas mudanças (`git commit -m 'Adiciona novo padrão'`)
4. Push para a branch (`git push origin feature/NovoPattern`)
5. Abra um Pull Request

## 📜 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## ✨ Autor

Desenvolvido com 💙 para fins de estudo e aprendizado.

---

⭐ **Dica**: Marque este repositório com uma estrela se ele está te ajudando nos estudos!