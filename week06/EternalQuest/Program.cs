using EternalQuest;

/* CREATIVITY AND EXCEEDING REQUIREMENTS:
1. DEFENSIVE PROGRAMMING: Implemented comprehensive input validation for all numeric fields 
   and filename strings to prevent ArgumentExceptions and format crashes.
2. PERSISTENT ACTION LOG: Created a timestamped history trail of the last 10 user actions. 
   This log remains on the terminal even after the program exits, ensuring total traceability.
3. RPG LEVELING SYSTEM: Integrated a dynamic rank calculation based on the score, which is 
   displayed in a persistent header alongside the action history.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}