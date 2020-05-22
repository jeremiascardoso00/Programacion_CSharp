using System;

namespace manejoCadenas
{
	class Program
	{

		static void Main(string[] args)
		{
			string Charset = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz";
			int Clave = 17;
			string MensajeCifrado = "fcyb ry pbabpüzüragb ehr yyruñ qrfqr qragéb rf ry jréqñqréb pbabpüzüragb";

			Console.WriteLine("Mensaje decifrado:\n{0}", Descifrar(MensajeCifrado, Charset, Clave));
		}

		static string Descifrar(string Mensaje, string Charset, int Clave)
		{
			string Out = "";
			for (int i = 0; i < Mensaje.Length; i++)
			{
				if (!Charset.Contains(Mensaje[i].ToString())) Out += Mensaje[i];
				else
				{
					int ix = Charset.IndexOf(Mensaje[i]);
					for (int j = 0; j < Clave; j++)
					{
						if (ix == 0) ix = Charset.Length - 1;
						else ix--;
					}
					Out += Charset[ix];
				}
			}
			return Out;
		}
	}
}