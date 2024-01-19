# Descrição do Programa.

Olá. Este repositório foi criado com o objetivo de entender o caminho para se criar uma conexão com um tabela MySQL no Visual Studio Code, em um projeto em C#. 
Abaixo vou deixar a descrição de cada etapa da construção dessa conexão. 

**Este estudo foi feito com base em alguns fóruns e documentos encontrados na internet e adaptados para a minha reallidade.**

## Comandos iniciais.

A primeira coisa a se fazer é criar seu projeto no .NET. Execute em seu terminal o comando **"dotnet new console"** e aguarde seu projeto ser gerado.

Após gerar, adicione também no terminal o comanado **"dotnet add package MySql.Data"**. Ele fará com que os pocotes NuGet sejam instalados em seu programa.


**obs:** Segundo o artigo "Uma introdução ao NuGet", disponibilizado pela Microsoft, os NuGet são "um arquivo ZIP com a extensão .nupkg que contém o código compilado (DLLs), outros arquivos relacionados a esse código e um manifesto descritivo que inclui informações como o número de versão do pacote. Os desenvolvedores com código para compartilhar criam pacotes e os publicam em um host público ou privado. Os consumidores de pacote obtêm esses pacotes de hosts adequados, os adicionam aos seus projetos e chamam a funcionalidade de um pacote no código do projeto. Em seguida, o próprio NuGet manipula todos os detalhes de intermediários."

Você pode ler o artigo todo em: <https://learn.microsoft.com/pt-br/nuget/what-is-nuget>


## Adicionando arquivo .JSON

Agora precisamos adicionar um arquivo .JSON. Segundo o blog RockContent, "JSON, que significa JavaScript Object Notation, é uma formatação utilizada para estruturar dados em formato de texto e transmiti-los de um sistema para outro, como em aplicações cliente-servidor ou em aplicativos móveis." Sendo assim, o JSON no nosso caso irá armazenar a string de conexão com o banco de dados MySQL. 

Primeiro você deve criar um novo arquivo em seu programa, adicionado o .json ao fim. Um padrão muito usado por programadores é colocar o nome de **appsettings.json**.

Em seguida, adicione os seguintes comando: 
