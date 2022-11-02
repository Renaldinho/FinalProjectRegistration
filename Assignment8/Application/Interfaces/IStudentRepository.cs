using Domain;

namespace Application.Interfaces;

public interface IStudentRepository
{
    public void RebuildDatabase();

    public Student CreateNewStudent(Student student);

    public Student DeleteStudent(int id);

    public List<Student> GetAllStudents();

    public Student UpdateStudent(Student student);
}