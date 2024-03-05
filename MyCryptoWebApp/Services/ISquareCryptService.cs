namespace MyCryptoWebApp.Services;

public interface ISquareCryptService
{
    Task<string> Encrypted(string openText);
    Task<string> Decrypted(string encryptText);
}