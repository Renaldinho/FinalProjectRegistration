using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class StudentRepository: IStudentRepository
{
    public void RebuildDatabase()
    {
        throw new NotImplementedException();
    }

    public Student CreateNewStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public bool DeleteStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Student> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public bool UpdateStudent(Student student)
    {
        throw new NotImplementedException();
    }
}