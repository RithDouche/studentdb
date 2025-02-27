// Date         Name            Description
// 2/13/25      Sotharith        Created DbApp object, ReadStudentDataFromInputFile, RunDatabaseApp, and WriteDataToOutputFile methods.
//                              Also created streamwriter OutputFile
// 2/25/25      Sotharith        


using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.IO;

namespace StudentDb
{
    internal class DbApp
    {
        // will handle operations on a db
        // 1 - Add a record
        // 2 - Update or Modify/Edit a record
        // 3 - Find, Search, or Read records in the database
        // 4 - Delete or remove records from the database

        // storage for student records during program runtime
        private List<Student> students = new List<Student>();
    

        public DbApp()
        {
            // Things that may be handled in constructor 

            // INPUT - Read in data from permanent storage (in this case from a file)
            ReadStudentDataFromInputFile();

            // Fill list with sample student data
            //switching over to reading the input file - no longer need the test driver student 
            //DbAppTestDriver();

            // PROCESSING - run main app "loop" engine
            RunDatabaseApp();

        }

        private void ReadStudentDataFromInputFile()
        {
            // create a resource in the code to point to the file on disk
            StreamReader inFile = new  StreamReader(StudentInputFile);

            string firstName = string.Empty;
            // use stream object to read in from the other file
            while((firstName = inFile.ReadLine()) != null) 
            {
                //read in the rest of a student data object
                String lastName = inFile.ReadLine();
                double gpa = Convert.ToDouble(inFile.ReadLine());
                //double gpa = 4.0;
                string emailAddress = inFile.ReadLine();

                //make a new student object and add it to the  
                students.Add(new Student(firstName, lastName, gpa, emailAddress));
            }
            //close the file
            inFile.Close();
        }
        private void RunDatabaseApp()
        {
            while (true)
            {
                // show user what they can choose
                DisplayMainMenu();
                // choose the selection
                char selection = GetUserSelection();

                switch (char.ToUpper(selection))
                {
                    case 'A':
                        AddStudentRecord();
                        break;
                    case 'F':
                        string email = string.Empty;
                        //FindRecord();
                        Student stu = FindStudentRecord(out email);
                        break;
                    case 'M':
                        //ModifyRecord();
                        ModifyStudentRecord();
                        break;
                    case 'D':
                        //DeleteRecord();
                        DeleteStudentRecord();
                        break;
                    case 'P':
                        //PrintRecords();
                        PrintAllStudentRecords();
                        break;
                    case 'S':
                        //SaveData();
                        SaveStudentDataToOutputFile();
                        break;
                    case 'K':
                        //PrintAll();
                        PrintAllStudentRecordKeys();
                        break;
                    case 'E':
                        //Exit
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Write($" ERROR: {selection} is not a valid INPUT, SELECT AGAIN!");
                        // display menu again
                        break;
                }
            }
        }

        private void AddStudentRecord()
        {
        }

        private Student FindStudentRecord(out string email)
        {
            Console.WriteLine("\n Enter the email (primary key) being searched for: ");
            email = Console.ReadLine();

            foreach (Student stu in students)
            {
                if(email == stu.EmailAddress)
                {
                    Console.WriteLine($"FOUND email address: {stu.EmailAddress}\n");
                    return stu;
                }
            }

            Console.WriteLine($" {email} NOT FOUND.");
            return null;
        }

        private void ModifyStudentRecord()
        {
        }

        private void DeleteStudentRecord()
        {
        }

        private void PrintAllStudentRecords()
        {
            Console.WriteLine("\n******** List all Student Records ********");

            foreach (Student stu in students)
            {
                Console.WriteLine(stu);
            }
            Console.WriteLine("****** DOne listing all students ******");
        }

        private void PrintAllStudentRecordKeys()
        {
            Console.WriteLine("\n******** List all Student Emails in use ********");

            foreach (Student stu in students)
            {
                Console.WriteLine(stu.EmailAddress);
            }
            Console.WriteLine("****** Done listing all student emails ******");
        }

        private char GetUserSelection()
        {
            // Returns key that was pressed WITHOUT having to press enter
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar;
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(@"
*************************************************
********** Student Database App *****************
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
[A]dd a studnet record     (C in CURD - Create)
[F]ind a student record    (R in CRUD - Read)
[M]odify student record    (U in CRUD - Update)
[D]elete a student record  (D in CRUD - Delete)
[P]rint all records in current db storage
Print all primary [K]eys (email addresses)
[S]ave data to file and continue
[E]xit without saving changes

User Key Selection: ");

        }

        // use 2 seperate files. 1 for input, 1 for output
        // until we code the program to read, process, and write using one file
        private const string StudentOutputFile = "STUDENT_INPUT_FILE.txt";
        private const string StudentInputFile = "STUDENT_OUTPUT_FILE.txt";

        private void SaveStudentDataToOutputFile()
        {
            // create an object that attaches to the file on disk
            StreamWriter outFile = new StreamWriter(StudentOutputFile);

            Console.WriteLine("Output student data to the permanent output file.");

            // use the ref to the file above to write to the file
            foreach (Student student in students)
            {
                // for now - monitoring what is going to the output file.
                // Will comment out when database gets big
                Console.WriteLine(student);
                outFile.WriteLine(student);
            }

            // close the resource
            outFile.Close();
        }

        // Temp Test
        public void DbAppTestDriver()
        {
            // have a student db - need something to represent a student in system
            Student stu1 = new Student();
            Student stu2 = new Student();
            Student stu3 = new Student();

            // does not scale - need a constructor
            stu1.FirstMidName = "Alice Amy";
            stu1.LastName = "Anderson";
            stu1.GradePtAvg = 4.0;
            stu1.EmailAddress = "aanderson@uw.edu";

            // need to make students like this
            Student stu4 = new Student("David Deacon", "Davis", 3.7, "ddavis@uw.edu");
            stu2 = new Student("Bob Billy", "Bradshaw", 3.8, "bbradshaw@uw.edu");
            stu3 = new Student("Carlos Charlie", "Castaneda", 3.6, "ccastaneda@uw.edu");

            // put all students so far into the list
            students.Add(stu1);
            students.Add(stu2);
            students.Add(stu3);
            students.Add(stu4);


            // output - output  can be done individually
            //Console.WriteLine(stu1);
            //Console.WriteLine(stu2);
            //Console.WriteLine(stu3);
            //Console.WriteLine(stu4);

            //WriteDataToOutputFile();
        }
    }
}