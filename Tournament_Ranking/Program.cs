public class Team : IComparable<Team>
{
    public string Name {get; set;}
    public int Points {get; set;}

    public int CompareTo(Team other)
    {
        
    }
}

public class Tournament
{
    private SortedList<int,Team> _ranking = new ortedList<int,Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<Match> _undoStack = new Stack<Match>();

    public void ScheduleMatch(Match match)
    {
        _schedule.AddAfter(match);
    }

    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {
        
    }
}