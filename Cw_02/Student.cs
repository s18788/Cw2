using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Student
{
    private string firstName;
    private string email;
    private string name;
    private string index;
    private DateTime dateOfBirth;
    private string mothersFName;
    private string fathersFName;

    public Student(string firstName, string name, string index, DateTime dateOfBirth, string email, string mothersFName, string fathersFName)
    {
        this.firstName = firstName;
        this.name = name;
        this.index = index;
        this.dateOfBirth = dateOfBirth;
        this.email = email;
        this.mothersFName = mothersFName;
        this.fathersFName = fathersFName;



    }
}
