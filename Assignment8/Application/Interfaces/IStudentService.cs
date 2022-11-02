using Application.DTOs;

namespace Domain.Interfaces;

public interface IStudentService
{
    void RebuildDatabase();
    Student CreateNewStudent(PostStudentDTO dto);
    List<Student> GetAllStudents();
    Student UpdateStudent(int id, Student student);

    Student DeleteStudent(int id);
}