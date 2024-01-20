# Descrição do Programa.

Olá. Este repositório foi criado com o objetivo de entender o caminho para se criar uma conexão com um tabela MySQL no Visual Studio Code, em um projeto em C#. 
Abaixo vou deixar a descrição de cada etapa da construção dessa conexão. 

**Este estudo foi feito com base em alguns fóruns e documentos encontrados na internet e adaptados para a minha reallidade.**

## Comandos iniciais.

A primeira coisa a se fazer é criar seu projeto no .NET. Execute em seu terminal o comando **"dotnet new console"** e aguarde seu projeto ser gerado.

Após gerar, adicione também no terminal o comando **"dotnet add package MySql.Data"**. Ele fará com que os pocotes NuGet sejam instalados em seu programa.

```
dotnet add package MySql.Data
```


**obs:** Segundo o artigo "Uma introdução ao NuGet", disponibilizado pela Microsoft, os NuGet são "um arquivo ZIP com a extensão .nupkg que contém o código compilado (DLLs), outros arquivos relacionados a esse código e um manifesto descritivo que inclui informações como o número de versão do pacote. Os desenvolvedores com código para compartilhar criam pacotes e os publicam em um host público ou privado. Os consumidores de pacote obtêm esses pacotes de hosts adequados, os adicionam aos seus projetos e chamam a funcionalidade de um pacote no código do projeto. Em seguida, o próprio NuGet manipula todos os detalhes de intermediários."

Você pode ler o artigo todo em: <https://learn.microsoft.com/pt-br/nuget/what-is-nuget>


## Adicionando arquivo .JSON

Agora precisamos adicionar um arquivo .JSON. Segundo o blog RockContent, "JSON, que significa JavaScript Object Notation, é uma formatação utilizada para estruturar dados em formato de texto e transmiti-los de um sistema para outro, como em aplicações cliente-servidor ou em aplicativos móveis." Sendo assim, o JSON no nosso caso irá armazenar a string de conexão com o banco de dados MySQL. 

Primeiro você deve criar um novo arquivo em seu programa, adicionado o .json ao fim. Um padrão muito usado por programadores é colocar o nome de **appsettings.json**.

Em seguida, adicione os seguintes comando: 
```
{
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=zapzum1;User=root;Password=Regin@0812"
    }
  }
````

**Descrição:**
1. Server: você deverá passar o local de seu servidor, caso seja local:
2. localhost. Se for remoto, adicione seu endereço.
3. Databse: nome do banco de dados no qual você deseja conectar em seu programa.
4. User: seu usuário no MySQL. geralmente em servidores locais, o nome do user deve ser "root".
5. Passeword: a senha que você criou quando instalou o programa em sua máquina.

Você também pode acessar o artigo completo sobre as funcionalidades do .JSON em: https://rockcontent.com/br/blog/json/


## Verificações de packageReference

Aconteceu comigo de não adicionar todos os packeagereferences quando eu instalei o NuGet do MySQL, com isso precisei pesquisar como fazer manualmente. Então, antes de seguir, verifique no seu arquivo .csprojet se os comandos abaixo estão todos inseridos. Se não, adicione eles manualmente: 
```
<ItemGroup>
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="8.0.0" />
    <PackageReference Include="MySql.Data" Version="8.3.0" />
    <PackageReference Include="MySql.Data.EntityFrameworkCore" Version="8.0.22" />
  </ItemGroup>
```


## Program

Agora trabalhando de fato no conector da nossa tabela, irei passar aqui o codesnap de um exemplo de como conectar e puxar os dados se sua tabela e verificar se realmente a conexão está sendo feita de maneira certa. Após a visualização, acompanhe a explicação da construção das principais partes do códigp:

<img src="https://github.com/luizawander/teste_MySQL/assets/154068580/8266ada5-cc27-4565-b6d8-cb0655793dae" width="500" height="500">


```
using MySql.Data.MySqlClient;
using System;
using Microsoft.Extensions.Configuration; 
```
1. MySql.Data.MySqlClient é necessário para trabalhar com o MySQL.
2. Microsoft.Extensions.Configuration é usado para configurar e ler dados de configuração.

```
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
```
3. IConfiguration é uma interface no .NET que faz parte do namespace Microsoft.Extensions.Configuration. Essa interface define um conjunto de métodos e propriedades para acessar configurações em um aplicativo .NET. Ela é usada para recuperar valores de configuração, como strings de conexão com banco de dados, informações de API, configurações de aplicativos, etc.

4. new ConfigurationBuilder(): Cria uma nova instância da classe ConfigurationBuilder. Essa classe faz parte do namespace Microsoft.Extensions.Configuration.

5. .SetBasePath(Directory.GetCurrentDirectory()): Define o diretório base para a pesquisa de arquivos de configuração. Directory.GetCurrentDirectory() retorna o diretório atual do aplicativo, geralmente o diretório do executável.

6. .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true): Adiciona um arquivo de configuração JSON ao construtor.

7. "appsettings.json" é o nome do arquivo JSON que contém as configurações.

8. optional: false indica que o arquivo é obrigatório. Se não for encontrado, lançará uma exceção.

9. reloadOnChange: true especifica que as configurações devem ser recarregadas automaticamente se o arquivo for alterado.

10. .Build(): Constrói a configuração. Esse método finaliza a configuração, tornando-a imutável. Depois de chamar Build(), você não pode mais modificar a configuração. Retorna um objeto IConfiguration que representa as configurações carregadas.

```
   string connectionString = configuration.GetConnectionString("DefaultConnection");
```
11. String de Conexão: Você está obtendo a string de conexão do arquivo de configuração usando a chave "DefaultConnection".
csharp


```
   using MySqlConnection connection = new MySqlConnection(connectionString);
    connection.Open();
```
12. Conexão MySQL: Você está criando uma instância de MySqlConnection usando a string de conexão e em seguida abrindo a conexão.


```
 string sqlQuery = "SELECT nome_Cliente, CPF_Cliente FROM cliente";
    using MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
```
13. Comando MySQL: Você está criando um comando MySQL (MySqlCommand) com a consulta SQL especificada de sua tabela **(Obs: lembre-se de colocar as referências da tabela exatamente como está lá)**

```
using MySqlDataReader reader = cmd.ExecuteReader();
    Console.WriteLine("Conexão bem-sucedida!");
```
Execução da Consulta e Mensagem de Sucesso: Você está executando a consulta e exibindo uma mensagem de sucesso no console. Coloquei ela por padrão para sabermos se realmente todas as etapas acima estão corretas.
