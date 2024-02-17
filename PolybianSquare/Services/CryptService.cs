namespace PolybianSquare.Services;

public class CryptService : ICryptService
{
    /// <summary>
    /// Исходный алфавит (символы перемешаны)
    /// </summary>
    private readonly char[] _alphabet =
    {
        'у', '-', 'к', 'т', 'е', '3', 'р', '6', 'а', '7', 'ь', '9', 'г', '8', '/', 'ц', '+', '%', '*', '5', '(', ':',
        'о', 'э', ',', 'щ', '@', '2', '4', ';', 'п', '0', 'б', 'ё', ')', '!', 'ъ', '[', '?', 'ю', '№', 'ы', 'и', 'д',
        ']', 'в', 'л', '}', 'з', 'м', 'ф', 'ж', '.', 'й', '{', 'х', '1', '_', 'я', 'н', '#', 'ч', 'с', 'ш'
    };

    /// <summary>
    /// Полибианский квадрат
    /// </summary>
    private readonly char[,] _polybianSquare;

    public CryptService()
    {
        _polybianSquare = InitSquare();
    }

    /// <summary>
    /// Получаем двухмерный масив (квадрат) из исходного алфавита
    /// </summary>
    private char[,] InitSquare()
    {
        var result = new char[8, 8];

        var r = 0;
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                result[i, j] = _alphabet[r++];
            }
        }

        return result;
    }

    /// <summary>
    /// Функция шифрования открытого сообщения
    /// </summary>
    /// <param name="openText">открытое сообщение</param>
    public async Task<string> Encrypted(string openText)
    {
        var encryptedText = "";

        foreach (var t in openText)
        {
            if (t == ' ')
            {
                encryptedText += ' ';
                continue;
            }

            encryptedText += await FindChar(t, 0);
        }

        return encryptedText;
    }

    /// <summary>
    /// Функция расшифрования зашифрованного сообщения
    /// </summary>
    /// <param name="encryptText">зашифрованное сообщение</param>
    /// <returns></returns>
    public async Task<string> Decrypted(string encryptText)
    {
        var decryptText = "";

        foreach (var t in encryptText)
        {
            if (t == ' ')
            {
                decryptText += ' ';
                continue;
            }

            decryptText += await FindChar(t, 1);
        }

        return decryptText;
    }

    /// <summary>
    /// Функция поиска нужного симвала в квадрате
    /// </summary>
    /// <param name="inChar">входящий символ</param>
    /// <param name="type">0 - шифрование; 1 - расшифрование</param>
    private async Task<char> FindChar(char inChar, int type)
    {
        var x = 0;
        var y = 0;

        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (inChar != _polybianSquare[i, j]) continue;
                x = i;
                y = j;

                break;
            }
        }

        switch (type)
        {
            case 0 when x != 7:
                x += 1;
                break;
            case 0:
                x = 0;
                break;
            case 1 when x != 0:
                x -= 1;
                break;
            case 1:
                x = 7;
                break;
            default:
                break;
        }

        return _polybianSquare[x, y];
    }
}