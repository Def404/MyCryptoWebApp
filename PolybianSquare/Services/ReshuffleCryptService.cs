namespace PolybianSquare.Services;

public class ReshuffleCryptService : IReshuffleCryptService
{
	public async Task<string> Encrypted(string openText)
	{
		var encryptedText = "";

		var openTextLength = openText.Length;
		var divisors = Divisors(openTextLength);

		var divId = 0;
		var a = 0;
		var b = 0;

		if (divisors.Count % 2 == 0)
		{
			divId = (divisors.Count / 2) - 1;

			a = divisors[divId];
			b = divisors[divisors.Count - 1 - divId];
		}
		else
		{
			divId = divisors.Count / 2;
			a = divisors[divId];
			b = divisors[divId];
		}

		if (a * b > openTextLength)
		{
			var t = a * b - openTextLength;

			for (int i = 0; i < t; i++)
			{
				openText += " ";
			}
		}

		var table = new char[a, b];

		var a1 = 0;
		var b1 = 0;

		for (int i = 0; i < a * b; i++)
		{
			table[a1, b1] = openText[i];

			a1 += 1;

			if (a1 == a)
			{
				a1 = 0;
				b1 += 1;
			}
		}

		for (int i = 0; i < a; i++)
		{
			for (int j = 0; j < b; j++)
			{
				encryptedText += table[i, j];
			}
		}

		return encryptedText.Trim();
	}

	public async Task<string> Decrypted(string encryptText)
	{
		var decryptText = "";

		var encryptTextLength = encryptText.Length;
		var divisors = Divisors(encryptTextLength);
		
		var divId = 0;
		var a = 0;
		var b = 0;

		if (divisors.Count % 2 == 0)
		{
			divId = (divisors.Count / 2) - 1;

			a = divisors[divId];
			b = divisors[divisors.Count - 1 - divId];
		}
		else
		{
			divId = divisors.Count / 2;
			a = divisors[divId];
			b = divisors[divId];
		}

		if (a * b > encryptTextLength)
		{
			var t = a * b - encryptTextLength;

			for (int i = 0; i < t; i++)
			{
				encryptText += " ";
			}
		}
		
		var table = new char[a, b];

		
		var e = 0;

		for (int i = 0; i < a; i++)
		{
			for (int j = 0; j < b; j++)
			{
				table[i, j] = encryptText[e++];
			}
		}
		
		var a1 = 0;
		var b1 = 0;
		
		for (int i = 0; i < a * b; i++)
		{
			decryptText += table[a1, b1];

			a1 += 1;

			if (a1 == a)
			{
				a1 = 0;
				b1 += 1;
			}
		}
		
		return decryptText.Trim();
	}

	private static List<int> Divisors(int n)
	{
		var divisors = new List<int>();

		for (var i = 2; i * i <= n; i++)
		{
			if (n % i == 0)
			{
				divisors.Add(i);

				if (i * i != n)
					divisors.Add(n / i);
			}
		}

		if (divisors.Count == 0)
		{
			n += 1;
			divisors = Divisors(n);
		}

		divisors.Sort();


		return divisors;
	}
}