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
    }
  }
}
