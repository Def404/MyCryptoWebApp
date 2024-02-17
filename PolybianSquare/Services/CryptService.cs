namespace PolybianSquare.Services;

public class CryptService : ICryptService
{
    private static char[] Alphabet =
    {
        'у', '-', 'к', 'т', 'е', '3', 'р', '6', 'а', '7', 'ь', '9', 'г', '8', '/', 'ц', '+', '%', '*', '5', '(', ':',
        'о', 'э', ',', 'щ', '@', '2', '4', ';', 'п', '0', 'б', 'ё', ')', '!', 'ъ', '[', '?', 'ю', '№', 'ы', 'и', 'д',
        ']', 'в', 'л', '}', 'з', 'м', 'ф', 'ж', '.', 'й', '{', 'х', '1', '_', 'я', 'н', '#', 'ч', 'с', 'ш'
    };

    private char[,] PolybianSquare;

    public CryptService()
    {
        PolybianSquare = InitSquare();
    }

    public char[,] InitSquare()
    {
        var result = new char[8, 8];

        var r = 0;
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                result[i, j] = Alphabet[r++];
            }
        }

        return result;
    }

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
            var x = 0;
            var y = 0;

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (t == PolybianSquare[i, j])
                    {
                        x = i;
                        y = j;

                        break;
                    }
                }
            }

            if (x != 7)
            {
                x += 1;
            }
            else
            {
                x = 0;
            }

            var findChar = PolybianSquare[x, y];

            encryptedText += findChar;
        }

        return encryptedText;
    }

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
            
            var x = 0;
            var y = 0;

            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    if (t == PolybianSquare[i, j])
                    {
                        x = i;
                        y = j;

                        break;
                    }
                }
            }

            if (x != 0)
            {
                x = x - 1;
            }
            else
            {
                x = 7;
            }

            var findChar = PolybianSquare[x, y];


            decryptText += findChar;
        }

        return decryptText;
    }
}