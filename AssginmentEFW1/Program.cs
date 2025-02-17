namespace AssginmentEFW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EnterpriceDBContext DBContext = new EnterpriceDBContext();
            //DBContext.Students.Add();
            using (var context = new EnterpriceDBContext())
            {
                using (var transaction = context.Database.BeginTransaction()) 
                {
                    try
                    {
                        var dept = new Department { Name = "Computer Science", HiringDate = DateTime.Now };
                        context.Departments.Add(dept);
                        context.SaveChanges();

                        var instructor = new Instructor { Name = "Ali Mohamed", Salary = 50000, Dept_ID = dept.Dep_Id };
                        context.Instructors.Add(instructor);
                        context.SaveChanges();

                   
                        var student = new Student
                        {
                            FName = "Ali",
                            LName = "Mohamed",
                            Address = "306 Street",
                            Age = 22,
                            DepId = dept.Dep_Id 
                        };
                        context.Students.Add(student);
                        context.SaveChanges();

                      
                        var students = context.Students.ToList();
                        foreach (var stud in students)
                        {
                            Console.WriteLine($"{stud.FName} {stud.LName} - Department: {stud.Department?.Name}");
                        }

                 
                        student.Address = "306 Maadi";
                        context.Students.Update(student);
                        context.SaveChanges();

                    
                        context.Students.Remove(student);
                        context.SaveChanges();

                
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        transaction.Rollback(); 
                    }

                }
            }
        }
    }
}