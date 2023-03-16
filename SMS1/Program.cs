using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public class student
    {
        public int sid;
        public string name;
        public string city;
        public int age;


        public student(int sid, string name, string city, int age)
        {
            this.sid = sid;
            this.name = name;
            this.city = city;
            this.age = age;
        }
    }
    public class program
    {
        public static List<student> students = new List<student>();
        static int sid;
        static string name;
        static string city;
        static int age;

        public static void Main(string[] args)
        {
            string ch = "";
            Console.WriteLine("\n\tStudent-Management-System");
            Console.WriteLine("\t-----------  ------------");
            Console.WriteLine("\n1.Create new student \n2.View \n3.Update \n4.Delete ");

            do
            {
                Console.Write("\nSelect your choice : ");
                int choice;
                bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out choice);

                if (!IsConversionSuccessful)
                    Console.Write("\nPlease enter a valid format");
                else
                {
                    switch (choice)
                    {
                        case 1:
                            enterDetails();
                            bool exists = students.Exists(x => x.sid == sid);
                            if (exists)
                                Console.Write("\n\n *Sno already exists");
                            else
                                students.Add(new student(sid, name,city,age));
                            foreach (student student in students)
                            {
                                // Console.WriteLine($"{counter++}.\tSno : {student.sid}\n\tName : {student.name}\n");
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                Console.WriteLine("|  Student id |  Name                           |  City                            |  Age      |");
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                Console.WriteLine("|  {0, -10} |  {1,-10}                      |  {2,-10}                      |  {3, -8} |", student.sid, student.name, student.city, student.age);
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                            }
                            break;

                        case 2:
                            view();
                            break;

                        case 3:
                            Update();
                            break;

                        case 4:
                            deletedetails();
                            break;

                        default:
                            Console.Write("\nInvalid Choice, Please enter a valid choice");
                            break;
                    }
                    do
                    {
                        Console.WriteLine("\n\tTo continue the Student-Management-System Application");
                        Console.Write("\n\t-----------------------  ----------------------------");
                        Console.Write("\n1.Create new student \n2.View \n3.Update \n4.Delete ");
                        Console.Write("\n\nDo you want to continue to the Application, Say (yes or no)");
                        ch = Console.ReadLine().Trim().ToLower();


                        if (ch != "y" && ch != "n")
                            Console.Write("\n\nInvalid Choice, Please say (yes or no)");

                    } while (ch != "y" && ch != "n");
                }
            } while (ch == "y");

            Console.WriteLine("\n\n  *** Program Terminated *** ");
        }
        public static void enterDetails()
        {
            Console.WriteLine("\nPlease provide the details below");
            //Console.WriteLine("+++++++++++++++++++++++++++++++");
            enterSno();
            enterName();
            enterCity();
            enterAge();
        }

        public static void enterSno()
        {
            //Console.Write("\n+++++++++++++++++++++++++++++++");
            Console.Write("\nEnter Sno : ");
            
            bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out sid);

            if (!IsConversionSuccessful)
                Console.Write("\nPlease enter a valid format");
            //Console.WriteLine("\n+++++++++++++++++++++++++++++++");
        }

        public static void enterName()
        {
           
            Console.Write("Enter name : ");
            name = Console.ReadLine().ToLower();
            //Console.WriteLine("\n+++++++++++++++++++++++++++++++");
        }

        public static void enterCity()
        {

            Console.Write("Enter City : ");
            city = Console.ReadLine().ToLower();
            //Console.WriteLine("\n+++++++++++++++++++++++++++++++");
        }

        public static void enterAge()
        {
            //Console.Write("\n+++++++++++++++++++++++++++++++");
            Console.Write("Enter Age : ");

            bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out age);

            if (!IsConversionSuccessful)
                Console.Write("\nPlease enter a valid format");
            //Console.WriteLine("\n+++++++++++++++++++++++++++++++");
        }

        public static void view()
        {
            Console.WriteLine("\n\nStudents Details");
            Console.WriteLine("++++++++++++++++++");
            Console.WriteLine("Select (1) to GetAll view and (2) to GetBy Id view : ");
            int choice;
            bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out choice);

            if (!IsConversionSuccessful)
                Console.Write("\nPlease enter a valid format");
            else
            {
                switch (choice)
                {
                    case 1:
                        viewAll();
                        break;

                    case 2:
                        enterSno();
                        viewStudent(sid);
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice"); break;
                }

            }
        }

        public static void viewAll()
        {
            Console.WriteLine("\n\nStudents Details");
            Console.WriteLine("++++++++++++++++++");

            if (students.Count == 0)
                Console.Write("\n0 records");
            else
            {
                int counter = 1;
                foreach (student student in students)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.WriteLine("|  Student id |  Name                           |  City                            |  Age      |");
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                    Console.WriteLine("|  {0, -10} |  {1,-10}                      |  {2,-10}                      |  {3, -8} |", student.sid, student.name, student.city, student.age);
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                }
            }
        }

            public static student viewStudent(int sid)
        {
            student student = students.Find(x => x.sid == sid);

            if (student == null)
            {
                Console.WriteLine("\n\n\t *No matchng records found...");
                return null;
            }
            else
            {
                Console.WriteLine("\n\nStudent Details");
                Console.WriteLine("++++++++++++++++++");
                Console.WriteLine($"Sno : {student.sid}\nName : {student.name}\nCity : {student.city}\nAge : {student.age}");
                return student;
            }
        }

        public static void Update()
        {
            Console.WriteLine("\n\nStudents Details");
            Console.WriteLine("++++++++++++++++++");
            Console.WriteLine("Select (1) to UpdateAll and (2) to Update By Id : ");
            int choice;
            bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out choice);

            if (!IsConversionSuccessful)
                Console.Write("\nPlease enter a valid format");
            else
            {
                switch (choice)
                {
                    case 1:
                        updateAlldetails();
                        break;

                    case 2:
                        updatedetails();
                        break;

                    default:
                        Console.WriteLine("\nInvalid Choice"); break;
                }

            }
        }

        public static void updatedetails()
        {
            enterDetails();
            student student = students.Find(x => x.sid == sid && x.name == name && x.city == city && x.age == age);

            if(student == null)
            {
                Console.WriteLine("\n\n No matching results found");
            }
            else
            {
                Console.WriteLine("Student Details");
                Console.WriteLine("++++++++++++++++++");
                Console.WriteLine($"Sno : {student.sid}\n Name : {student.name}\nCity : {student.city}\nAge : {student.age}");

                Console.WriteLine("\n1. Update Sid \n2. Update Name \n3. Update City \n4. Update Age");
                string ch = ""; 
                
                do {
                    Console.WriteLine("\n\nSelect the property which you want to update : ");
                    int choice;
                    bool IsConversionSuccessful = int.TryParse(Console.ReadLine(),out choice);

                    if (!IsConversionSuccessful)
                        Console.Write("\nPlease enter a valid format");
                    else
                    {
                        switch (choice)
                        {
                            case 1:
                                enterSno();
                                if (sid != 0)
                                {
                                    bool exists = students.Exists(x => x.sid == sid);
                                    if (exists)
                                        Console.Write("\n\n *Sno already exists");
                                    else
                                        student.sid = sid;
                                }
                                break;

                            case 2:
                                enterName();
                                student.name = name;
                                break;

                            case 3:
                                enterCity();
                                student.city = city;
                                break;

                                case 4:
                                    enterAge();
                                if (age != 0)
                                {
                                    bool exists = students.Exists(x => x.age == age);
                                    if (exists)
                                        Console.Write("\n\n *Sno already exists");
                                    else
                                        student.age = age;
                                }
                                break;

                            default:
                                Console.WriteLine("\nInvalid Choice"); break;
                        }
                        do
                        {
                            Console.WriteLine("\n\nDo you want to continue to update more.., Say (yes or no)");
                            ch = Console.ReadLine().Trim().ToLower();

                            if (ch != "y" && ch != "n")
                                Console.Write("\n\nInvalid Choice, Please say (yes or no)");

                        } while (ch != "y" && ch != "n");
                    }
                } while (ch == "y");
            }
        }

        public static void deletedetails()
        {
            enterSno();
            student student = students.Find(x => x.sid == sid);

            bool res = students.Remove(student);

            if (res)
                Console.WriteLine($"\n *{student.sid}* Student detail removed successfully");
            else
                Console.WriteLine("\n\n No records matched");

        }

        public static void updateAlldetails()
        {
            enterDetails();
            student student = students.Find(x => x.sid == sid && x.name == name && x.city == city && x.age == age);

            if (student == null)
            {
                Console.WriteLine("\n\n No matching results found");
            }
            else
            {
                Console.WriteLine("Student Details");
                Console.WriteLine("++++++++++++++++++");
                Console.WriteLine($"Sno : {student.sid}\n Name : {student.name} \nCity : {student.city} \nAge : {student.age}");

                Console.WriteLine("\n1. UpdateAll ");
                string ch = "";

                do
                {
                    Console.WriteLine("\n\nUpdate all : ");
                    int choice;
                    bool IsConversionSuccessful = int.TryParse(Console.ReadLine(), out choice);

                    if (!IsConversionSuccessful)
                        Console.Write("\nPlease enter a valid format");
                    else
                    {

                        switch (choice)
                        {
                            case 1:
                                enterSno();
                                if (sid != 0)
                                {
                                    bool exists = students.Exists(x => x.sid == sid);
                                    if (exists)
                                        Console.Write("\n\n *Sno already exists");
                                    else
                                        student.sid = sid;
                                }
                              
                                enterName();
                                student.name = name;
                               

                                enterCity();
                                student.city = city;
                                
                                enterAge();
                                if (age != 0)
                                {
                                    bool exists = students.Exists(x => x.age == age);
                                    if (exists)
                                        Console.Write("\n\n *Sno already exists");
                                    else
                                        student.age = age;
                                }
                                break;

                            default:
                                Console.WriteLine("\nInvalid Choice"); 
                                break;
                        }
                        do
                        {

                            Console.WriteLine("\n\nDo you want to continue to update more.., Say (yes or no)");
                            ch = Console.ReadLine().Trim().ToLower();

                            if (ch != "y" && ch != "n")
                                Console.Write("\n\nInvalid Choice, Please say (yes or no)");

                        } while (ch != "y" && ch != "n");
                    }
                } while (ch == "y");
            }
        }
    }

}





