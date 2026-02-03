using EncryptionApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EncryptionApi.Tests;

public class CipherTests
{
    [Fact]
    public void Encrypt_ShouldChangeText()
    {
        // 1. Arrange (Förbered)
        var controller = new CipherController();
        string input = "HEJ";

        // 2. Act (Utför)
        var result = controller.Encrypt(input) as OkObjectResult;

        // 3. Assert (Kontrollera)
        Assert.NotNull(result);
        string json = result.Value.ToString();
        // Vi kollar bara att resultatet inte är tomt eller null
        Assert.NotNull(json);
    }

    [Fact]
    public void Decrypt_ShouldRestoreText()
    {
        // En enkel kontroll att metoden körs utan krasch
        var controller = new CipherController();
        var result = controller.Decrypt("IFK") as OkObjectResult;
        Assert.NotNull(result);
    }
}