using System;

namespace PayrollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Karyawan karyawanA = new Karyawan("Agus Kuncoro", "081234567891", "Chairman", "897654321");
            karyawanA.showEmployeeData();
            Console.WriteLine("\n");
            karyawanA.showSalaryTotal(6); //argumen untuk mengisi parameter jumlah hari cuti
            
        }
    }

    class Karyawan
    {
        public string Name;
        public string Phone;
        public string Position;
        public string accountNumber;
        public Karyawan(string Name, string Phone, string Position, string accountNumber)
        {
            this.Name = Name;
            this.Phone = Phone;
            this.Position = Position;
            this.accountNumber = accountNumber;
        }

       public double Salary()
        {
            double salary=0;
            switch (this.Position)
            {
                case "Chairman":
                    salary = 30000000;
                    break;
                case "Manager":
                    salary = 15000000;
                    break;
                case "Employee_1":
                    salary = 7500000;
                    break;
                case "Employee_2":
                    salary = 6000000;
                    break;

            }
            return salary;
        }

        public double cutLeave(int dayLeave) //Method menghitung potongan cuti
        {
            double cut = 0;
            //Jika Cuti kurang dari sama dengan 5 hari maka potongan per harinya = 40% gaji/30
            //Jika Cuti lebih dari 5 hari maka mulai hari ke-6 potongan per harinya = 50% gaji/30
            
            for(int i=1; i<=dayLeave; i++)
            {
                if (i <= 5)
                {
                    cut += Salary()/30*40/100;
                }
                else
                {
                    cut += Salary()/30*50/100;
                }
            }
            return cut;
        }

        public void showEmployeeData()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Phone : {Phone}");
            Console.WriteLine($"Position : {Position}");
            Console.WriteLine($"Account Number : {accountNumber}");
            Console.WriteLine($"Salary : {Salary()}");
        }

        public void showSalaryTotal(int dayLeave)
        {
            double totalSalary = Salary() - cutLeave(dayLeave);
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Basic Salary: {Salary()}");
            Console.WriteLine($"Day Leaves : {dayLeave} days");
            Console.WriteLine($"Cut Leaves : {cutLeave(dayLeave)}");
            Console.WriteLine($"Total Salary : {Salary()} - {cutLeave(dayLeave)} = {totalSalary}");
            
        }
    }

}