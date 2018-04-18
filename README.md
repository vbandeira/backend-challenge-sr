# Desafio BodyTech
__Vinicius Bandeira__

## Comentários
Infelizmente não fui capaz de concluir o desafio no prazo informado. Muito se deu por conta dos meus horários. Acabo chegando tarde em casa durante a semana por conta da distância da minha residência e meu trabalho. Sendo assim, 90% do código e trabalho que vocês estão recebendo foi desenvolvido no último final de semana, ou seja, dois dias de trabalho.

Ficaram pendentes funções básicas como o cadastro de fichas, cadastro de séries e pesquisa de clientes. Essas funcionalidades foram implementadas no backend e testes unitários, porém não consegui implementar as chamadas das mesmas no frontend. O frontend também poderia ser melhor trabalhado, porém tentei priorizar meu tempo na implementação das funcionalidades do que no visual da aplicação.

Alguns outros pontos pendentes foi documentação (comentários) de código e de endpoints utilizando ferramentas com Swagger.

## Arquitetura
O código foi desenvolvido usando .NET Core. Utilizei o template WebAPI com Angular 4 para o desenvolvimento pelo fato de ser uma arquitetura fácil de ser desacoplada no futuro. Essa template utiliza o modelo MVC, sendo o Modelo representado pelo projeto `BTech.DataAccess` utilizando o Entity Framework Core, o Controller representado pela Web Api, e a View representada pela aplicação Angular.

Foi utilizada a IDE Visual Studio 2017 Community Edition. As dependências NuGet e NPM devem ser baixadas automaticamente pela IDE caso a mesma esteja configurada corretamente.

Optei por utilizar um In Memory Database disponível através do pacote Microsoft.EntityFrameworkCore.InMemory para simplificação da execução da aplicação e por ser de fácil migração para um banco de dados permanente para persistência. Para isso basta alterar a conexão do mesmo no arquivo `Startup.cs` e executar as _migrations_ para criação das tabelas.

## Arquitetura escalável
A arquitetura que eu proponho seria a de microsserviços. Minha ideia inicial era de implementar a demo já nessa solução, porém como a mesma involve a criação de componentes extras, optei por uma implementação intermediária que acredito que seja de fácil migração para a nova arquitetura.

Cada _Controller_ desta aplicação se tornaria um microsserviço isolado, com seu próprio acesso a dados e persistência. A comunicação entre os microsserviços poderia ser feita via HTTP/REST/JSON, ou TCP/RPC/ProtoBuf caso a arquitetura anterior apresente de problemas de performance.

A comunicação e gerenciamento dos microsserviços com o mundo externo se dá através de uma _API Gateway_ que é responsável por gerenciar as chamadas dos mundo externo (aplicação, web site, etc.) aos dados e informações fornecidos pelos serviços. Essa _Api Gateway_ é responsável por fazer o registro dos serviços (_Service Discovery_), atua como proxy reverso e é responsável pela integração dos dados retornados por cada serviço, quase como um barramento de serviços.

## Execução do Projeto
Inseri os arquivos para execução do projeto através do Docker. Dentro do projeto `BTech.Web` está o arquivo `Dockerfile` que faz o _download_ da imagem base com o ASP .NET Core em Linux, a cópia do código fonte para o container, compilação, publicação e configuração do _EntryPoint_. Além deste arquivo, também adicionei o arquivo `dockercomposer.yml` para o caso de executar mais containers junto com o desta solução.

A execução fora do Docker é possível através de duas formas. A mais simples é a execução por dentro do Visual Studio 2017. 

A outra forma, que seria um deploy real _On Premise_ depende da instalação das seguintes dependências do .NET Core Runtime:

- [NodeJS](https://nodejs.org/)
- [.NET Core Runtime e ASP.NET Core Runtime (baixar a versão correspondente ao sistema operacional em uso)](https://www.microsoft.com/net/download/dotnet-core/runtime-2.0.6)

Uma vez instalado, precisamos acessar o diretório do projeto `BTech.Web`, e executar os seguintes comandos:
1. `dotnet restore`
2. `npm install`
3. `dotnet build -c Release -o /app`
4. `dotnet publish -c Release -o /app`

Os comandos acima fazem a recuperação dos pacotes (passos 1 e 2), compilação (passo 3) e publicação da aplicação (passo 4). Feito isso, a aplicação compilada e pronta para uso estará no subdiretório `BTech.Web\app`. A execução do projeto deve ser realizada através do comando: `dotnet BTech.Web.dll`.