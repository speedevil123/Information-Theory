using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    internal class Class1
    {
        public class CheckCodes
        {
            public static void CheckCode(Dictionary<string, string> ToCheck)
            {
                List<string> symbols = new List<string>(ToCheck.Keys);
                List<string> codes = new List<string>(ToCheck.Values);
                Console.WriteLine("Кол-во букв: " + ToCheck.Count);

                for(int i = 0; i < symbols.Count; i++)
                {
                    for(int j = 0; j < symbols.Count; j++)
                    {
                        if (codes[i] == codes[j])
                        {
                            if(i == j)
                            {
                                continue;
                            }
                            else
                                Console.WriteLine("Совпадение!" + " Буква: " + symbols[i] + " Коды:" + codes[i] + " , " + codes[j]);
                        }
                    }
                }
            }
        }

        public class DeletePunctuation
        {
            public static string DeletePunc(string text)
            {
                string punctuation = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

                foreach (char c in punctuation)
                {
                    text = text.Replace(c.ToString(), "");
                }
                return text;
            }
        }

        public class Coding
        {
            public static string Encoding(string text, Dictionary<string, string> dict)
            {
                string result = string.Empty;
                List<string> symbols = new List<string>(dict.Keys);
                List<string> codes = new List<string>(dict.Values);

                for(int i = 0; i < text.Length; i++)
                {
                    for(int j = 0; j < codes.Count; j++)
                    {
                        if (text[i].ToString() == symbols[j])
                        {
                            result += codes[j];
                        }
                    }
                }
                return result;
            }

            public static string Decoding(string text, Dictionary<string, string> dict)
            {
                string result = string.Empty;
                List<string> symbols = new List<string>(dict.Keys);
                List<string> codes = new List<string>(dict.Values);

                string temp = string.Empty;
                for (int i = 0; i < text.Length; i++)
                {
                    temp += text[i];
                    for (int j = 0; j < codes.Count; j++)
                    {

                        if (temp == codes[j])
                        {
                            result += symbols[j];
                            temp = string.Empty;
                        }
                    }
                }
                return result;
            }
        }


        static void Main()
        {
            Dictionary<string, string> ShennonCode = new Dictionary<string, string>()
            {
                {" ", "111" },
                {"о", "110" },
                {"а", "1011" },
                {"е", "1010" },
                {"н", "1001" },
                {"и", "1000" },
                {"т", "0111" },
                {"с", "01101" },
                {"р", "01100" },
                {"л", "0101" },
                {"в", "01001" },
                {"к", "01000" },
                {"м", "00111" },
                {"п", "00110" },
                {"у", "00101" },
                {"д", "001001" },
                {"я", "001000" },
                {"ь", "000111" },
                {"ы", "000110" },
                {"б", "000101" },
                {"з", "000100" },
                {"г", "000011" },
                {"ч", "0000101" },
                {"й", "0000100" },
                {"ш", "0000011" },
                {"х", "0000010" },
                {"ю", "00000011" },
                {"ж", "00000010" },
                {"щ", "000000011" },
                {"э", "000000010" },
                {"ц", "000000001" },
                {"ф", "000000000" }

            };
            Dictionary<string, string> HaffmanCode = new Dictionary<string, string>()
            {
                {" ", "111" },
                {"о", "1101" },
                {"а", "1011" },
                {"е", "1001" },
                {"н", "0111" },
                {"и", "0101" },
                {"т", "0011" },
                {"с", "0001" },
                {"р", "11001" },
                {"л", "11000" },
                {"в", "10101" },
                {"к", "10001" },
                {"м", "01101" },
                {"п", "01001" },
                {"у", "01000" },
                {"д", "00101" },
                {"я", "00001" },
                {"ь", "00000" },
                {"ы", "101001" },
                {"б", "100001" },
                {"з", "100000" },
                {"г", "011001" },
                {"ч", "001001" },
                {"й", "001000" },
                {"ш", "1010001" },
                {"х", "0110001" },
                {"ю", "10100001" },
                {"ж", "01100001" },
                {"щ", "101000001" },
                {"э", "101000000" },
                {"ц", "011000001" },
                {"ф", "011000000" }
            };


            string filePath = "input.txt";
            string text = File.ReadAllText(filePath).ToLower();
;
            text = DeletePunctuation.DeletePunc(text);
            //Метод Шеннона-Фано

            Console.WriteLine("Метод Шеннона-Фано");
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Исходный текст: \n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");

            text = Coding.Encoding(text, ShennonCode);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Закодированный текст: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");

            text = Coding.Decoding(text, ShennonCode);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Декодированный текст: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");


            //Метод Хаффмана

            text = File.ReadAllText(filePath).ToLower();
            text = DeletePunctuation.DeletePunc(text);

            Console.WriteLine("Метод Хаффмана");
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Исходный текст: \n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");

            text = Coding.Encoding(text, HaffmanCode);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Закодированный текст: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");

            text = Coding.Decoding(text, HaffmanCode);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Декодированный текст: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------------------------------------" +
                "-----------------------------------------" +
                "---------------");


        }
    }
}
