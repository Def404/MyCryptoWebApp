namespace PolybianSquare.Services;

public interface ICryptService
{
    char[,] InitSquare();
    Task<string> Encrypted(string openText);

    Task<string> Decrypted(string encryptText);
}