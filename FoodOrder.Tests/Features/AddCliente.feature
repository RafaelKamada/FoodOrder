Feature: Cadastro de Cliente

  Scenario: Cliente é cadastrado com sucesso
    Given que tenho um cliente com CPF "12345678900", nome "João Silva" e email "joao@email.com"
    When eu tento cadastrar o cliente
    Then o cliente deve ser cadastrado com sucesso
    And o cliente cadastrado deve conter o CPF "12345678900"
    And o cliente cadastrado deve conter o nome "João Silva"
    And o cliente cadastrado deve conter o email "joao@email.com"