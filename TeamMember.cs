using System;

namespace Heist
{
  //*  Create a way to store a single team member. 
  public class TeamMember
  {
    public TeamMember(string nameInput)
    {
      _name = nameInput;

      //*  Prompt the user to enter a team member's skill level and save that skill level with the name.
      InputSkill();

      //*  Prompt the user to enter a team member's courage factor and save that courage factor with the name.
      InputCourage();
    }
    //*  A team member will have a name, a skill Level and a courage factor. 
    private string _name { get; set; }
    //*  The skill Level will be a positive integer 
    private int _skillLevel { get; set; }
    //*  the courage factor will be a decimal between 0.0 and 2.0.
    private decimal _courage { get; set; }

    private void InputSkill()
    {
      string skillInput = "";
      int parsedSkill;
      while (!Int32.TryParse(skillInput, out parsedSkill) || parsedSkill <= 0 || parsedSkill > 100)
      {
        Console.WriteLine("Enter skill level for new team member. Must be a positive integer between 1 - 100.");
        skillInput = Console.ReadLine();
      }
      _skillLevel = parsedSkill;
    }
    private void InputCourage()
    {
      string courageInput = "";
      decimal parsedCourage;
      while (!Decimal.TryParse(courageInput, out parsedCourage) || parsedCourage < 0 || parsedCourage > 2)
      {
        Console.WriteLine("Enter courage for new team member. Must be between 0 - 2, can be decimal (0.0 - 2.0)");
        courageInput = Console.ReadLine();
      }
      _courage = Math.Round(parsedCourage, 1);
    }

    public int GetSkillLevel()
    {
      return _skillLevel;
    }

    public void DisplayStats()
    {
      Console.WriteLine($"\n============================\nName: {_name}\nSkill Level: {_skillLevel}\nCourage: {_courage.ToString("N1")}");
    }
  }
}