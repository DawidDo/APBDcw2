using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using cw2.Models;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = "/Users/dawiddolowy/Desktop/Studia/s7/APBDx2/workplaceCW1/cw2/cw2/Data/dane.csv";
            string outputPath = "/Users/dawiddolowy/Desktop/Studia/s7/APBDx2/workplaceCW1/cw2/cw2/Data/output.csv";
            string format = "json";


            FileInfo fi = new FileInfo(csvPath);
            StreamReader stream = new StreamReader(fi.OpenRead());
            string x = null;
            if ((x = stream.ReadLine()) == null)
            {
                throw new ArgumentException("Podany plik nieistnieje lub jest pusty");
            }

            string line = null;
            HashSet<Student> lista = new HashSet<Student>();
            List<String> listaBad = new List<String>();
            FileInfo fiW = new FileInfo(outputPath);
            StreamWriter streamWriter = new StreamWriter(fiW.OpenWrite());

            bool isCorrect = true;
            while ((line = stream.ReadLine()) != null)
            {
                isCorrect = true;
                string[] datas = line.Split(",");

                foreach (string s in datas)
                {
                    if (s == " " || s=="")
                    {
                        listaBad.Add(line);
                        isCorrect = false;
                        break;
                    }

                }

                if (isCorrect == true)
                {
                    lista.Add(new Student()
                    {
                        FirstName = datas[0],
                        LastName = datas[1],
                        Kierunek = datas[2],
                        Tryb = datas[3],
                        Number = datas[4],
                        Data = datas[5],
                        Mail = datas[6],
                        Matka = datas[7],
                        Ojciec = datas[8]
                    });
                }
            }

            foreach (Student s in lista)
            {
                streamWriter.Write(JsonSerializer.Serialize(s));
                streamWriter.WriteLine(" ");
            }

            streamWriter.Close();

            FileInfo fiB =
                new FileInfo("/Users/dawiddolowy/Desktop/Studia/s7/APBDx2/workplaceCW1/cw2/cw2/Data/log.txt");
            StreamWriter streamWriterBad = new StreamWriter(fiB.OpenWrite());
            foreach (string s in listaBad)
            {
                streamWriterBad.Write(s);
                streamWriterBad.WriteLine(" ");
            }

            streamWriterBad.Close();
        }
    }
}