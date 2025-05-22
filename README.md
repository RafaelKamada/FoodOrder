# :hamburger: Food Order Usuários
![FoodOrder](foodorder.png?raw=true "FoodOrder")

## :pencil: Descrição do Projeto
<p align="left">Este projeto tem como objetivo concluir as  entregas do Tech Challenge do curso de Software Architecture da Pós Graduação da FIAP 2024/2025.
Este repositório constrói um serviço que faz parte de uma arquitetura de microsserviços.</p>

## 📊 Code Coverage
![Coverage](./Readme/coverage.png?raw=true "Arquitetura")

## 🏗️ Arquitetura de Microsserviços
![Arquitetura](arquitetura.png?raw=true "Arquitetura")

### :computer: Tecnologias Utilizadas
- Linguagem escolhida: .NET
- Banco de Dados: Postgres
- Mensageria: Publica na fila SQS

### :hammer: Detalhes desse serviço
Microserviço responsável pelo módulo de clientes da arquitetura de microserviços do sistema FoodOrder, desenvolvido em .NET e Postgres.

### :hammer_and_wrench: Execução do projeto
Para rodar o serviço localmente, você precisa ter Docker e .NET 9 instalados.

Para construir e rodar o serviço, utilize o comando:

```bash
docker-compose up --build -d
```

* Criar a rede Docker para comunicação entre os serviços.
* Subir o banco de dados Postgress.
* Iniciar o serviço `foodorder`.

Para parar e remover os containers, use:

```bash
docker-compose down
```

### Endpoints Disponíveis

| Método | Endpoint                                | Descrição                                     |
| ------ | --------------------------------------- | --------------------------------------------- |
| POST   | /Cadastrar                              | Cadastra um novo cliente.                     |
| GET    | /ConsultarPorCpf/{cpf}                  | Consulta um cliente cadastrado pelo cpf.      |

### 🗄️ Outros repos do microserviço dessa arquitetura
- [Food Order Produção](https://github.com/diegogl12/food-order-producao)
- [Food Order Pagamento](https://github.com/diegogl12/food-order-pagamento)
- [Food Order Cardápio](https://github.com/RafaelKamada/foodorder-cardapio)
- [Food Order Pedidos](https://github.com/vilacalima/food-order-pedidos)
- [Food Order Usuários](https://github.com/RafaelKamada/FoodOrder)


### 🗄️ Outros repos do Terraform/DB dessa arquitetura
- [Food Order Terraform](https://github.com/RafaelKamada/food-order-terraform-infra)
- [Food Order DB](https://github.com/nathaliaifurita/food-order-terraform-db)
- [Food Order MongoDB](https://github.com/RafaelKamada/food-order-terraform-mongodb)


### :page_with_curl: Documentações
- [Miro (todo planejamento do projeto)](https://miro.com/app/board/uXjVKhyEAME=/)


### :busts_in_silhouette: Autores
| [<img loading="lazy" src="https://avatars.githubusercontent.com/u/96452759?v=4" width=115><br><sub>Robson Vilaça - RM358345</sub>](https://github.com/vilacalima) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/16946021?v=4" width=115><br><sub>Diego Gomes - RM358549</sub>](https://github.com/diegogl12) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/8690168?v=4" width=115><br><sub>Nathalia Freire - RM359533</sub>](https://github.com/nathaliaifurita) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/43392619?v=4" width=115><br><sub>Rafael Kamada - RM359345</sub>](https://github.com/RafaelKamada) |
| :---: | :---: | :---: | :---: |
