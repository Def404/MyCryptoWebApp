namespace PolybianSquare.Services;

public interface ISquareCryptService
{
    Task<string> Encrypted(string openText);
    Task<string> Decrypted(string encryptText);
}