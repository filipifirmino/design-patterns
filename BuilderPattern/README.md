# 🏗️ Builder Pattern - Sistema de Mensageria

> Implementação do padrão Builder para construção de mensagens destinadas a filas de mensageria (RabbitMQ, Kafka, etc.)

## 📋 Índice

- [Sobre o Padrão](#-sobre-o-padrão)
- [Problema Resolvido](#-problema-resolvido)
- [Estrutura da Implementação](#️-estrutura-da-implementação)
- [Como Usar](#-como-usar)
- [Componentes](#-componentes)
- [Diagrama de Classes](#-diagrama-de-classes)
- [Vantagens](#-vantagens)
- [Quando Usar](#-quando-usar)

## 🎯 Sobre o Padrão

O **Builder Pattern** é um padrão de projeto criacional que permite construir objetos complexos passo a passo. Ele separa a construção de um objeto da sua representação, permitindo que o mesmo processo de construção crie diferentes representações.

### 💡 Conceito Principal

```
"Separar a construção de um objeto complexo de sua representação,
de modo que o mesmo processo de construção possa criar diferentes representações."
- Gang of Four
```

## ❓ Problema Resolvido

### Cenário Real

Em um sistema de mensageria, precisamos criar mensagens com múltiplos atributos:

```csharp
// ❌ SEM Builder - Código confuso e propenso a erros
var message = new Message();
message.Body = "json payload";
message.Header = "application/json";
message.Priority = 1;
message.IdempotenceKey = "unique-key-123";

// E se esquecermos de definir algum campo?
// E se a ordem importar?
// Como garantir consistência?
```

### Solução com Builder

```csharp
// ✅ COM Builder - Código fluente e seguro
var builder = new MessageBuilder();
var director = new DirectorBuilderMessage(builder);

director.MessageConstruct("json payload", 1, "unique-key-123", "application/json");
var message = director.Build();
```

## 🏛️ Estrutura da Implementação

```
BuilderPattern/
├── Model/
│   └── Message.cs                    # Produto final (objeto complexo)
├── Interface/
│   └── IMessageBuilder.cs            # Interface do Builder
├── Builders/
│   ├── MessageBuilder.cs             # Builder concreto
│   └── DirectorBuilderMessage.cs     # Director (opcional)
└── Program.cs                        # Exemplo de uso
```

### 📦 Namespaces Utilizados

- `BuilderPattern.Model` - Contém a classe Message
- `BuilderPattern.Interface` - Contém a interface IMessageBuilder
- `BuilderPattern.Builders` - Contém as implementações concretas

## 🚀 Como Usar

### Exemplo 1: Criando Uma Mensagem

```csharp
using BuilderPattern.Builders;
using BuilderPattern.Model;

// Cria o builder e o director
var builder = new MessageBuilder();
var director = new DirectorBuilderMessage(builder);

// Constrói a mensagem
director.MessageConstruct(
    body: "{ \"user\": \"John\", \"action\": \"login\" }",
    priority: 1,
    idempotenceKey: "login-123",
    header: "application/json"
);

// Obtém o resultado
var message = director.Build();

// Publica na fila
Publisher(message);
```

### Exemplo 2: Múltiplas Mensagens (Como no Program.cs)

```csharp
var builder = new MessageBuilder();
var director = new DirectorBuilderMessage(builder);

// Mensagem JSON
director.MessageConstruct("json", 1, "key", "header");
var jsonMessage = director.Build();

// Mensagem XML (reutilizando o mesmo builder)
director.MessageConstruct("xml", 2, "key", "header");
var xmlMessage = director.Build();

// Cada mensagem é independente!
Publisher(jsonMessage);
Publisher(xmlMessage);
```

### Exemplo 3: Uso Direto do Builder (Sem Director)

```csharp
var message = new MessageBuilder()
    .SetBody("Hello World")
    .SetHeader("text/plain")
    .SetPriority(3)
    .SetIdempotenceKey(Guid.NewGuid().ToString())
    .Build();
```

## 🧩 Componentes

### 1️⃣ Message (Produto)

O objeto complexo que está sendo construído.

```csharp
public class Message
{
    public string Body { get; set; }          // Corpo da mensagem
    public string Header { get; set; }        // Cabeçalho/Tipo
    public int Priority { get; set; }         // Prioridade na fila
    public string IdempotenceKey { get; set; } // Chave de idempotência
}
```

**Uso no contexto de mensageria:**
- `Body`: Payload JSON/XML da mensagem
- `Header`: Content-Type ou metadados
- `Priority`: Define ordem de processamento na fila
- `IdempotenceKey`: Previne processamento duplicado

### 2️⃣ IMessageBuilder (Interface)

Define todos os passos necessários para construir uma mensagem.

```csharp
public interface IMessageBuilder
{
    MessageBuilder SetBody(string body);
    MessageBuilder SetHeader(string header);
    MessageBuilder SetPriority(int priority);
    MessageBuilder SetIdempotenceKey(string key);
    Message Build();
    void Reset();
}
```

**Características:**
- ✅ Retorna `MessageBuilder` para permitir **Fluent Interface**
- ✅ Método `Build()` retorna o produto final
- ✅ Método `Reset()` permite reutilização do builder

### 3️⃣ MessageBuilder (Builder Concreto)

Implementação concreta que constrói o objeto passo a passo.

```csharp
public class MessageBuilder : IMessageBuilder
{
    private Message _message = new();

    public MessageBuilder SetBody(string body)
    {
        _message.Body = body;
        return this; // Permite encadeamento
    }

    public Message Build() => _message;

    public void Reset()
    {
        _message = new Message(); // Cria nova instância
    }
}
```

**Pontos-Chave:**
- 🔄 Mantém referência interna ao objeto sendo construído
- 🔗 Retorna `this` para encadeamento (Fluent Interface)
- 🔁 `Reset()` cria **nova instância**, não modifica a anterior

### 4️⃣ DirectorBuilderMessage (Director)

Encapsula a lógica de construção e gerencia o ciclo de vida.

```csharp
public class DirectorBuilderMessage
{
    private readonly IMessageBuilder _builder;

    public DirectorBuilderMessage(IMessageBuilder builder)
    {
        _builder = builder;
    }

    public void MessageConstruct(string body, int priority, 
                                 string idempotenceKey, string header)
    {
        _builder.SetBody(body)
            .SetPriority(priority)
            .SetIdempotenceKey(idempotenceKey)
            .SetHeader(header);
    }

    public Message Build() {
        var result = _builder.Build();
        _builder.Reset(); // Prepara para próxima construção
        return result;
    }
}
```

**Responsabilidades:**
- 🎭 Define a **ordem** de construção
- ♻️ Gerencia o **reset** automático
- 🎯 Fornece API de **alto nível**
- 🔧 Recebe o builder via **construtor** (Dependency Injection)

## 📊 Diagrama de Classes

```
┌─────────────────────────────┐
│       <<interface>>         │
│     IMessageBuilder         │
├─────────────────────────────┤
│ + SetBody(string)           │
│ + SetHeader(string)         │
│ + SetPriority(int)          │
│ + SetIdempotenceKey(string) │
│ + Build(): Message          │
│ + Reset(): void             │
└──────────────┬──────────────┘
               │ implements
               │
┌──────────────▼──────────────┐
│      MessageBuilder         │
├─────────────────────────────┤
│ - _message: Message         │
├─────────────────────────────┤
│ + SetBody(string)           │
│ + SetHeader(string)         │
│ + SetPriority(int)          │
│ + SetIdempotenceKey(string) │
│ + Build(): Message          │
│ + Reset(): void             │
└──────────────┬──────────────┘
               │
               │ uses
               │
┌──────────────▼──────────────┐
│  DirectorBuilderMessage     │
├─────────────────────────────┤
│ - _builder: IMessageBuilder │
├─────────────────────────────┤
│ + MessageConstruct(...)     │
│ + Build(): Message          │
└──────────────┬──────────────┘
               │
               │ builds
               │
┌──────────────▼──────────────┐
│         Message             │
├─────────────────────────────┤
│ + Body: string              │
│ + Header: string            │
│ + Priority: int             │
│ + IdempotenceKey: string    │
└─────────────────────────────┘
```

## ✨ Vantagens

### 🎯 Controle Fino da Construção
Você controla cada passo da criação do objeto:
```csharp
builder.SetPriority(1)    // Passo 1
       .SetBody("data")   // Passo 2
       .Build();          // Finaliza
```

### 🔧 Características da Implementação Atual

- ✅ **Dependency Injection**: Director recebe builder via construtor
- ✅ **Fluent Interface**: Métodos retornam `this` para encadeamento
- ✅ **Reset Automático**: Director gerencia o reset após cada build
- ✅ **Namespaces Organizados**: Separação clara de responsabilidades
- ✅ **C# 9+ Features**: Uso de `new()` para inicialização simplificada

### 🔄 Reutilização
O mesmo builder pode criar diferentes objetos:
```csharp
var director = new DirectorBuilderMessage(builder);
var msg1 = director.Build(); // Mensagem 1
var msg2 = director.Build(); // Mensagem 2 (independente)
```

### 🧩 Isolamento de Código Complexo
A lógica de construção fica isolada no Director:
```csharp
// Cliente não precisa saber a ordem/lógica
director.MessageConstruct("data", 1, "key", "header");
```

### 🔌 Flexibilidade
Fácil criar novos tipos de builders:
```csharp
// Builder para mensagens de alta prioridade
public class HighPriorityMessageBuilder : IMessageBuilder { ... }

// Builder para mensagens JSON
public class JsonMessageBuilder : IMessageBuilder { ... }
```

### 🛡️ Imutabilidade (Parcial)
Cada `Build()` + `Reset()` garante objetos independentes.

## 🎪 Quando Usar

### ✅ Use Builder Quando:

- 📦 **Objeto tem muitos parâmetros** (4+)
- 🔧 **Construção é complexa** (múltiplos passos)
- 🎭 **Diferentes representações** do mesmo objeto
- 🚫 **Evitar construtores telescópicos**:
  ```csharp
  // ❌ Evite isso
  new Message("body", "header", 1, "key");
  new Message("body", "header", 1);
  new Message("body", "header");
  ```
- 🔄 **Processo de construção precisa ser reutilizável**

### ❌ Não Use Builder Quando:

- 🎯 Objeto é **simples** (2-3 campos)
- ⚡ **Performance é crítica** (builder adiciona overhead)
- 🏃 Objetos são **criados raramente**

## 🔗 Padrões Relacionados

- **Factory Method**: Cria objetos simples; Builder cria objetos complexos
- **Abstract Factory**: Famílias de objetos; Builder foca em um objeto
- **Prototype**: Clona objetos; Builder constrói do zero
- **Fluent Interface**: Técnica usada no Builder para encadeamento

## 📚 Casos de Uso Reais

### 1. **Mensageria** (Este projeto)
```csharp
var rabbitMessage = builder
    .SetBody(JsonSerializer.Serialize(data))
    .SetPriority(1)
    .Build();
```

### 2. **Query Builders (SQL)**
```csharp
var query = new SqlBuilder()
    .Select("*")
    .From("users")
    .Where("age > 18")
    .OrderBy("name")
    .Build();
```

### 3. **HTTP Clients**
```csharp
var client = new HttpClientBuilder()
    .SetBaseUrl("https://api.example.com")
    .AddHeader("Authorization", "Bearer token")
    .SetTimeout(30)
    .Build();
```

### 4. **UI Components**
```csharp
var dialog = new DialogBuilder()
    .SetTitle("Confirmar")
    .SetMessage("Deseja continuar?")
    .AddButton("Sim", OnYes)
    .AddButton("Não", OnNo)
    .Build();
```

## 🧪 Testando a Implementação

```bash
# Navegue até o projeto
cd BuilderPattern/BuilderPattern

# Execute o projeto
dotnet run

# Saída esperada:
# Publishing the message: json
# Publishing the message: xml
```

### 📋 Código Real do Program.cs

```1:17:BuilderPattern/BuilderPattern/Program.cs
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
```

## 📖 Referências

- **Design Patterns: Elements of Reusable Object-Oriented Software** - Gang of Four
- [Refactoring Guru - Builder Pattern](https://refactoring.guru/design-patterns/builder)
- [Microsoft Docs - Builder Pattern](https://docs.microsoft.com/en-us/azure/architecture/patterns/builder)

---

## 💡 Dicas de Estudo

1. **Compare com Factory**: Entenda quando usar cada um
2. **Experimente sem Director**: Veja a diferença na usabilidade
3. **Adicione validações**: Torne o builder mais robusto
4. **Implemente imutabilidade**: Use `init` nas propriedades
5. **Crie builders especializados**: JsonMessageBuilder, XmlMessageBuilder, etc.
6. **Teste o reset**: Verifique se objetos são independentes após reset
7. **Analise o Program.cs**: Veja como o padrão é usado na prática
8. **Experimente diferentes ordens**: Teste se a ordem dos métodos importa

---

**Implementado com 💙 para fins educacionais**

🔙 [Voltar ao Repositório Principal](../README.md)

