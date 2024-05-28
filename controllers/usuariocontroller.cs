using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using UsuariosAPI.models;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IDbConnection _connection;

    public UsuariosController(IDbConnection connection)
    {
        _connection = connection;
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> CriarUsuario(Usuario usuario)
    {
        var usuarioExistente = await _connection.QueryFirstOrDefaultAsync<Usuario>(
            "SELECT * FROM Usuarios WHERE Email = @Email OR CPF = @CPF",
            new { usuario.Email, usuario.CPF }
        );

        if (usuarioExistente != null)
        {
            return Conflict("Email ou CPF já existem.");
        }

        usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash);

        var sql = "INSERT INTO Usuarios (Nome, Email, SenhaHash, CPF, Nascimento) VALUES (@Nome, @Email, @SenhaHash, @CPF, @Nascimento)";
        await _connection.ExecuteAsync(sql, usuario);

        return usuario;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> ObterUsuarios()
    {
        var usuarios = await _connection.QueryAsync<Usuario>("SELECT * FROM Usuarios");

        if (usuarios == null || usuarios.Count() == 0)
        {
            return NotFound("Nenhum usuário cadastrado");
        }

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> ObterUsuarioId(int id)
    {
        var usuario = await _connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });

        if (usuario == null)
        {
            return NotFound($"Usuário {id} não encontrado");
        }

        return Ok(usuario);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizaUsuario(int id, Usuario usuario)
    {
        var usuarioAtualizar = await _connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
        if (usuarioAtualizar == null)
        {
            return NotFound($"Usuário {id} não encontrado");
        }

        var usuarioIgual = await _connection.QueryFirstOrDefaultAsync<Usuario>(
            "SELECT * FROM Usuarios WHERE (Email = @Email OR CPF = @CPF) AND Id != @Id",
            new { usuario.Email, usuario.CPF, Id = id }
        );
        if (usuarioIgual != null)
        {
            return Conflict($"Email ou CPF já cadastrado no usuário id {usuarioIgual.Id}");
        }

        var sql = "UPDATE Usuarios SET Nome = @Nome, Email = @Email, CPF = @CPF, Nascimento = @Nascimento, SenhaHash = @SenhaHash WHERE Id = @Id";
        await _connection.ExecuteAsync(sql, new { usuario.Nome, usuario.Email, usuario.CPF, usuario.Nascimento, usuario.SenhaHash, Id = id });

        return CreatedAtAction(nameof(ObterUsuarioId), new { id = id }, usuario);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuarioExistente = await _connection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
        if (usuarioExistente == null)
        {
            return NotFound($"Usuário {id} não encontrado");
        }

        await _connection.ExecuteAsync("DELETE FROM Usuarios WHERE Id = @Id", new { Id = id });
        return Ok("Usuário excluido com sucesso");
    }
}
