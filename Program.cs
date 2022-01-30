using System;

namespace Heist
{
  class Program
  {
    static void Main(string[] args)
    {
      //*  Print the message "Plan Your Heist!".
      Console.WriteLine("Plan Your Heist!");
      Console.WriteLine("----------------");

      TeamMember newMember = new TeamMember();

      //*  Display the team member's information.
      newMember.DisplayStats();

      //* Phase Two
      //* The program should be updated to...

      //TODO Create a way to store several team members.
      //TODO Collect several team members' information.
      //TODO Stop collecting team members when a blank name is entered.
      //TODO Display a message containing the number of members of the team.
      //TODO Display each team member's information.
    }
  }
}
