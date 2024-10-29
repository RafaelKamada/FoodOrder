:hamburger: # FoodOrder
![FoodOrder](foodorder.png?raw=true "FoodOrder")

## Descrição do Projeto
<p align="center">Este projeto tem como objetivo concluir a primeira etapa da entrega do Tech Challenge do curso de Software Architecture da Pós Graduação da FIAP.</p>

Linguagem escolhida: DotNet
Banco de Dados: Postgres

### Entregáveis Fase 1

- Documentação do sistema (DDD) com Event Storming via [Miro](https://miro.com/app/board/uXjVKhyEAME=/?utm_source=notification&utm_medium=email&utm_campaign=daily-updates&utm_content=view-board-cta&lid=bpzqwwbw6c61), incluindo todos os passos/tipos de diagrama mostrados na aula 6 do módulo de DDD, e utilizando a linguagem ubíqua, dos seguintes fluxos: 
    - Realização do pedido e pagamento; ✔️
    - Preparação e entrega do pedido. ✔️
- Uma aplicação para todo o sistema de backend (monolito) que deverá ser desenvolvido seguindo os padrões apresentados nas aulas:
    - Utilizando arquitetura hexagonal ✔️
    - APIs ✔️

    | Status | Features cobertas                 | APIs                           |
    |  :---: | :---------------------------------| :------------------------------|
    |    ✔️   | Cadastro do Cliente               | `Cliente/Cadastrar`            |
    |    ✔️   | Identificação do Cliente via CPF  | `Cliente/ConsultarPorCPF`      |
    |    ✔️   | Criar produtos                    | `Produto/Cadastrar`            |
    |    ✔️   | Editar produtos                   | `Produto/Atualizar`            |
    |    ✔️   | Remover produtos                  | `Produto/Deletar`              |
    |    ✔️   | Buscar produtos por categoria     | `Produto/ConsultarPorCategoria`|
    |    ✔️   | FakeCheckout                      | `Checkout/FakeCheckout`        |
    |    ✔️   | Listar os pedidos                 | `Pedido/ListarPedidos`         |

    - Swagger para consumo das APIs ✔️
    - Banco de dados à sua escolha ✔️
    - Dockerfile configurado para executá-la corretamente ✔️
    - docker-compose.yml para subir o ambiente completo ✔️

### Execução do projeto
```docker-compose up -d```


### Autores
- Rafael Kamada - RMXXXX
- Diego Gomes - RMXXXX
- Robson Vilaça - RMXXXXX
- Nathalia Freire - RM359533
