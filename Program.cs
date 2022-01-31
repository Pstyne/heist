using System;

namespace Heist
{
  class Program
  {
    static void Main(string[] args)
    {
      //* Store a value for the bank's difficulty level. Set this value to 100.
      int bankDifficulty = 100;
      //*  Print the message "Plan Your Heist!".
      Console.WriteLine("Plan Your Heist!");
      Console.WriteLine("----------------");

      Team newTeam = new Team();
      
      //* Sum the skill levels of the team. Save that number.
      int teamSkillLevel = newTeam.TeamSkillLevel();
      
      //* Compare the number with the bank's difficulty level.
      //* If the team's skill level is greater than or equal to the bank's difficulty level,
      //* Display a success message, otherwise display a failure message.
      if (teamSkillLevel >= bankDifficulty)
      {
        Console.WriteLine("Your Heist was Successful!");
      } 
      else
      {
        Console.WriteLine("Your Heist was NOT Successful!");
      }
    }
  }
}
