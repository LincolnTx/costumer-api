# Projeto demo de Clientes #Teste Vetta

Esse projeto foi criado visando a aplicação para uma vaga de fullstack na Vetta.

Foi feito num modelo monorepo para facilitar a execução do mesmo.

Para executar o projeto, abra a solution no VS19 e clique no ícone verde de play para rodar o build.

Ao finalizar o processo de build, uma nova janela do navegador irá se abrir, direto com o swagger da aplicação. Através do swagger todas as rotas de aplicação podem ser testadas

Teste a demo:

- A primeira página serve para logar na aplicação, feita somente para não deixar a pagina sem "usuário".
- Para logar use as credencias ```email= admin@admin.com senha= admin@123```.
- menu superior de navegação,o botão para fazer logout.
- Ao logar você será direcionado para a home onde podera ver todos os cliente cadastrados e suas informações (Lista de clientes).
- Cada card é um cliente, e é possível deletar um cliente clicanto na lixeira no canto superior direto de cada card.
- Infelizmente a busca e cadastro não foram implementadas no front, mas podem ser testadas via swagger.

## Bibliotecas utilizadas: Front

- **axios**: Configurar e realizar requisições HTTP;
- **prettier**: Padronizador de indentação do código fonte;
- **react-router-dom**: Gerenciador de rotas e navegação para react;
- **react-icons**: Biblioteca de icones para react, nesse projeto foram utilizados os icoes de Font Awesome;

## Bibliotecas utilizadas: Back

- **Swashbuckle**: Configurar e utiliza o swagger;
- **Microsoft.EntityFrameworkCore**: Framework de banco de dados do dotnet, acesso e manipulação de Banco de dados;
- **FluentValidation**:Biblioteca para validação de campos em classes c#, usada para validar as informações recebidas;

Foi utilizado o SQLServer localDb como banco da dados dessa aplicação

