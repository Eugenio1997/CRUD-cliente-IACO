

Este é um repositório cuja finalidade é apenas aprendizagem sobre o tipo de aplicação chamada Windows Formas do ecossistema .NET Framework que utiliza a linguagem C#.

### Esse projeto conterá:

- Formulario de cadastro de cliente;
- Panel contendo TextBoxs para obter dados de endereço do usuário (usando esse panel com a ideia de formulario multi-steps)
- Formulario contendo um DataGridView para exibir os clientes cadastrados;

### O fluxo de cadastro do cliente será como descrito abaixo:

1. Formulario contendo os seguintes campos: 
  - Primeiro Nome, Sobrenome, CPF, Telefone (mais campos)
2. Formulário contendo campos relativos à endereço como:
  - CEP, rua, numero da residencia, cidade e estado
3. Exibir o DataGridView com os dados do cliente inserido e os demais clientes, sendo estes dados recuperados do database
4. Os campos dos formulários devem ser limpos após o cadastro do novo cliente ter sido concluido,
  podendo somente ser realizado um novo cadastro após o usuário fechar o formulario que contém o DataGridView. 

### Setup

- Oracle Database Express Edition 21c (Banco)
- SQL Developer (SGBD)
- .NET Framework 3.5.2
- Visual Studio 15 (IDE)
