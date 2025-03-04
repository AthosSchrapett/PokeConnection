# PokeConnection

PokeConnection é um projeto de estudos que tem como objetivo explorar diferentes conceitos no desenvolvimento de APIs em C#.

## 🚀 Tecnologias Utilizadas (Até o Momento)
- C# / .NET
- HttpClientFactory
- Polly (Retries e Circuit Breaker)
- xUnit (Testes automatizados)
- Serilog
- Elasticsearch

## 📌 Objetivo
Este projeto está em andamento e será expandido ao longo do tempo com novas funcionalidades e tecnologias.

## 🛠️ Implementações(Em construção)

O **HttpClientFactory** foi implementado para facilitar a comunicação com APIs externas, garantindo reutilização eficiente de conexões.  

Agora, o **Polly** foi adicionado para garantir maior estabilidade e resiliência, incluindo:
- **Retries Automáticos** – Requisições com falha são repetidas automaticamente.  
- **Exponential Backoff** – O tempo de espera entre tentativas cresce exponencialmente (2s → 4s → 8s).  
- **Circuit Breaker** – Se ocorrerem falhas consecutivas, novas requisições são bloqueadas por 30 segundos antes de permitir novas tentativas.

Essa abordagem protege a aplicação contra falhas transitórias e garante que as requisições HTTP sejam tratadas de forma eficiente.

**Padrão Adapter**

O Adapter converte o JSON completo recebido da PokeAPI para a entidade Pokemon (nome, tipos e habilidades), e também para o PokemonResponseDTO retornado pela API.

## 📄 Status do Projeto
O projeto está em desenvolvimento e, no momento, conta com:
- **HttpClientFactory** para gerenciamento de conexões HTTP.
- **Polly** para resiliência com retries e circuit breaker.
- **xUnit** para execução de testes automatizados.
- **Serilog e Elasticsearch** para gerenciamento de logs na aplicação.

## 🛠️ Próximos Passos
- Conexão com bancos de dados (SQL e NoSQL).
- Melhor tratamento de logs e monitoramento.  
- Implementação de RabbitMQ para processamento assíncrono. 
- CI/CD e deploy automatizado.  

## 🤝 Contribuição
Este projeto é apenas para fins de estudo, mas sugestões são bem-vindas.

## 📄 Licença
Este projeto está sob a licença MIT.

📌 **GitHub**: [AthosSchrapett](https://github.com/AthosSchrapett)
