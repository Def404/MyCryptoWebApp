namespace PolybianSquare.Services;

public interface ICryptService
{
    Task<string> Encrypted(string openText);
    Task<string> Decrypted(string encryptText);
}