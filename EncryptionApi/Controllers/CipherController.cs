using Microsoft.AspNetCore.Mvc;

namespace EncryptionApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CipherController : ControllerBase
{
    // KRYPTERA (ENCRYPT)
    [HttpGet("encrypt")]
    public IActionResult Encrypt(string text)
    {
        if (string.IsNullOrEmpty(text)) return BadRequest("Text needed");

        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (char)(buffer[i] + 1);
        }
        return Ok(new { Original = text, Encrypted = new string(buffer) });
    }

    // AVKRYPTERA (DECRYPT)
    [HttpGet("decrypt")]
    public IActionResult Decrypt(string text)
    {
        if (string.IsNullOrEmpty(text)) return BadRequest("Text needed");

        char[] buffer = text.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = (char)(buffer[i] - 1);
        }
        return Ok(new { Encrypted = text, Decrypted = new string(buffer) });
    }
}