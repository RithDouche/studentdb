// Date         Name            Description
// 2/13/25      harmansb        Created new student file with two constructors. One do nothing no arg constructor and one with multiple arguments.
//                              Also created a string override to print out first, last, gpa, and email.
// 2/20/25      harmansb        Created a ToStringForOutputFile method


namespace StudentDb
{
    // Good example of POCO data object class
    internal class Student
    {
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public double GradePtAvg { get; set; }
        public string EmailAddress { get; set; }

        // fully specified constructor definition
        public Student(string first, string last, double gpa, string email)
        {
            FirstMidName = first;
            LastName = last;
            GradePtAvg = gpa;
            EmailAddress = email;
        }

        // do nothing - no-arg constructor
        public Student() 
        { 
        }

        // need easy way to output student object data when requested by user
        public override string ToString()
        {
            string str = "******** Student Record ********\n";
            str += $"First: {FirstMidName}\n";
            str += $" Last: {LastName}\n";
            str += $"  GPA: {GradePtAvg}\n";
            str += $"Email: {EmailAddress}\n";

            return str;

        }

        // need easy way to output student object data to the datafile file for persistence
        // storing the data between instances of the program execution
        public string ToStringForOutputFile()
        {
            string str = string.Empty;
            str += $"{FirstMidName}\n";
            str += $"{LastName}\n";
            str += $"{GradePtAvg}\n";
            str += $"{EmailAddress}\n";

            return str;

        }
    }
}