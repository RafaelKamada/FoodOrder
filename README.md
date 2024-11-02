# :hamburger: FoodOrder
![FoodOrder](foodorder.png?raw=true "FoodOrder")

## :pencil: Descrição do Projeto
<p align="center">Este projeto tem como objetivo concluir a primeira etapa da entrega do Tech Challenge do curso de Software Architecture da Pós Graduação da FIAP.</p>

### :computer: Tecnologias Utilizadas
- Linguagem escolhida: DotNet
- Banco de Dados: Postgres

### :hammer: Entregáveis Fase 1
- Documentação do sistema (DDD) com Event Storming via [Miro](https://miro.com/app/board/uXjVKhyEAME=/?utm_source=notification&utm_medium=email&utm_campaign=daily-updates&utm_content=view-board-cta&lid=bpzqwwbw6c61) dos seguintes fluxos: 
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

### Documentação do Cadastro de Produto

[README de cadastro de produto](./Readme/README_PRODUTO.md)

### :hammer_and_wrench: Execução do projeto
1. Faça o clone do projeto: ```git@github.com:RafaelKamada/FoodOrder.git```
2. Rode o comando do docker-compose na raiz do projeto: ```docker-compose up -d```

### :busts_in_silhouette: Autores
| [<img loading="lazy" src="https://avatars.githubusercontent.com/u/96452759?v=4" width=115><br><sub>Robson Vilaça - RM358345</sub>](https://github.com/vilacalima) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/16946021?v=4" width=115><br><sub>Diego Gomes - RM358549</sub>](https://github.com/diegogl12) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/8690168?v=4" width=115><br><sub>Nathalia Freire - RM359533</sub>](https://github.com/nathaliaifurita) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/43392619?v=4" width=115><br><sub>Rafael Kamada - RM359345</sub>](https://github.com/RafaelKamada) |
| :---: | :---: | :---: | :---: |

