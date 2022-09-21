using System;
using System.Collections.Generic;
using System.Text;

namespace Itzld
{
    public class TableValues
    {
        Random random = new Random();
        public string Gender(int i)
        {
            if (i % 2 == 0)
                return "male  ";
            return "female";

        }

        public string Age()
        {
            return random.Next(20, 90).ToString();
        }

        public string Zip()
        {
            return random.Next(4200, 4499).ToString();
        }

        public string Color()
        {
            string [] arr = new string[]{"blue ","green","brown"};
            int index = random.Next(0, 2);
            return arr[index];
        }

        public string Salary()
        {
            int value = random.Next(1000, 9999);
            string salary = value + "$";
            return salary;
        }

        public string GenderAnonymous()
        {
            return "{male:female}";
        }

        public string AgeAnonymous(string age, int nK)
        {
            if (nK > 4)
                return "20<age<100";

            return (int.Parse(age[0].ToString()) - nK + 2) + "0<age<"+(int.Parse(age[0].ToString())+nK-1)+"0";
        }

        public string ZipAnonymous(string zip, int nK)
        {
            StringBuilder builder = new StringBuilder(zip);
            for(int i=1; i < nK && i<5; ++i)
            {
                builder[builder.Length - i] = '*';
            }

            return builder.ToString();
        }

        public string ColorAnonymous(string color, int nK)
        {
            if (nK == 2)
            {
                switch (color)
                {
                    case "blue ":
                        return"{blue;green}";
                    case "green":
                        return "{green;brown}";
                    case "brown":
                        return "{brown;blue}";
                    default:
                        return "";
                }
            }
            else
                return "{blue;green;brown}";

        }

        public string SalaryAnonymous(string sal, int nK)
        {
            StringBuilder builder = new StringBuilder(sal);
            for (int i = 1; i < nK && i < 5; ++i)
            {
                builder[builder.Length - i-1] = '*';
            }

            return builder.ToString();
        }
    }
}
