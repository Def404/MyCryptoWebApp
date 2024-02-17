namespace PolybianSquare.Services;

public interface ICryptService
{
    char[,] InitSquare();
    string Encrypted(string openText);

    string Decrypted(string encryptText);
}