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

### :hammer_and_wrench: Execução do projeto
1. Faça o clone do projeto: ```git clone git@github.com:RafaelKamada/FoodOrder.git```
2. Rode o comando do docker-compose na raiz do projeto: ```docker-compose up -d```
3. O projeto deverá iniciar os serviços, conforme abaixo:
```
☁  FoodOrder [alterar_readme] docker-compose up -d
[+] Building 0.0s (0/0)                                                                     
[+] Running 3/3
 ✔ Network foodorder_default     Created                                               0.1s 
 ✔ Container postgress.database  Started                                               1.1s 
 ✔ Container orders.api          Started                                               1.7s 
 ```
4. Acessar o Swagger: ```http://localhost:9000/swagger/index.html```
5. Após a inicialização do Swagger, é preciso seguir as instruções da Documentação do Cadastro de Produto e Documentação para o Fake Checkout.

### :hammer: Entregáveis Fase 3
- Configuração de deploy para Kubernetes utilizando Terraform. O projeto segue as melhores práticas de CI/CD, garantindo automação e segurança no deploy dos recursos. 

## 📁 Estrutura do Repositório
```
food-order-terraform-db
├── .github/workflows/  # Configuração dos pipelines de CI/CD
│   ├── deploy.yml  # Workflow para provisionamento da infraestrutura AWS com Terraform
├── kubernets.tf  # Configuração de deploy da api no cluster EKS na AWS
├── provider.tf  # Configuração do provider AWS no Terraform
├── vars.tf  # Definição de variáveis do Terraform
└── README.md  # Documentação do projeto
```

## 🔧 Configuração e Deploy
### 📌 Pré-requisitos
- Terraform instalado
- AWS CLI configurado
- kubectl instalado

## 🚀 Passos para Deploy

1. Clone o repositório: 
```git clone https://github.com/RafaelKamada/FoodOrder.git```
```cd FoodOrder```

2. Inicialize o Terraform:
```terraform init```

3. Valide e aplique a infraestrutura:
```terraform plan```
```terraform apply```

4. Configure o contexto do Kubernetes:
```aws eks update-kubeconfig --name nome-do-cluster --region regiao```

5. Implante aplicações no cluster:
```kubectl apply -f k8s/```

## 🔑 Configuração do Secrets no GitHub

### 1️⃣ Acesse as configurações do repositório
1. Vá até o repositório no GitHub.
2. Clique em Settings.
3. No menu lateral, clique em Secrets and variables > Actions.
4. Clique em New repository secret.

#### 2️⃣ Adicione as Secrets necessárias
✅ Para autenticação na AWS
Essas credenciais são usadas pelo Terraform e pelo GitHub Actions para acessar a AWS.

    | Nome da secret           | Descrição                                                                |
    | :------------------------| :------------------------------------------------------------------------|
    | `AWS_ACCESS_KEY_ID`      | Chave de acesso da AWS                                                   |
    | `AWS_SECRET_ACCESS_KEY`  | Chave secreta da AWS                                                     |
    | `AWS_SESSION_TOKEN`      | (Opcional) Token de sessão, se estiver usando credenciais temporárias    |

✅ Outras Secrets
Caso sua aplicação use um banco de dados ou outra API, adicione as credenciais necessárias.

    | Nome da secret           | Descrição                  |
    | :------------------------| :--------------------------|
    | `DB_NAME`                | Nome do Banco de Dados     |
    | `DB_USERNAME`            | Usuário do banco de dados  |
    | `DB_PASSWORD`            | Senha do banco de dados    |



    

### :page_with_curl: Documentações
- [Documentação de cadastro de produto](./Readme/README_PRODUTO.md)
- [Documentação para o Fake Checkout](./Readme/README_PEDIDO.md)
- [Documentação de arquitetura](./Readme/README_ARQUITETURA.md)
- [Documentação do banco de dados](./Readme/README_DB.md)
- [Youtube](https://www.youtube.com/watch?v=TIZCErpTQjM)


### :busts_in_silhouette: Autores
| [<img loading="lazy" src="https://avatars.githubusercontent.com/u/96452759?v=4" width=115><br><sub>Robson Vilaça - RM358345</sub>](https://github.com/vilacalima) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/16946021?v=4" width=115><br><sub>Diego Gomes - RM358549</sub>](https://github.com/diegogl12) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/8690168?v=4" width=115><br><sub>Nathalia Freire - RM359533</sub>](https://github.com/nathaliaifurita) |  [<img loading="lazy" src="https://avatars.githubusercontent.com/u/43392619?v=4" width=115><br><sub>Rafael Kamada - RM359345</sub>](https://github.com/RafaelKamada) |
| :---: | :---: | :---: | :---: |

