using System;
namespace IntelligenceInvestigation.InterFaces
{
    public interface IInformerT
    {
        public bool FindOut { get; set; }
        public int AmountInformation { get; protected set; }
    }
}
