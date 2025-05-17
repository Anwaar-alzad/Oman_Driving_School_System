using System.ComponentModel.DataAnnotations;

namespace Oman_Driving_School_System;

public class Lesson
{

    public int ID { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public Status Status { get; set; }
    [StringLength(150)]
    public string? Note { get; set; }
    // foreign key takes the obejct of student and instractor
    public int StudentId { get; set; } // FK
    public Student Student { get; set; }
    public int InstructorId { get; set; } // FK
    public Instructor Instructor { get; set; }

    public Lesson() { }

    // for booking
    public Lesson(int stdId, DateOnly date, string note, Status status)
    {
        this.StudentId = stdId;
        this.Date = date;
        this.Note = note;
        this.Status = status;

    }
    public Lesson(DateOnly date, TimeOnly time, int stdId, int instructId)
    {
        this.Date = date;
        this.Time = time;
        this.StudentId = stdId;
        this.InstructorId = instructId;
    }

    // for giving feedback


}
