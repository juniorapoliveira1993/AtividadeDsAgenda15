using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeDsAgenda15.Model
{
    public class Event(string name, DateTime startDate, DateTime endDate,
    double numberParticipants, double costParticipant, Location eventLocation )
    {
        public string Name { get; } = name;
        public string StartDate { get; } = startDate.ToShortDateString();
        public string EndDate { get; } = endDate.ToShortDateString();
        public double NumberParticipants { get; } = numberParticipants;
        public double CostParticipant { get; } = costParticipant;
        public string EventLocation { get; } = eventLocation.Name;
        public int Duration { get; } = (endDate - startDate).Days;
        private double _totalprice = -1;
        public string Totalprice { get{

                if(_totalprice != -1) return _totalprice.ToString("C");

                double locationCost = eventLocation.GetTotalPrice(Duration);
                double totalCostParticipants = NumberParticipants * Duration * CostParticipant;
                _totalprice = locationCost + totalCostParticipants;
                return _totalprice.ToString("C");
       
        }  }
    }
}
