using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace struct_ism
{
    class Program
    {
        public struct Student
        {
            public string Name;
        	public int Group;
            public int[] Ses;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            string path = @"F:\tmp\struct\1\student.txt";
            string all = Read(path);
            string[] all_mas = GetMas(all);
            //Console.WriteLine(all_mas[0]);
            //Console.WriteLine(all_mas[1]);
            //Console.WriteLine(all_mas[2]);
            //string[] sort_mas = SORT(all_mas);
            //Console.WriteLine(sort_mas[0]);
            //Console.WriteLine(sort_mas[1]);
            //Console.WriteLine(sort_mas[2]);
            Student[] stud = Get_Mas(all_mas);
            stud = Sort(stud);
            //Console.WriteLine(stud[0].Ses[4]);
            Write(stud);
        }

        static Student[] Sort(Student[] st)
        {
            int cout = st.Length;
            int[] sort = new int[cout];
            Student tmp1;
            int i1 = 0;
            for (int i = 0; i < cout; i++)
            {
                sort[i] = st[i].Group;
            }
            for (int o = 0; o < cout * cout; o++)
            {
                for (int i = 0; i < cout - 1; i++)
                {
                    if (sort[i] > sort[i + 1])
                    {
                        i1 = sort[i]; tmp1 = st[i];
                        sort[i] = sort[i + 1]; st[i] = st[i + 1];
                        sort[i + 1] = i1; st[i + 1] = tmp1;
                    }
                }
            }
            return st;

         }
        static void Write(Student[] st)
        {
            int lic = 0;
            int cout = st.Length;
            for (int i = 0; i < cout; i++)
            {
                if (mid(st[i].Ses) >= 4) { Console.WriteLine(st[i].Name + " " + st[i].Group.ToString()); lic++; }
            }
            if (lic == 0) Console.WriteLine("Немає студентів з балом вище 4");
        }
        static double mid(int[] mas)
        {
            int cout = mas.Length;
            double all = 0;
            for (int i = 0; i < cout; i++)
            {
                all += mas[i];
            }
            return (all / cout);
        }
        static string[] SORT(string[] mas)
        {
            int cout = mas.Length;
            double[] sort = new double[cout];
            double[] sort_out = new double[cout];
            string[] oo = new string[cout];
            Regex ch = new Regex(@"(\d*[.,]?\d+)");
            MatchCollection tmp = ch.Matches("");
            for (int i = 0; i < cout; i++)
            {
                tmp = ch.Matches(mas[i]);
                sort[i] = double.Parse(tmp[0].Groups[0].Value);
            }
            double i1 = 0;
            string tmp1 = "";
            //Array.Sort(sort_out);
            //for (int i = 0; i < sort_out.Length; i++) Console.WriteLine(sort_out[i]+" ");
            for (int o = 0; o < cout*cout; o++)
            {
                for (int i = 0; i < cout - 1; i++)
                {
                    if (sort[i] > sort[i + 1])
                    {
                        i1 = sort[i]; tmp1 = mas[i];
                        sort[i] = sort[i + 1]; mas[i] = mas[i + 1];
                        sort[i + 1] = i1; mas[i + 1] = tmp1;
                    }

                }
            }
            oo = mas;
            return oo;
        }

        static Student[] Get_Mas(string[] mas)
        {
            int count = mas.Length;
            Student[] tmp = new Student[count];
            for(int i=0;i< count;i++)
            {
                Regex ch = new Regex(@"([a-zA-ZА-Яа-яїЇіІЄє])+\s(([a-zA-ZА-Яа-яїЇіІЄє])\.){2}");
                MatchCollection tmp_1 = ch.Matches(mas[i]);
                Regex ch_1 = new Regex(@"(\d+([\.,]\d+)?)");
                MatchCollection tmp_2 = ch_1.Matches(mas[i]);
                tmp[i].Name = tmp_1[0].Groups[0].Value;
                tmp[i].Group = int.Parse(tmp_2[0].Groups[0].Value);
                int[] a = new int[5];
                tmp[i].Ses = new int[5];
                for (int o=1; o<tmp_2.Count;o++)
                {
                    a[o-1] = int.Parse(tmp_2[o].Groups[0].Value);
                }
                tmp[i].Ses = a;
            }
            return tmp;
        }
        static string Read(string path)
        {
            string all = "";
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding(1251)))
                {
                    all = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return all;
        }
        static string[] GetMas(string all)
        {
            int cout = 0, lenth = all.Length;
            for (int i = 0; i < lenth; i++)
            {
                if (all[i].ToString() == "\n") cout++;
            }
            cout++;
            //Console.WriteLine(cout.ToString());
            string[] mas = new string[cout];
            for (int i = 0, i1 = 0; i < lenth; i++)
            {
                if (all[i].ToString() != "\n") mas[i1] += all[i];
                if (all[i].ToString() == "\n") i1++;
            }
            return mas;
        }
    }
}
