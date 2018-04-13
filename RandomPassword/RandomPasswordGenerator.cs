using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomPassword
{

    public class RandomPasswordGenerator
    {
        private string specialChar = @"~!@#$%^&*()_-+={}[]|\\<>/?";

        public string GetPassword(int length, CharType[] types)
        {
            Random r = new Random();

            StringBuilder password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {

                CharType currentType = types[r.Next(types.Length)];

                switch (currentType)
                {
                    case CharType.Number:
                        password.Append(r.Next(10));
                        break;
                    case CharType.Upper:
                        password.Append((char)(r.Next(26) + 'A'));
                        break;
                    case CharType.Lower:
                        password.Append((char)(r.Next(26) + 'a'));
                        break;
                    case CharType.Special:
                        password.Append(specialChar[r.Next(specialChar.Length)]);
                        break;
                    default:
                        break;
                }
            }


            return password.ToString();
        }




    }
}
