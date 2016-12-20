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
            string output = String.Format("Task 1 password: {0}, Task 2 password: {1}", 
                "bypass",//GetTask1(),
                GetTask2());
            return output;
        }
        private string GetTask1()
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
                    Console.WriteLine(password);
                }
                count++;
                done = password.Length == 8 ? true : false;
                //Console.Write(count.ToString());
            }
            return password;
        }
        private string GetTask2()
        {
            string hash;
            int doneCount = 0;
            bool done = false;
            string[] password = new string[8];
            string output = String.Empty;
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
                    int pos; 
                    bool success = Int32.TryParse(hash.Substring(5, 1), out pos);
                    if (success)
                    {
                        if(pos < 8)
                        {
                            string key = hash.Substring(6, 1);
                            if(password[pos] == null)
                            {
                                password[pos] = key;
                                doneCount++;
                            }
                            Console.WriteLine(key);

                        }
                    }
                }
                count++;
                done = doneCount == 8 ? true : false;
                //Console.Write(count.ToString());
            }
            foreach (var item in password)
            {
                output += item;
            }
            return output;
        }
        

    }
}
