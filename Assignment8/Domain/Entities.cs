namespace Domain;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int ZipCode { get; set; }
    public string PostalDistrict { get; set; }
    
    public string Email { get; set; }
}

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Student> StudentList { get; set; }

}

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Hash{ get; set; }
    public string Salt { get; set; }
    public string Role { get; set; }
}

