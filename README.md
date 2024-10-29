# FoodOrder
## Descrição do Projeto
<p align="center">Este projeto tem como objetivo concluir a primeira etapa da entrega do Tech Challenge do curso de Software Architecture da Pós Graduação da FIAP.</p>

<h1 align="center">
    <a href="https://dotnet.microsoft.com/pt-br/apps/aspnet/">🔗 .NET</a>
</h1>
<p align="center">🚀 lib para construir interfaces do usuário com componentes reutilizáveis</p>

### Entregáveis Fase 1

- [x] Documentação do sistema (DDD) com Event Storming via [Miro](https://miro.com/app/board/uXjVKhyEAME=/?utm_source=notification&utm_medium=email&utm_campaign=daily-updates&utm_content=view-board-cta&lid=bpzqwwbw6c61), incluindo todos os passos/tipos de diagrama mostrados na aula 6 do módulo de DDD, e utilizando a linguagem ubíqua, dos seguintes fluxos: 
    - [x] Realização do pedido e pagamento;
    - [x] Preparação e entrega do pedido.
- [x] Uma aplicação para todo o sistema de backend (monolito) que deverá ser desenvolvido seguindo os padrões apresentados nas aulas:
    - [x] Utilizando arquitetura hexagonal
    - [x] APIs:
        - [x] Cadastro do Cliente
        - [x] Identificação do Cliente via CPF
        - [x] Criar, editar e remover produtos
        - [x] Buscar produtos por categoria
        - [x] Fake checkout, apenas enviar os produtos escolhidos para a fila. O checkout é a finalização do pedido.
        - [x] Listar os pedidos
    - [x] Swagger para consumo das APIs
    - [x] Banco de dados à sua escolha
    - [x] Dockerfile configurado para executá=la corretamente
    - [x] docker-compose.yml para subir o ambiente completo
