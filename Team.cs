using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist
{
  //* Create a way to store several team members.
  public class Team
  {
    public Team()
    {
      //* Collect several team members' information.
      while (true)
      {
        //*  Prompt the user to enter a team member's name and save that name.
        Console.WriteLine("Enter name for new team member");
        string newMemberNameInput = Console.ReadLine();
        
        //* Stop collecting team members when a blank name is entered.
        if (String.IsNullOrWhiteSpace(newMemberNameInput))
        {
          break;
        }
        TeamMember newTeamMemeber = new TeamMember(newMemberNameInput);
        AddMember(newTeamMemeber);
      }
           
    }
    
    private List<TeamMember> _teamList { get; set; } = new List<TeamMember>();
    private void AddMember(TeamMember memberBerry)
    {
      _teamList.Add(memberBerry);
    }

    //* Sum the skill levels of the team. Save that number.
    public int TeamSkillLevel()
    {
      return _teamList.Sum(tm => tm.GetSkillLevel());
    }

    public List<TeamMember> GetTeamMembers()
    {
      return _teamList;
    }
    public void ShowMembers()
    {
      //* Display a message containing the number of members of the team.
      Console.WriteLine($"Team Members: {_teamList.Count}");
      //* Display each team member's information.
      _teamList.ForEach(m => m.DisplayStats());
    }
  }
}