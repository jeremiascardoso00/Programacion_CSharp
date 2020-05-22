using System;
using System.Xml.Linq;

namespace manejoCadenas
{
	class Program
	{

		static void Main(string[] args)
		{
			string Caracteres = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz";
			//TextoCifrado cifrado para probar: fcyb ry pbabpüzüragb ehr yyruñ qrfqr qragéb rf ry jréqñqréb pbabpüzüragb
			Console.WriteLine("Ingrese el texto cifrado");
			string TextoCifrado = Console.ReadLine();
			//La clave es 17
			Console.WriteLine("Ingrese la clave");
			int Clave = int.Parse(Console.ReadLine());

			Console.WriteLine($"Mensaje descifrado: { Descifrar(TextoCifrado, Caracteres, Clave) }");

			Console.ReadKey();
		}

		static string Descifrar(string TextoCifrado, string Caracteres, int Clave)
		{
			string TextoDescifrado = "";
			for (int i = 0; i < TextoCifrado.Length; i++)
			{
				if (!Caracteres.Contains(TextoCifrado[i].ToString())) TextoDescifrado += TextoCifrado[i];
				else
				{
					int indice = Caracteres.IndexOf(TextoCifrado[i]);
					for (int j = 0; j < Clave; j++)
					{
						if (indice == 0)
						{
							indice = Caracteres.Length - 1;
						}
						else 
						{
							indice--;
						}
					}
					TextoDescifrado += Caracteres[indice];
				}
			}
			return TextoDescifrado;
		}
	}
}