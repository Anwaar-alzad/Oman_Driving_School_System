using System.ComponentModel.DataAnnotations;

namespace Oman_Driving_School_System;

public class Student
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    [Phone]
    public int PhoneNumber { get; set; }
    public LisenceType lisenceType { get; set; }
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    // parameterless required by EF
    public Student() { }
    public Student(string name, int phone, LisenceType lisenceType)
    {
        this.Name = name;
        this.PhoneNumber = phone;
        this.lisenceType = lisenceType;

    }

}
