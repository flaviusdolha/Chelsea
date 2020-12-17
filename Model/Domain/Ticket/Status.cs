namespace Chelsea.Model.Domain.Ticket
{
    public enum Status : short
    {
        NotAssigned = 0,
        InProgress = 1,
        Finished = 2,
        Postponed = -1,
        Abandoned = -2
    }
}