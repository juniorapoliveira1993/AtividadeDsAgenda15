using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeDsAgenda15.Model
{
    public class Location(string name, double dailyPrice, double capacity)
    {
        public string Name {  get; } =  name;
        public double DailyPrice { get; } = dailyPrice;

        public double Capacity { get; } = capacity;

        public double GetTotalPrice(int numberDays){
            return numberDays * DailyPrice;
        }

    }  
}
