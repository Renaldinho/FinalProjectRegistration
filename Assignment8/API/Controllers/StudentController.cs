using Application.DTOs;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{

    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }


    [HttpPost]
    [Route("BuildDB")]
    public void RebuildDatabase()
    {
        _service.RebuildDatabase();
    }

    [HttpPost]
    [Route("PostStudent")]
    public ActionResult<Student> CreateNewStudent(PostStudentDTO dto)
    {
        try
        {
            var result = _service.CreateNewStudent(dto);
            return Created("Student/" + result.Id, result);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("GetStudents")]
    public ActionResult<List<Student>> GetAllStudents()
    {
        return _service.GetAllStudents();
    }

    [HttpPut]
    [Route("UpdateStudent/{id}")]
    public ActionResult<Student> UpdateStudent([FromRoute]int id,[FromBody]Student student)
    {
        try
        {
            Student updatedStudent = _service.UpdateStudent(id, student);
            return Ok(updatedStudent);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No product found at ID " + id);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Student> DeleteStudent(int id)
    {
        try
        {
            var removedStudent = _service.DeleteStudent(id);
            return Ok(removedStudent);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No student with ID: " + id + " found");
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }


}