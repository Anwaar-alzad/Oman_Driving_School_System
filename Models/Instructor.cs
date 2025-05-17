using System.ComponentModel.DataAnnotations;

namespace Oman_Driving_School_System;

public class Instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PhoneNumber { get; set; }
    public Specialization specialization { get; set; }
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();

    public Instructor() { }

    public Instructor(string name, int phone, Specialization specialization)
    {
        this.Name = name;
        this.PhoneNumber = phone;
        this.specialization = specialization;
    }

}
