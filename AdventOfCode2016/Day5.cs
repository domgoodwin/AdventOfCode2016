using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day5
    {
        public string InputText { get; private set; }

        public Day5(string inputText)
        {
            InputText = inputText;
        }

        public string Process()
        {
            string hash;
            bool done = false;
            string password = "";
            int count = 0;
            while (!done)
            {
                string input = InputText + count.ToString();
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                    //StringBuilder sBuilder = new StringBuilder();
                    //for (int i = 0; i < data.Length; i++)
                    //{
                    //    sBuilder.Append(data[i].ToString("x2"));
                    //}
                    hash = string.Empty;
                    StringBuilder hex = new StringBuilder(data.Length * 2);
                    foreach (byte b in data)
                        hex.AppendFormat("{0:x2}", b);
                    hash = hex.ToString();
                }
                if (hash.Substring(0, 5) == "00000")
                {
                    password += hash.Substring(5, 1);
                }
                count++;
                done = password.Length == 8 ? true : false;
                Console.Write(count.ToString());
            }
            return password;
        }
        

    }
}
