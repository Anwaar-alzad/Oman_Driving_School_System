using System;
using Microsoft.EntityFrameworkCore;

namespace Oman_Driving_School_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationDBContext();

            int choice;
            do
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("Nizwa Driving School System");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Register New Student");
                Console.WriteLine("2. Register New Instructor");
                Console.WriteLine("3. Book Driving Lesson");
                Console.WriteLine("4. Record Lesson Completion & Instructor Feedback");
                Console.WriteLine("5. View Student Lesson History");
                Console.WriteLine("6. View All Scheduled Lessons");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                bool isValid = int.TryParse(Console.ReadLine(), out choice);
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("=======================================");
                        Console.WriteLine("         Registering new student       ");
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Enter student Name:");
                        string studentName = Console.ReadLine();
                        // Name validation
                        if (string.IsNullOrWhiteSpace(studentName))
                        {
                            Console.WriteLine("Error: Name can't be empty");
                        }
                        Console.WriteLine("Enter student Phone number:");
                        // Name validation
                        if (!int.TryParse(Console.ReadLine(), out int stuPhone))
                        {
                            Console.WriteLine("Error: Invalid phone number");
                            return;
                        }
                        Console.WriteLine("Student Lisence Type:");
                        foreach (var lisenceType in Enum.GetValues(typeof(LisenceType)))
                        {
                            Console.WriteLine($"{(int)lisenceType} - {lisenceType}");
                        }
                        Console.WriteLine("Choose number for student Lisence Type:");
                        int studentLisence = int.Parse(Console.ReadLine());
                        LisenceType lisenceType1 = (LisenceType)studentLisence;

                        // create object to store inputs entered by user
                        Student student = new Student(studentName, stuPhone, lisenceType1);
                        context.Students.Add(student);
                        context.SaveChanges();
                        Console.WriteLine("✅ Student registered with ID: ST001");
                        break;
                    case 2:
                        Console.WriteLine("=======================================");
                        Console.WriteLine("         Registering new Instructor    ");
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Enter instructor Name:");
                        string instructorName = Console.ReadLine();
                        Console.WriteLine("Enter instructor Phone number:");
                        int instractorPhone = int.Parse(Console.ReadLine());
                        Console.WriteLine(" Specialization :");
                        foreach (var specialization_ in Enum.GetValues(typeof(Specialization)))
                        {
                            Console.WriteLine($"{(int)specialization_} - {specialization_}");
                        }
                        Console.WriteLine("Choose number for student Lisence Type:");
                        int spec = int.Parse(Console.ReadLine());
                        Specialization spec1 = (Specialization)spec;

                        // create object to store inputs entered by user
                        Instructor instructor = new Instructor(instructorName, instractorPhone, spec1);
                        context.Instructors.Add(instructor);
                        context.SaveChanges();
                        Console.WriteLine($"✅ Instructor registered with ID: {instructor.Id}");
                        break;
                    case 3:
                        Console.WriteLine("=======================================");
                        Console.WriteLine("           Book Driving lesson         ");
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Enter Student ID:");
                        int stdId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Instructor ID:");
                        int InstId_ = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Lesson Date (dd/mm/yyyy):");
                        string date = Console.ReadLine();
                        if (DateOnly.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly date_))
                        {
                            Console.WriteLine($"You entered: {date_}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        Console.Write("Enter Time (HH:mm): ");
                        TimeOnly lessonTime;
                        Console.Write("Enter Time (HH:mm): ");
                        while (!TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm", null, System.Globalization.DateTimeStyles.None, out lessonTime))
                        {
                            Console.Write("Invalid time. Please enter again (HH:mm): ");
                        }
                        Console.WriteLine($"Time entered: {lessonTime}");
                        Lesson lesson = new Lesson(date_, lessonTime, stdId, InstId_);

                        context.Lessons.Add(lesson);
                        context.SaveChanges();
                        Console.WriteLine("✅ Lesson scheduled successfully.");
                        break;
                    case 4:
                        Console.WriteLine("=======================================");
                        Console.WriteLine("     Recording lesson completion and feedback   ");
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Enter Student ID:");
                        int studId = int.Parse(Console.ReadLine());
                        var instructorExists = context.Students.Any(s => s.Id == studId);
                        if (!instructorExists)
                        {
                            Console.WriteLine($"Instructor with ID {studId} does not exist.");
                            return;
                        }

                        Console.WriteLine("Enter Lesson Date (dd/mm/yyyy):");
                        string lessonDate = Console.ReadLine();
                        if (DateOnly.TryParseExact(lessonDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly lessondate_))
                        {
                            Console.WriteLine($"You entered: {lessondate_}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format.");
                        }
                        Console.WriteLine("Enter note:");
                        string note = Console.ReadLine();
                        Console.WriteLine("Enter Status:");
                        Console.WriteLine("Status (Completed / Scheduled):");
                        foreach (var status_ in Enum.GetValues(typeof(Status)))
                        {
                            Console.WriteLine($"{(int)status_} - {status_}");
                        }
                        Console.WriteLine("Choose number for status:");
                        int status = int.Parse(Console.ReadLine());
                        Status status1 = (Status)status;

                        // int stdId, DateOnly date, string note, Status status
                        Lesson lessonWithNotes = new Lesson(studId, lessondate_, note, status1);
                        context.Lessons.Add(lessonWithNotes);
                        context.SaveChanges();
                        Console.WriteLine("✅ Lesson marked as completed and feedback saved.");
                        break;

                    case 5:
                        Console.WriteLine("=======================================");
                        Console.WriteLine("      View Student Lesson History      ");
                        Console.WriteLine("=======================================");
                        Console.Write("Enter Student ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int result))
                        {
                            Console.WriteLine("Invalid input. Please enter a numeric Student ID.");
                            break;
                        }

                        var student_ = context.Students.FirstOrDefault(s => s.Id == result);
                        if (student_ == null)
                        {
                            Console.WriteLine("Student not found.");
                            break;
                        }

                        var studentLessons = context.Lessons
                        .Where(l => l.StudentId == result)
                        .Include(l => l.Instructor)
                        .OrderBy(l => l.Date)
                        .ThenBy(l => l.Time)
                        .ToList();

                        if (!studentLessons.Any())
                        {
                            Console.WriteLine("No lessons found for this student.");
                            break;
                        }
                        // Display lessons
                        Console.WriteLine($"📘 Lesson History for {student_.Name}:");
                        foreach (var lesson_ in studentLessons)
                        {
                            Console.WriteLine($"Date: {lesson_.Date:dd/MM/yyyy} | Time: {lesson_.Time:HH:mm} | Instructor: {lesson_.Instructor.Name}");
                            if (!string.IsNullOrWhiteSpace(lesson_.Note))
                                Console.WriteLine($"Feedback: {lesson_.Note}");
                        }
                        break;
                    case 6:
                        Console.WriteLine("=======================================");
                        Console.WriteLine("     Viewing all scheduled lessons     ");
                        Console.WriteLine("=======================================");
                        var scheduledLessons = context.Lessons
                        .Include(l => l.Student)
                        .Include(l => l.Instructor)
                        .OrderBy(l => l.Date)
                        .ThenBy(l => l.Time)
                        .ToList();

                        if (!scheduledLessons.Any())
                        {
                            Console.WriteLine("No scheduled lessons found.");
                            break;
                        }

                        int count = 1;
                        foreach (var lesson_ in scheduledLessons)
                        {
                            int studentId = lesson_.Student.Id;
                            int instructorId = lesson_.Instructor.Id;
                            Console.WriteLine($" ST{studentId} | {lesson_.Student.Name} | IN{instructorId} | {lesson_.Instructor.Name} | {lesson_.Date:dd/MM/yyyy} at {lesson_.Time:HH:mm}");
                        }
                        break;
                    case 7:
                        Console.WriteLine("Exiting system. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number between 1 and 7.");
                        break;
                }

                Console.WriteLine(); // Add a blank line for spacing

            } while (choice != 7);
        }
    }
}
