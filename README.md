# RabbitMQ-MVP
> Um sistema de votação dividido em duas partes, onde uma fique gerando votos aos montes, como se fosse uma competição para eleger um único ganhador.
> E para que o sistema não caia, teremos um processador desses votos, utilizando mensageria com RabbitMQ de forma escalável para aguentar a alta demanda de votos.

## Tecnologias utilizadas :rocket:

| Nome   | Descrição                  |
| ---------- |  --------------------- |
| RabbitMQ  | Consumo de mensagens de um broker |
| Console Application | Criada com .NET Core 3.1    |
| Serilog   |  Gerenciamento de logs da aplicação   |

## Índice :pencil:

* [Instalação](#instalação)
* [Como usar](#como-usar)
* [Demo](#rabbitmq-mvp)

## Instalação
> Realize a instalação e, faça as configurações necessárias para que suba o servidor `RabbitMQ` na porta padrão `http://127.0.0.1:15672/#/`.

| Nome   | Descrição                    | Obrigátorio               |
| ---------- | ------------------------------ | --------------------- |
| 🌎[Erlang](https://www.erlang.org/downloads)       |     Requisito necessário para o RabbitMQ ser instalado            |:white_check_mark: |
| 🌎[RabbitMQ](https://www.rabbitmq.com/download.html)        |     Streaming de menssagens        |      :white_check_mark:     |
| 🌎[RabbitMQ Management](http://127.0.0.1:15672/#/)   |        Gerenciador com interface para o RabbitMQ, faça login com: guest e senha: guest      | :x: |

## Como usar
> Após realizar as configurações do `RabbitMQ Management` e já com o `servidor` em pé crie um tópico com o nome que você irá configurar logo depois na demo.


## RabbitMQ-MVP 
> No arquivo `appsettings.json`, você deve colocar as configurações que você fez nos passos anteriores.
```
{
  "RabbitMQ_Broker": "http://127.0.0.1:15672",
  "RabbitMQ_Topic": "<nome_topico>",
  "TotalVendas": "10"
}
```
### 1. Simulador de votos:
> Console application `Simulador-Votos`.

### 2. Processador de votos:
> Console application `Processador-Votos`.
