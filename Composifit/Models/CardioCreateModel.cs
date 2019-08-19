using System;

namespace Composifit.Models
{
    public class CardioCreateModel
    {
        public string Name { get; set; }      
        public DateTime? Date { get; set; }
        public int MesoId { get; set; }
        public int TimeInMinutes { get; internal set; }
        public string Intensity { get; internal set; }
    }
}