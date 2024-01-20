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
![json](https://github.com/luizawander/teste_MySQL/assets/154068580/a3dd6327-5dfe-454a-ba20-cf9649abdb11)


**Descrição:**
1. Server: você deverá passar o local de seu servidor, caso seja local:
2. localhost. Se for remoto, adicione seu endereço.
3. Databse: nome do banco de dados no qual você deseja conectar em seu programa.
4. User: seu usuário no MySQL. geralmente em servidores locais, o nome do user deve ser "root".
5. Passeword: a senha que você criou quando instalou o programa em sua máquina.

Você também pode acessar o artigo completo sobre as funcionalidades do .JSON em: https://rockcontent.com/br/blog/json/


## Verificações de packageReference

Aconteceu comigo de não adicionar todos os packeagereferences quando eu instalei o NuGet do MySQL, com isso precisei pesquisar como fazer manualmente. Então, antes de seguir, verifique no seu arquivo .csprojet se os comandos abaixo estão todos inseridos. Se não, adicione eles manualmente: 
![csprojet](https://github.com/luizawander/teste_MySQL/assets/154068580/43cb75a1-f14e-450e-8800-51c480da8167)


## Program

Agora trabalhando de fato no conector da nossa tabela, irei passar aqui o codesnap de um exemplo de como conectar e puxar os dados se sua tabela e verificar se realmente a conexão está sendo feita de maneira certa. Após a visualização, acompanha a explicação da construção do código:
