using Domain;

namespace Application.Interfaces;

public interface ITeamService
{
    public void CreateTeam(Team team);
    public void RemoveTeam(Team team);
    public void AddStudentToTeam(Team t, Student s);
    public void MoveStudentToNewTeam(Team oldTeam, Team newTeam, Student s);
    public void RemoveStudentFromTeam(Team team, Student student);
    public IEnumerable<Team> GetAllTeams();
    public Team GetTeamById(int id);
    public IEnumerable<Student> GetNonAssignedStudents();
}