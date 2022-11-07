using Application.Interfaces;
using Domain;
using Moq;

namespace Testing;

public class StudentServiceTester
{
    [Fact]
    public void GetAllStudentsTest()
    {
        Student studentEntry = new Student
        {
            Id = 1, Address = "Address", Email = "email@.gmail.com", Name = "Bob", PostalDistrict = "district 7",
            ZipCode = 6700
        };
        var expectedData = new[]
        {
            studentEntry
        };
        
        //Arrange
        Mock<IStudentRepository> mockRepository = new Mock<IStudentRepository>();
        mockRepository.Setup(repo => repo.GetAllStudents()).Returns(expectedData.ToList);
        //Act

        var actualData = mockRepository.Object.GetAllStudents();
        //Assert
        Assert.Equal(expectedData.Length,actualData.Count);
    }
}