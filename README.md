# RestaurantOrder.API
Backend API para um sistema de pedidos de restaurante.
A idéia foi utilizar o máximo de recursos oferecidos pelo .NET Core e bibliotecas e não precisar "reinventar a roda".

Especificações
* Aplicação da separação de projetos com base em Domínio
* Utilização do Repository Pattern
* Um context com banco de dados em memória, com dados para se utilizar
* Context trabalha com no tracking já que APIs funcionam desconectadas
* Uso do Automapper para aproveitar os Outer Facing Contracts (DTOs)
* Uso de Injeção de Dependências
* Uso de métodos assíncronos desde as controllers até o acesso a dados


Funcionalidades:
* Incluído o suporte para retornar XML, caso solicitado no header do request. Sendo JSON o retorno padrão
* Retorno de status 406 caso o header do request não seja aceito
* Adicionada mensagem de erro padronizada caso o ambiente não seja de desenvolvimento (há um start de produção configurado no launchSettings.json
* A criação de um recurso usa o retorno CreatedAtRoute que devolve o recurso criado com o código 201
