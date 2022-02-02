using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist
{
  public class Bank
  {
    public Bank()
    {
      //? This diffLevel will start the loop 
      int diffLevel = 0;
      while (diffLevel <= 0)
      {
        //? Try to get the input. It will only really throw if the string cannot be converted to integer.
        //? A negative number can be input but it will not cause an exception. 
        //? When there is an exception just skip current iteration and reprompt user. 
        try
        {
          Console.WriteLine("Enter a difficulty level for the bank, must be a positive integer");
          diffLevel = Int32.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
          continue;
        }
      }

      Difficulty = diffLevel;
    }
    //* Store a value for the bank's difficulty level. Set this value to 100.
    public int Difficulty { get; set; }
  }
  public class HeistReport
  {
    public int TeamSkillLevel { get; set; }
    public int BankDifficultyLevel { get; set; }
    public bool SuccessfulHeist { get; set; }
  }

  public class EndOfHeistsReport
  {
    public int SuccessfulHeistCount { get; set; }
    public int FailedHeistCount { get; set; }
  }
  class Program
  {

    static void Main(string[] args)
    {
      Bank bank = new Bank();
      
      int bankDifficulty = bank.Difficulty;
      //* Print the message "Plan Your Heist!".
      Console.WriteLine("Plan Your Heist!");
      Console.WriteLine("----------------");

      Team newTeam = new Team();
      
      List<TeamMember> teamList = newTeam.GetTeamMembers();

      int trialRuns = 0;

      while (trialRuns <= 0)
      {
        try
        {
          Console.WriteLine("Enter a number of trial runs for the team.");
          trialRuns = Int32.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
          Console.WriteLine("Enter a number of trial runs for the team. Must be a positive integer greater than 0..");
          trialRuns = Int32.Parse(Console.ReadLine());
        }
      }
      
      //* Before displaying the success or failure message, display a report that shows.
      //* The team's combined skill level
      //* The bank's difficulty level
      List<HeistReport> heistReports = new List<HeistReport>();
      for (int i = trialRuns; i > 0; i--)
      {
        HeistReport report = new HeistReport {
          TeamSkillLevel = teamList.Sum(tm => tm.GetSkillLevel()),
          //* Create a random number between -10 and 10 for the heist's luck value.
          //* Add this number to the bank's difficulty level.
          BankDifficultyLevel = bankDifficulty + new Random().Next(-10, 10)
        };
        heistReports.Add(report);
      }
      
      //* Compare the number with the bank's difficulty level.
      //* If the team's skill level is greater than or equal to the bank's difficulty level,
      //* Display a success message, otherwise display a failure message.
      heistReports.ForEach(hr => {
        if (hr.TeamSkillLevel >= hr.BankDifficultyLevel)
        {
          hr.SuccessfulHeist = true;
        } 
        else
        {
          hr.SuccessfulHeist = false;
        }
      });

      EndOfHeistsReport endOfHeistsReport = new EndOfHeistsReport(){
        SuccessfulHeistCount = heistReports.Select(hr => hr.SuccessfulHeist).Where(hrSuccess => hrSuccess == true).Count(),
        FailedHeistCount = heistReports.Select(hr => hr.SuccessfulHeist).Where(hrSuccess => hrSuccess == false).Count()
      };

      Console.WriteLine(@$"
      --End of Heists Report--
        {endOfHeistsReport.SuccessfulHeistCount} heists were successful!
        {endOfHeistsReport.FailedHeistCount} heists failed!
      ");
    }
  }
}
