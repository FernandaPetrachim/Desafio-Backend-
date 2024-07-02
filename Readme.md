<html>
<body>
    <h1><strong>Bem-vindo ao repositório do projeto API de Gerenciamento de Usuários</strong></h1>
    <p>Este é uma API REST, realizado para um aplicativo de gerenciamento de usuários, desenvolvido com base no conceito CRUD (Create, Read, Update, Delete). A API permite o cadastro, listagem, atualização e exclusão de usuários, garantindo segurança através do armazenamento de senhas em hash e evitando duplicidade de emails e CPFs.</p>
    <h2><strong>Funcionalidades</strong></h2>
    <ul>
        <li>Cadastro de um novo usuário</li>
        <li>Listagem de todos os usuários</li>
        <li>Listagem de um usuário por ID</li>
        <li>Atualização de informações de um usuário por ID</li>
        <li>Exclusão de um usuário por ID</li>
        <li>Documentação da API utilizando Swagger</li>
    </ul>
    <h2><strong>Tecnologias Utilizadas</strong></h2>
    <ul>
        <li>C# com .NET Core 2.0 (ou superior)</li>
        <li>Dapper para acesso a dados</li>
        <li>BCrypt para hashing de senhas</li>
        <li>Swagger para documentação da API</li>
        <li>SQL Server ou banco de dados em memória com Entity Framework Core</li>
    </ul>
    <h2><strong>Requisitos</strong></h2>
    <ul>
        <li>.NET Core SDK 2.0 ou superior</li>
        <li>SQL Server (opcional, caso não utilize banco de dados em memória)</li>
    </ul>
    <h2><strong>Instalação</strong></h2>
    <p>Clone o repositório:</p>
    <ul>
        <li>git clone https://github.com/seu-usuario/nome-do-repositorio.git</li>
        <li>cd nome-do-repositorio</li>
    </ul>
    <p>Restaure os pacotes NuGet:</p>
    <pre><code>dotnet restore</code></pre>
    <p>Configure a string de conexão no arquivo <code>appsettings.json</code> (se estiver utilizando SQL Server):</p>
    <pre><code>{
    "ConnectionStrings": {
        "DefaultConnection": "Server=.;Database=UsuariosDB;Trusted_Connection=True;"
    }
}</code></pre>
    <p>Execute a aplicação:</p>
    <pre><code>dotnet run</code></pre>
     <h2><strong>Endpoints</strong></h2>
    <h3>Cadastro de Usuário</h3>
    <p><strong>URL:</strong> /api/usuarios</p>
    <p><strong>Método:</strong> POST</p>
    <p><strong>Body:</strong></p>
    <pre><code>{
    "nome": "string",
    "email": "string",
    "senhaHash": "string",
    "cpf": "string",
    "nascimento": "yyyy-MM-dd"
}</code></pre>
    <p><strong>Resposta:</strong></p>
    <ul>
        <li>201 Created em caso de sucesso</li>
        <li>409 Conflict se o email ou CPF já existirem</li>
    </ul>
    <h3>Listagem de Usuários</h3>
    <p><strong>URL:</strong> /api/usuarios</p>
    <p><strong>Método:</strong> GET</p>
    <p><strong>Resposta:</strong></p>
    <ul>
        <li>200 OK com a lista de usuários</li>
        <li>404 Not Found se não houver usuários cadastrados</li>
    </ul>
    <h3>Listagem de Usuário por ID</h3>
    <p><strong>URL:</strong> /api/usuarios/@Model.UsuarioId</p>
    <p><strong>Método:</strong> GET</p>
    <p><strong>Resposta:</strong></p>
    <ul>
        <li>200 OK com o usuário encontrado</li>
        <li>404 Not Found se o usuário não for encontrado</li>
    </ul>
    <h3>Atualização de Usuário</h3>
    <p><strong>URL:</strong> /api/usuarios/@Model.UsuarioId</p>
    <p><strong>Método:</strong> PUT</p>
    <p><strong>Body:</strong></p>
    <pre><code>{
    "nome": "string",
    "email": "string",
    "senhaHash": "string",
    "cpf": "string",
    "nascimento": "yyyy-MM-dd"
}</code></pre>
    <p><strong>Resposta:</strong></p>
    <ul>
        <li>200 OK em caso de sucesso</li>
        <li>404 Not Found se o usuário não for encontrado</li>
        <li>409 Conflict se o email ou CPF já estiverem em uso por outro usuário</li>
    </ul>
    <h3>Exclusão de Usuário</h3>
    <p><strong>URL:</strong> /api/usuarios/@Model.UsuarioId</p>
    <p><strong>Método:</strong> DELETE</p>
    <p><strong>Resposta:</strong></p>
    <ul>
        <li>200 OK em caso de sucesso</li>
        <li>404 Not Found se o usuário não for encontrado</li>
    </ul>
    <h2><strong>Queries T-SQL</strong></h2>
    <p>As queries T-SQL representando as operações CRUD podem ser encontradas na pasta <code>Database</code>.</p>
    <h2><strong>Testes</strong></h2>
    <p>Os testes da API foram realizados utilizando o Thunder Client, uma extensão do VS Code para testar APIs REST.E pelo swagger: http://localhost:5010/swagger/index.html</p>
<h2><strong>Contribuição</strong></h2>
    <p>Se deseja contribuir com este projeto, por favor, siga os passos abaixo:</p>
    <ol>
        <li>Faça um fork do repositório.</li>
        <li>Crie uma branch para sua feature:</li>
        <pre><code>git checkout -b minha-feature</code></pre>
        <li>Commit suas mudanças:</li>
        <pre><code>git commit -m 'Minha nova feature'</code></pre>
        <li>Push para a branch:</li>
        <pre><code>git push origin minha-feature</code></pre>
        <li>Crie um Pull Request.</li>
    </ol>
    <h2><strong>Contato</h2></strong>
    <p>E-mail: fernanda_petrachim@hotmail.com</p>
    <h2><strong>Licença</strong></h2>
    <p>Este projeto está licenciado sob a MIT License.</p>
</body>
</html>
