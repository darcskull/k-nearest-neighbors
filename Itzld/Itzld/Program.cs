using System;

namespace Itzld
{
    class Program
    {
        static TableValues values = new TableValues();
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Моля въведете брой на записите, които да бъдат генерирани");
            n = int.Parse(Console.ReadLine());
            TableData[] data = GenerateTable(n);
            Visualize(data);
            Console.WriteLine("Моля въведете ниво на анонимност");
            int nK = int.Parse(Console.ReadLine());
            Console.WriteLine("Моля изберете броя на QI");
            int nQ = int.Parse(Console.ReadLine());
            if (nQ > 5)
                Console.WriteLine("Въвели сте невалиден брой Квази идентификатори");
            else
            {
                TableData[] anonymous = Anonymous(data, nQ, nK);
                VisualizeAnonymous(anonymous, nQ);
            }

        }
        
        //Генерира начални стойности за таблицата
        public static TableData[] GenerateTable(int n)
        {
            TableData[] data = new TableData[n];

            for (int i=0; i < data.Length; ++i)
            {
                data[i] = new TableData();
                data[i].Gender = values.Gender(i);
                data[i].Age = values.Age();
                data[i].Zip = values.Zip();
                data[i].Color = values.Color();
                data[i].Salary = values.Salary();
            }

            return data;
        }

        //Визуализира началната таблица на данни
        public static void Visualize(TableData[] data)
        {
            string sp = "   ";
            Console.WriteLine("Gender"+sp+"Years"+sp+"Zip"+sp+"Color"+sp+"Salary");
            Console.WriteLine();
            for(int i=0; i < data.Length; ++i)
            {
                Console.WriteLine(data[i].Gender+"   "+ data[i].Age+"   "+data[i].Zip+"   "+data[i].Color+"   "+data[i].Salary);
            }
            Console.WriteLine();
        }

        // Визуализира анонимизираната таблица с данни
        public static void VisualizeAnonymous(TableData[] data, int nQ)
        {
            string sp = "  ";
            string pr = "  ";
            if (nQ >= 3)
            {
                sp = "          ";
                pr = "       ";
            }
            if (nQ >= 4)
                pr = "          ";

            Console.WriteLine("Zip" + "   " + "Salary" + "   " + "Gender" + sp + "Years"+ pr + "Color" );
            Console.WriteLine();
            for (int i = 0; i < data.Length; ++i)
            {
                Console.WriteLine(data[i].Zip + "   " + data[i].Salary + "   " + data[i].Gender + "   " + data[i].Age+"   " + data[i].Color);
            }
            Console.WriteLine();
        }

        //Анонимизира таблицата с данни
        public static TableData[] Anonymous(TableData[] data, int nQ, int nK)
        {
            TableData[] dataAn = new TableData[data.Length];

            for (int i = 0; i < data.Length; ++i)
            {
                dataAn[i] = new TableData();
                if (nQ >= 3)
                    dataAn[i].Gender = values.GenderAnonymous();
                else
                    dataAn[i].Gender = data[i].Gender;
                if (nQ >= 2)
                    dataAn[i].Age = values.AgeAnonymous(data[i].Age, nK);
                else
                    dataAn[i].Age = data[i].Age;
                dataAn[i].Zip = values.ZipAnonymous(data[i].Zip, nK);
                if (nQ >= 4)
                    dataAn[i].Color = values.ColorAnonymous(data[i].Color, nK);
                else
                    dataAn[i].Color = data[i].Color;
                if (nQ >= 5)
                    dataAn[i].Salary = values.SalaryAnonymous(data[i].Salary, nK);
                else
                    dataAn[i].Salary = data[i].Salary;
            }

            return dataAn;
        }
    }
}
