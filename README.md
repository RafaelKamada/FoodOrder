# FoodOrder

## Descrição do Projeto


<p align="center">Este projeto tem como objetivo concluir a primeira etapa da entrega do Tech Challenge do curso de Software Architecture da Pós Graduação da FIAP.</p>

### Entregáveis Fase 1

- [x] Documentação do sistema (DDD) com Event Storming via [Miro](https://miro.com/app/board/uXjVKhyEAME=/?utm_source=notification&utm_medium=email&utm_campaign=daily-updates&utm_content=view-board-cta&lid=bpzqwwbw6c61), incluindo todos os passos/tipos de diagrama mostrados na aula 6 do módulo de DDD, e utilizando a linguagem ubíqua, dos seguintes fluxos: 
    - [x] Realização do pedido e pagamento;
    - [x] Preparação e entrega do pedido.
- [x] Uma aplicação para todo o sistema de backend (monolito) que deverá ser desenvolvido seguindo os padrões apresentados nas aulas:
    - [x] Utilizando arquitetura hexagonal
    - [x] APIs:

    | Status | Features cobertas                 | API                            |
    | ------ | ----------------------------------| -------------------------------|
    |  [x]   | Cadastro do Cliente               | `Cliente/Cadastrar`            |
    |  [x]   | Identificação do Cliente via CPF  | `Cliente/ConsultarPorCPF`      |
    |  [x]   | Criar produtos                    | `Produto/Cadastrar`            |
    |  [x]   | Editar produtos                   | `Produto/Atualizar`            |
    |  [x]   | Remover produtos                  | `Produto/Deletar`              |
    |  [x]   | Buscar produtos por categoria     | `Produto/ConsultarPorCategoria`|
    |  [x]   | FakeCheckout                      | `Checkout/FakeCheckout`        |
    |  [x]   | Listar os pedidos                 | `Pedido/ListarPedidos`         |

    - [x] Swagger para consumo das APIs
    - [x] Banco de dados à sua escolha
    - [x] Dockerfile configurado para executá-la corretamente
    - [x] docker-compose.yml para subir o ambiente completo

### Execução do projeto
```docker-compose up -d```


### Autores
- Rafael Kamada - RMXXXX
- Diego Gomes - RMXXXX
- Robson Vilaça - RMXXXXX
- Nathalia Freire - RM359533
