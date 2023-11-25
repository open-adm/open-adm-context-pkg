using application_pkg.Exceptions;
using context_pkg.Factories.Interfaces;
using Microsoft.EntityFrameworkCore;
using pkg_context.Context;
using pkg_context.Cryptography;

namespace context_pkg.Factories.Factorie;

public class ContextFactory : IContextFactory
{
    public ClientContext CreateContextClient(byte[] stringConnectionByte)
    {
        var stringConnection = CryptographyDb.DecryptString(stringConnectionByte);

        if (string.IsNullOrWhiteSpace(stringConnection))
            throw new ExceptionCustom("String de conexão inválida para criação do contexto do cliente!");

        var optionsBuilderClient = new DbContextOptionsBuilder<ClientContext>();

        optionsBuilderClient.UseNpgsql(stringConnection,
            b => b.MigrationsAssembly(typeof(ClientContext).Assembly.FullName));

        return new ClientContext(optionsBuilderClient.Options);
    }
}
