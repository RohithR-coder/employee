namespace PayslipApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicSalary { get; set; }
        public double HRA { get; set; }
        public double DA { get; set; }
        public double NetSalary { get; set; }

        public void CalculateNetSalary()
        {
            NetSalary = BasicSalary + HRA + DA;
        }
    }
}
