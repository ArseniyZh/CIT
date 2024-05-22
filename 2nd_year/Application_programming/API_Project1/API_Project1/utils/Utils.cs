using System.Text;
using System.Security.Cryptography;

namespace API_Project1.utils
{
	public class Utils
	{
		public Utils()
		{
		}

        public static string HashString(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Вычисление хеша
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Конвертация байтового массива в строку
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

}
}

