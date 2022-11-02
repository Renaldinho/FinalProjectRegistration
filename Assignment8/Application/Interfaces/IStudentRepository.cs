using Domain;

namespace Application.Interfaces;

public interface IStudentRepository
{
    public void RebuildDatabase();

    public Student CreateNewStudent(Student student);

    public bool DeleteStudent(Student student);

    public IEnumerable<Student> GetAllStudents();

    public bool UpdateStudent(Student student);
}