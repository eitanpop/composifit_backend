using System;

namespace Composifit.Models
{
    public class CardioCreateModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int MesoId { get; set; }
        public int TimeInMinutes { get; set; }
        public string Intensity { get; set; }
    }
}