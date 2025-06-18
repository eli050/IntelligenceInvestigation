namespace IntelligenceInvestigation.InterFaces
{
    public interface IBreakabale
    {
        public int Count { get; set; }
        public bool IsBroken();
    }
}
