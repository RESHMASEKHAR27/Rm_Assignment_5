using System.Runtime.Serialization.DataContracts;
using System.Xml.Linq;

namespace Rm_Assignment_5
{
    //All classes should have datamembers like empid,name,dept,desg and basic salary
    

    public interface GovtRules
    {
        public double EmployeePF(double basicSalary);
        public string LeaVeDetails();
        public double gratuityAmount(float serviceCompleted, double basicSalary);
    }
    public class Employee
    {
       
        public int empid { get; set; }
        public string name { get; set; }
        public string dept { get; set; }
        public string desg { get; set; }
        public int basic_salary { get; set; }

        // All values should be assigned through parameterized constructor
        public Employee(int Employeeid, string Name, string Department, string Designation, int basicSalary)
        {
            empid = Employeeid;
            name = Name;
            dept = Department;
            desg = Designation;
            basic_salary = basicSalary;

        }

    }
    //Implement the interface in classes like TCS,Accenture
    //base class should come before interface
    public class TCS : Employee,GovtRules
    {

        public TCS(int Employeeid, string Name, string Department, string Designation, int Salary)
            : base(Employeeid,  Name, Department, Designation, Salary)
        {

        }
        public double EmployeePF(double basicSalary)
        {

            
            double pfemployeeContrib = 0.12 * basicSalary;
            double pfemployerContrib = 0.0833 * basicSalary;

            
            double pensionemployerContrib = 0.0367 * basicSalary;

            
            return pfemployeeContrib + pfemployerContrib + pensionemployerContrib;
            
            

        }
        public string LeaVeDetails()
        {
            return "Casual Leave: 1 day per month\n" +
                "Sick Leave: 12 days per year\n" +
                "Privilege Leave: 10 days per year";

        }
        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {

            if (serviceCompleted > 5)

                return basicSalary;
            else if (serviceCompleted > 10)
                return 2 * basicSalary;
            else if (serviceCompleted > 20)
                return 3 * basicSalary;
            else
                return 0;
            
            
        }

        
    }

    class Accenture : Employee, GovtRules
    {

        public Accenture(int Employeeid, string Name, string Department, string Designation, int Salary)
           : base(Employeeid, Name, Department, Designation, Salary)
        {

        }

        public double EmployeePF(double basicSalary)
        {

            double pfemployeeContrib = 0.12 * basicSalary;
            double pfemployerContrib = 0.12 * basicSalary;

            return pfemployeeContrib + pfemployerContrib;


        }
        public string LeaVeDetails()
        {
            return "Casual Leave: 2 day per month\n" +
               "Sick Leave: 5 days per year\n" +
               "Privilege Leave: 5 days per year";
        }

        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

       
    }


    class Assignment_5
    {
        static void Main()
        {
            TCS tcsEmployee = new TCS(1, "Reshma", "IT", "DotNet", 20000);


            
            Console.WriteLine("TCS Employee Details:");
            Console.WriteLine($"Employee ID: {tcsEmployee.empid}");
            Console.WriteLine($"Name: {tcsEmployee.name}");
            Console.WriteLine($"Department: {tcsEmployee.dept}");
            Console.WriteLine($"Designation: {tcsEmployee.desg}");
            Console.WriteLine($"Basic Salary: {tcsEmployee.basic_salary}");

            Console.WriteLine($"Employee PF Contribution: {tcsEmployee.EmployeePF(tcsEmployee.basic_salary)}");
            Console.WriteLine($"Leave Details:\n{tcsEmployee.LeaVeDetails()}");
            Console.WriteLine($"Gratuity Amount: {tcsEmployee.gratuityAmount(7, tcsEmployee.basic_salary)}");

            Console.WriteLine();

            Accenture accentEmployee = new Accenture(2, "Anand", "Manager", "Senior Manager", 75000);

            Console.WriteLine("Accenture Employee Details:");
            Console.WriteLine($"Employee ID: {accentEmployee.empid}");
            Console.WriteLine($"Name: {accentEmployee.name}");
            Console.WriteLine($"Department: {accentEmployee.dept}");
            Console.WriteLine($"Designation: {accentEmployee.desg}");
            Console.WriteLine($"Basic Salary: {accentEmployee.basic_salary}");

            Console.WriteLine($"Employee PF Contribution: {accentEmployee.EmployeePF(accentEmployee.basic_salary)}");
            Console.WriteLine($"Leave Details:\n{accentEmployee.LeaVeDetails()}");
            Console.WriteLine($"Gratuity Amount: {accentEmployee.gratuityAmount(8, accentEmployee.basic_salary)}");
        }
    }
    
}