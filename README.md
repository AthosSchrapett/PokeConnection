# PokeConnection

PokeConnection é um projeto de estudos que tem como objetivo explorar diferentes conceitos no desenvolvimento de APIs em C#.

## 🚀 Tecnologias Utilizadas (Até o Momento)
- C# / .NET
- HttpClientFactory
- Polly (Retries e Circuit Breaker)

## 📌 Objetivo
Este projeto está em fase inicial e será expandido ao longo do tempo com novas funcionalidades e tecnologias. Atualmente, a implementação foca no uso do **HttpClientFactory** para gerenciar chamadas HTTP de forma eficiente e na utilização do **Polly** para melhorar a resiliência da API.

## 🛠️ Implementação Atual: HttpClientFactory + Polly

O **HttpClientFactory** foi implementado para facilitar a comunicação com APIs externas, garantindo reutilização eficiente de conexões.  

Agora, o **Polly** foi adicionado para garantir maior estabilidade e resiliência, incluindo:
- **Retries Automáticos** – Requisições com falha são repetidas automaticamente.  
- **Exponential Backoff** – O tempo de espera entre tentativas cresce exponencialmente (2s → 4s → 8s).  
- **Circuit Breaker** – Se ocorrerem falhas consecutivas, novas requisições são bloqueadas por 30 segundos antes de permitir novas tentativas.

Essa abordagem protege a aplicação contra falhas transitórias e garante que as requisições HTTP sejam tratadas de forma eficiente.

## 📄 Status do Projeto
O projeto está em desenvolvimento e, no momento, conta com:
- **HttpClientFactory** para gerenciamento de conexões HTTP.
- **Polly** para resiliência com retries e circuit breaker.

## 🛠️ Próximos Passos
- Melhor tratamento de logs e monitoramento.  
- Implementação de RabbitMQ para processamento assíncrono.  
- Testes automatizados com xUnit.  
- CI/CD e deploy automatizado.  

## 🤝 Contribuição
Este projeto é apenas para fins de estudo, mas sugestões são bem-vindas.

## 📄 Licença
Este projeto está sob a licença MIT.

📌 **GitHub**: [AthosSchrapett](https://github.com/AthosSchrapett)
