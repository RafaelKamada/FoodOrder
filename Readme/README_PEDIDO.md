# Documentação para FakeCheckout

Este guia descreve os passos necessários para realizar um fake checkout e listar os pedidos em nosso sistema. Para cada passo, é fornecido um exemplo de JSON ou Print da tela de entrada ou saída, junto com uma descrição do processo.

## Requisitos
- Ter realizado os passos de Cadastro de Produto: 
[README de cadastro de produto](./Readme/README_PRODUTO.md)


## Índice
- [Passo 1: Cadastrar Cliente](#passo-1-cadastrar-cliente)
- [Passo 2: Consultar Cliente](#passo-2-consultar-cliente)
- [Passo 3: Fake Checkout sem CPF](#passo-3-fake-checkout-sem-cpf)
- [Passo 4: Fake Checkout com CPF](#passo-4-fake-checkout-com-cpf)
- [Passo 5: Listar Pedidos](#passo-5-listar-pedidos)
- [Passo 6: Consulta Status de Pagamento](#passo-6-consulta-status-de-pagamento)
- [Passo 7: Atualizar Status do Pedido](#passo-7-atualizar-status-do-pedido)

---


### Passo 1: Cadastrar Cliente

Para cadastrar um cliente é obrigatório informar os campos de cpf, nome e e-mail. Abaixo o JSON de exemplo para cadastrar um cliente. 

**JSON de Exemplo:**

```json
{
  "cpf": "000.000.001-91",
  "nome": "Nome 1",
  "email": "email@mail.com"
}

```

#### Cadastrar Cliente:

![Print Swagger Cadastrar Cliente](./CadastrarCliente.png)

---


### Passo 2: Consultar Cliente

Para consultar um cliente basta informar um cpf. No exemplo abaixo utilizamos o cpf: <code>000.000.001-91</code>. 

#### Consulta Cliente:

![Print Swagger Cadastrar Cliente](./ConsultaCliente.png)

---


### Passo 3: Fake Checkout sem CPF

Para realizar um fake checkout é obrigatório informar um ou mais produtos passando o Id de cada Produto escolhido, e um CPF caso o usuário tenha se identificado. Abaixo está um exemplo de JSON para realizar o fake checkout sem "cpf" e com um produto "churros".

**JSON de Exemplo:**

```json
{
  "cpf": "string",
  "produtos": [
    1
  ]
}

```

#### Checkout sem CPF:

![Print Swagger FakeCheckout sem CPF](./FakeCheckout_sem_CPF.jpg)

---


### Passo 4: Fake Checkout com CPF

Para realizar um fake checkout é obrigatório informar um ou mais produtos passando o Id de cada Produto escolhido, e um CPF caso o usuário tenha se identificado. Abaixo está um exemplo de JSON para realizar o fake checkout com "cpf" e com 2 produtos "churros".

**JSON de Exemplo:**

```json
{
  "cpf": "000.000.001-91",
  "produtos": [
    1, 1
  ]
}

```

#### Checkout com CPF:

![Print Swagger FakeCheckout com CPF](./FakeCheckout_com_CPF.png)

---

### Passo 5: Listar Pedidos

Neste passo, você pode listar os pedidos criados no sistema. O JSON de retorno esperado incluir os detalhes de cada pedido.

#### Pedidos:

![Print Swagger Retorno da lista de pedidos](./ListarPedidos.png)

#### Exemplo de JSON de Retorno:

```json
{
  "pronto": [],
  "emPreparo": [
    {
      "id": 1,
      "numeroPedido": 1,
      "tempoEspera": "00:00:00",
      "dataCriacao": "2025-01-21T22:48:02.220797Z",
      "clienteId": null,
      "pagamentoId": 1,
      "pedidoStatus": {
        "id": 1,
        "descricao": "Em preparação"
      },
      "sacolaId": 1,
      "produtos": [
        {
          "id": 1,
          "nome": "frango",
          "descricao": "ave assada"
        }
      ]
    }
  ],
  "recebido": []
}
```
---

### Passo 6: Consulta Status de Pagamento

Neste passo é possível consulta o status do pagamento de um pedido após o seu checkout. O json de requisição necessita apenas do número do pedido.

#### Exemplo de JSON de Requisição:
```json
{
  "numeroPedido": 1
}

```
![Print Swagger Retorno de consulta do status de pagamento de um pedido](./StatusPagamento.png)

#### Exemplo de JSON de Resposta:
```json
{
  "descricao": "pending"
}

```

---

### Passo 7: Atualizar Status do Pedido

Este passo serve para atualizar o status de um pedido para:
- preparado
- emPreparo
- recebido

O json de requisição precisa do número do pedido e do status que deve ser atualizado.

#### Exemplo de JSON de Requisição:
```json
{
  "numeroPedido": 1,
  "status": "pronto"
}

```
![Print Swagger Retorno de update status de pedidos](./StatusPedido.png)

---

Este README documenta o processo básico de checkout e consulta de pedidos em nosso sistema de forma clara e objetiva.

