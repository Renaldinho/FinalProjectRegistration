using Application.Interfaces;
using Domain;

namespace Application;

public class TeamService : ITeamService
{
    public void CreateTeam(Team team)
    {
        throw new NotImplementedException();
    }

    public void RemoveTeam(Team team)
    {
        throw new NotImplementedException();
    }

    public void AddStudentToTeam(Team t, Student s)
    {
        throw new NotImplementedException();
    }

    public void MoveStudentToNewTeam(Team oldTeam, Team newTeam, Student s)
    {
        throw new NotImplementedException();
    }

    public void RemoveStudentFromTeam(Team team, Student student)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Team> GetAllTeams()
    {
        throw new NotImplementedException();
    }

    public Team GetTeamById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Student> GetNonAssignedStudents()
    {
        throw new NotImplementedException();
    }
}