using System;


namespace ClassTasks;

public class CustomGetHashUser
{
    public CustomGetHashUser(string fName,string lName,int age)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
        
    }
    public string FirstName { get;  } = null!;
    public string LastName { get; } = null!;
    public int Age { get; set; }

    public override int GetHashCode()
    {
        return this.FirstName.Length*this.LastName.Length*this.Age;
    }

    public override bool Equals(object? obj )
    {
        return (obj as CustomGetHashUser).FirstName ==this.FirstName 
            && (obj as CustomGetHashUser).LastName == this.LastName
            && (obj as CustomGetHashUser).Age ==this.Age;
    }
}
