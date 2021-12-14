using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Authentication
{
    class Program : User

    {
        static void Main(string[] args)
        {
            int exit = 0;
            List<User> ListUser = new List<User>();
            do
            {
                Console.WriteLine("************************************");
                Console.WriteLine("|    Program Authentication        |");
                Console.WriteLine("*************************************");
                Console.WriteLine("1. Create user");
                Console.WriteLine("2. Show user");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Update User");
                Console.WriteLine("5. Delete User");
                Console.WriteLine("6. Login User");
                Console.WriteLine("7. Exit");
                Console.WriteLine("************************************");
                Console.WriteLine("\n");
                int c;
                Console.WriteLine(" Input Pilihan Anda :  ");
                try
                {
                    c = int.Parse(Console.ReadLine());
                    switch (c)
                    {
                        case 1:
                            Console.Clear();
                            DaftarUser(ListUser);
                            Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            TampilUser(ListUser);
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("————————————————————————————————————————");
                            Console.WriteLine("Menu Search User");
                            Console.WriteLine("————————————————————————————————————————");
                            Console.Write("Username : ");
                            string usern = Console.ReadLine();
                            SearchUser(ListUser, usern);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            UpdateUser(ListUser);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            DeleteUser(ListUser);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 6:
                            Console.Clear();
                            LoginUser(ListUser);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 7:
                            exit = 7;
                            Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Input Kembali");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                }



                catch (FormatException)
                {
                    Console.WriteLine(" Inputan Salah!!! Ulangi-->Tekan ENTER");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (exit != 7);
        }

        public static void DaftarUser(List<User> ListUser)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("         Menu Daftar User            ");
            Console.WriteLine("==================================== ");

            bool cekDpnBlk = false;
            string dpn, blk;

            Console.WriteLine(" Input Nama Depan : ");
            dpn = (Console.ReadLine());

            Console.WriteLine(" Input Nama Belakang : ");
            blk = (Console.ReadLine());

            if (dpn == "" || blk == "")
            {
                Console.WriteLine("Input not Valid!");
                Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
            }
            else
            {
                cekDpnBlk = true;
            } while (cekDpnBlk == false) ;

            Random rnd = new Random();
            int rFirst = rnd.Next(1, 99);
            int rSecond = rnd.Next(100);
            string usern = dpn.Substring(0, 2) + blk.Substring(0, 2) + rFirst + rSecond;

            bool cekPass = false;
            string pass;

            do
            {
            z:
                Console.WriteLine(" Input Password = ");
                pass = Console.ReadLine();

                var hasNumber = new Regex(@"[0-9]+");
                var hasUppperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Char = new Regex(@".{8,}");

                var isVallited = hasNumber.IsMatch(pass) && hasUppperChar.IsMatch(pass) && hasMinimum8Char.IsMatch(pass);

                if (pass == "")
                {
                    Console.WriteLine();
                    Console.WriteLine("Input Not Valid");
                }
                else if (!isVallited)
                {
                    Console.WriteLine("Passwor harus mengandung Huruf Besar, Angka dan Simbol");
                    goto z;

                }
                else
                {
                    cekPass = true;
                }
            } while (cekPass == false);


            ListUser.Add(new User(dpn, blk, usern, pass));

            Console.WriteLine("\n");
            Console.WriteLine("*** Daftar anda telah berhasil Terimakasih ***");
            /*Console.WriteLine();*/
            Console.ReadLine();
            Console.Clear();
        }
        public static void TampilUser(List<User> ListUser)
        {
            Console.WriteLine("************************************");
            Console.WriteLine("  Menu Tampil User    ");
            Console.WriteLine("************************************");

            if (ListUser.Count == 0)
            {
                Console.WriteLine("Belum ada user terdaftar");
                return;
            }

            foreach (var p in ListUser)
            {
                Console.WriteLine($"Nama : {(p.FirstName)} {(p.LastName)}");
                Console.WriteLine($"username : {p.UserName}");
                Console.WriteLine($"Password :  {p.password}");
                Console.WriteLine();
                Console.WriteLine("————————————————————————————————————————");

            }
        }


        public static void SearchUser(List<User> ListUser, string usern)
        {
            User c = ListUser.FirstOrDefault(x => x.UserName == usern);
            if (c == null)
            {
                Console.WriteLine("Username Tidak Ditemukan");
                return;
            }
            else
            {
                foreach (var p in ListUser)
                {
                    if (usern == p.UserName)
                    {
                        Console.WriteLine($"Nama : {(p.FirstName)} {p.LastName}");
                        Console.WriteLine($"username : {p.UserName}");
                        Console.WriteLine($"Password :  {p.password}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void UpdateUser(List<User> ListUser)
        {
            Console.WriteLine("————————————————————————————————————————");
            Console.WriteLine("Menu Update User");
            Console.WriteLine("————————————————————————————————————————");

            Console.Write("username : ");
            string a = Console.ReadLine();

            User c = ListUser.FirstOrDefault(x => x.UserName == a);
            if (c == null)
            {
                Console.WriteLine("Username Tidak Ditemukan");
                return;
            }
            else
            {
                foreach (var p in ListUser)
                {
                    if (a == p.UserName)
                    {
                        Console.WriteLine($"Nama : {(p.FirstName)} {p.LastName}");
                        Console.WriteLine($"username : {p.UserName}");
                        Console.WriteLine($"Password :  {p.password}");

                        var hasNumber = new Regex(@"[0-9]+");
                        var hasUpperChar = new Regex(@"[A-Z]+");
                        var hasMinimum8Chars = new Regex(@".{8,}");

                    z:
                        Console.Write("Input ganti password = ");
                        string passbaru = Console.ReadLine();

                        var isValidated = hasNumber.IsMatch(passbaru) && hasUpperChar.IsMatch(passbaru) && hasMinimum8Chars.IsMatch(passbaru);

                        if (isValidated)
                        {
                            p.password = BCrypt.Net.BCrypt.HashPassword(passbaru);
                            Console.WriteLine($"Password baru = {p.password}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Password harus mengandung huruf besar, angka dan simbol");
                            goto z;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void DeleteUser(List<User> ListUser)
        {
            Console.WriteLine("————————————————————————————————————————");
            Console.WriteLine("Menu Delete User");
            Console.WriteLine("————————————————————————————————————————");

            Console.Write("Username : ");
            string a = Console.ReadLine();

            User c = ListUser.FirstOrDefault(x => x.UserName == a);
            if (c == null)
            {
                Console.WriteLine("Username Tidak Ditemukan");
                return;
            }
            else
            {
                foreach (var p in ListUser)
                {
                    if (a == p.UserName)
                    {
                        ListUser.Remove(p);
                        Console.WriteLine("Data user sudah dihapus");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
            }
        }
        public static void LoginUser(List<User> ListUser)
        {
            Console.Write("Username : ");
            string a = Console.ReadLine();

            Console.Write("Password : ");
            string b = Console.ReadLine();

            if (ListUser.Exists(item => item.UserName == a && BCrypt.Net.BCrypt.Verify(b, item.password)))
            {
                Console.WriteLine("Login Berhasil!!");
                Console.ReadKey();
                Console.Clear();
            }
            else if (ListUser.Exists(item => item.UserName != a))
            {
                Console.WriteLine("username salah");
                Console.ReadKey();
            }
            else if (ListUser.Exists(item => item.UserName == a && BCrypt.Net.BCrypt.Verify(b, item.password) == false))
            {
                Console.WriteLine("password salah");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Username Tidak DItemukan");
            }
            Console.WriteLine();
        }
    }
}

