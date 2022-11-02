using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;

namespace Application;

public class StudentService: IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<PostStudentDTO> _studentDTOValidator;
    private readonly IValidator<Student> _studentValidator;

    public StudentService(IStudentRepository repository,IMapper mapper
                            ,IValidator<PostStudentDTO> studentDTOValidator,IValidator<Student> studentValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _studentDTOValidator = studentDTOValidator;
        _studentValidator = studentValidator;
    }

    public void RebuildDatabase()
    {
        _repository.RebuildDatabase();
    }

    public Student CreateNewStudent(PostStudentDTO dto)
    {
        var validation = _studentDTOValidator.Validate(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());
        
        Student mappedStudent = _mapper.Map<Student>(dto);
        return _repository.CreateNewStudent(mappedStudent);
    }

    public List<Student> GetAllStudents()
    {
        return _repository.GetAllStudents();
    }

    public Student UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
            throw new ValidationException("ID in route and body don't match");
        var validation = _studentValidator.Validate(student);
        
        if (!validation.IsValid)
            throw new ValidationException(validation.ToString());

        return _repository.UpdateStudent(student);

    }

    public Student DeleteStudent(int id)
    {
        return _repository.DeleteStudent(id);
    }
}