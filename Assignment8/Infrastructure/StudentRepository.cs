using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class StudentRepository: IStudentRepository
{

    private DatabaseContext _context;

    public StudentRepository(DatabaseContext context)
    {
        _context = context;
    }

    public void RebuildDatabase()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }

    public Student CreateNewStudent(Student student)
    {
        var createdStudent = _context.Students.Add(student).Entity;
        _context.SaveChanges();
        return createdStudent;
    }

    public Student DeleteStudent(int id)
    {
        var studentToDelete = _context.Students.Find(id) ?? throw new KeyNotFoundException();
        _context.Students.Remove(studentToDelete);
        _context.SaveChanges();
        return studentToDelete;
    }

    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    public Student UpdateStudent(Student student)
    {
        var updatedStudent = _context.Students.Update(student).Entity;
        _context.SaveChanges();
        return updatedStudent;
    }
}