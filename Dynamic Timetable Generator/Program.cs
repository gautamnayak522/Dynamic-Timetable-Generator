using System;
using System.Collections.Generic;

namespace Dynamic_Timetable_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int workingDays;
            bool validWorkingDays = false;

            int subjectsPerDay;
            bool validSubjectsPerDay = false;

            int totalSubjects;
            bool validTotalSubjects = false;

            int totalHoursofWeek;


            do
            {
                Console.Write("Enter the number of Working Days: ");
                string workingdayInput = Console.ReadLine();

                if (int.TryParse(workingdayInput, out workingDays) && workingDays >= 1 && workingDays <= 7)
                {
                    validWorkingDays = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. working day should be between 1 and 7.");
                }
            }
            while (!validWorkingDays);

            do
            {
                Console.Write("Enter the number of subjects per day: ");
                string subjectPerDayInput = Console.ReadLine();

                if (int.TryParse(subjectPerDayInput, out subjectsPerDay) && subjectsPerDay >= 1 && subjectsPerDay <= 8)
                {
                    validSubjectsPerDay = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. subject per day should be between 1 and 8.");
                }
            } while (!validSubjectsPerDay);

            do
            {
                Console.Write("Enter the number of Total Subjects: ");
                string totalsubjectsInput = Console.ReadLine();
                if (int.TryParse(totalsubjectsInput, out totalSubjects) && totalSubjects > 0)
                {
                    validTotalSubjects = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Total subject should greater than 0.");
                }
            }
            while (!validTotalSubjects);

            //Calculating total Hours of Week

            totalHoursofWeek = workingDays * subjectsPerDay;

            Console.WriteLine("The Total Hours for Week is = {0}", totalHoursofWeek);
            Console.WriteLine("==> Please Enter Details of All {0} Subject", totalSubjects);
            Console.WriteLine("Note : The total hours of subjects must be equal to Total hours hours for week : {0}hr", totalHoursofWeek);


            List<Subject> subjectslist = new List<Subject>();

            bool Check = false;
            int totalHoursOfSubjects = 0;


            while (!Check)
            {
                for (int i = 0; i < totalSubjects; i++)
                {
                    Subject subject = new Subject();
                    Console.Write("Enter Name of Subject {0}: ", i + 1);
                    subject.subject = Console.ReadLine();

                    int hours;
                    bool isValidHr = false;

                    do
                    {
                        Console.Write("Enter Hours for {0}: ", subject.subject);
                        string hourInput = Console.ReadLine();

                        if (int.TryParse(hourInput, out hours))
                        {
                            isValidHr = true;
                        }

                        if (hours <= 0)
                        {
                            Console.WriteLine("Invalid input OR Each Subject should have atleat 1 hr");
                        }
                    } while (!(isValidHr && hours > 0));


                    subject.hrsPerSubject = hours;

                    totalHoursOfSubjects += subject.hrsPerSubject;
                    subjectslist.Add(subject);

                    if (totalHoursOfSubjects > totalHoursofWeek)
                        break;
                }

                if (totalHoursOfSubjects == totalHoursofWeek)
                {
                    Check = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Inputs, Please try again");
                    Console.WriteLine("Note : The total hours of subject must be equal to Total hours for week which is : {0}", totalHoursofWeek);
                    subjectslist.Clear();
                    totalHoursOfSubjects = 0;
                    Console.ResetColor();
                }
            }



            //Printing a table from subjectlist

            var random = new Random();

            for (int i = 0; i < subjectsPerDay; i++)
            {
                for (int j = 0; j < workingDays; j++)
                {
                    if (totalSubjects > 0)
                    {
                        var randomnumber = random.Next(totalSubjects);

                        Console.Write("{0,-15}", subjectslist[randomnumber].subject);
                        subjectslist[randomnumber].hrsPerSubject--;

                        if (subjectslist[randomnumber].hrsPerSubject == 0)
                        {
                            subjectslist.RemoveAt(randomnumber);
                            totalSubjects--;
                        }
                    }
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }
    }
}
