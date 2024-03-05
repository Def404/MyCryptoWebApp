namespace PolybianSquare.Services;

public interface IReshuffleCryptService
{
	Task<string> Encrypted(string openText);
	Task<string> Decrypted(string encryptText);
}