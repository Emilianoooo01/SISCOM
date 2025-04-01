using System;
using System.Linq;
using System.Text;

namespace SISCOM.Models
{
    public class CaptchaModel
    {

        public string GenerarCaptcha()
        {
            Random random = new Random();
            StringBuilder captcha = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                int numero = random.Next(0, 9);
                char letra = (char)('A' + random.Next(0, 26));

                captcha.Append(numero);
                captcha.Append(letra);
            }

            return captcha.ToString();
        }
    }
}