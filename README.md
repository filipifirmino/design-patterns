# 🎨 Design Patterns - Repositório de Estudos

> Um repositório dedicado ao estudo e implementação prática dos principais padrões de projeto (Design Patterns) em C# .NET

## 📚 Sobre o Projeto

Este repositório foi criado com o objetivo de servir como **material de referência e estudo** dos Design Patterns clássicos do Gang of Four (GoF) e outros padrões relevantes no desenvolvimento de software moderno.

### 🎯 Filosofia do Repositório

Cada **branch** representa a implementação de um **padrão específico**, contendo:
- ✅ Código funcional e comentado
- ✅ Exemplo prático de uso
- ✅ Documentação explicativa
- ✅ Implementação focada em simplicidade e clareza

## 🌳 Estrutura de Branches

| Branch | Padrão | Categoria | Status |
|--------|--------|-----------|--------|
| `Builder-branch` | Builder Pattern | Criacional | ✅ Implementado |
| `observer-branch` | Observer Pattern | Comportamental | ✅ Implementado |
| `Factory-branch` | Factory Pattern | Criacional | 🔜 Em breve |
| `Singleton-branch` | Singleton Pattern | Criacional | 🔜 Em breve |
| `Strategy-branch` | Strategy Pattern | Comportamental | 🔜 Em breve |

## 🎯 Padrões Implementados

### 🏗️ Builder Pattern (`Builder-branch`)
**Categoria**: Criacional  
**Problema**: Construção de objetos complexos com múltiplos parâmetros  
**Solução**: Builder com Director para construção passo a passo  
**Cenário**: Sistema de mensageria (RabbitMQ/Kafka)  
**Características**:
- ✅ Fluent Interface
- ✅ Director com Dependency Injection
- ✅ Reset automático
- ✅ Namespaces organizados

### 👁️ Observer Pattern (`observer-branch`)
**Categoria**: Comportamental  
**Problema**: Notificar múltiplos objetos sobre mudanças de estado  
**Solução**: Subject notifica Observers automaticamente  
**Cenário**: Sistema de inventário com serviços de notificação  
**Características**:
- ✅ Product como Subject
- ✅ Três serviços como Observers (Analytics, Inventory, Notification)
- ✅ C# 12 collection expressions
- ✅ Interfaces bem definidas (IObserver, ISubject)

## 🔜 Próximos Padrões

### 🏭 Factory Pattern (`Factory-branch`)
**Categoria**: Criacional  
**Foco**: Criação de objetos sem especificar classes concretas  
**Cenário Planejado**: Sistema de criação de diferentes tipos de documentos

### 🔒 Singleton Pattern (`Singleton-branch`)
**Categoria**: Criacional  
**Foco**: Garantir única instância de uma classe  
**Cenário Planejado**: Logger global ou configuração de aplicação

### 🎯 Strategy Pattern (`Strategy-branch`)
**Categoria**: Comportamental  
**Foco**: Algoritmos intercambiáveis em tempo de execução  
**Cenário Planejado**: Sistema de pagamento com diferentes métodos

## 🚀 Como Usar Este Repositório

### Explorando um Padrão Específico

```bash
# Clone o repositório
git clone https://github.com/seu-usuario/design-patterns.git

# Navegue até a pasta
cd design-patterns

# Mude para a branch do padrão desejado
git checkout Builder-branch
# ou
git checkout observer-branch

# Explore a implementação
cd BuilderPattern
# ou
cd ObserverPattern
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

### Estudando Múltiplos Padrões

```bash
# Liste todas as branches (padrões disponíveis)
git branch -a

# Alterne entre diferentes padrões
git checkout Builder-branch
git checkout observer-branch
git checkout Factory-branch
```

## 📖 Categorias de Padrões

### 🏗️ Padrões Criacionais
Focados na criação de objetos de forma flexível e reutilizável.
- **Builder** - Construção de objetos complexos passo a passo
- **Factory Method** - Interface para criar objetos
- **Singleton** - Garante única instância de uma classe
- **Prototype** - Clonagem de objetos
- **Abstract Factory** - Famílias de objetos relacionados

### 🔧 Padrões Estruturais
Focados na composição de classes e objetos.
- **Adapter** - Compatibilidade entre interfaces
- **Decorator** - Adicionar funcionalidades dinamicamente
- **Facade** - Interface simplificada para subsistemas
- **Proxy** - Controle de acesso a objetos
- **Composite** - Estruturas de árvore

### 🎭 Padrões Comportamentais
Focados na comunicação entre objetos.
- **Observer** - Notificação de mudanças (✅ Implementado)
- **Strategy** - Algoritmos intercambiáveis
- **Command** - Encapsular requisições
- **State** - Comportamento baseado em estado
- **Template Method** - Estrutura de algoritmo

## 💡 Por Que Usar Branches?

```
main (documentação geral)
  ├── Builder-branch (implementação isolada do Builder)
  ├── observer-branch (implementação isolada do Observer)
  └── Factory-branch (implementação isolada do Factory)
```

**Vantagens:**
- 🎯 **Isolamento**: Cada padrão em seu próprio contexto
- 📦 **Simplicidade**: Sem interferência entre implementações
- 🔍 **Foco**: Estude um padrão por vez
- 🔄 **Comparação**: Use `git diff` entre branches para comparar abordagens

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