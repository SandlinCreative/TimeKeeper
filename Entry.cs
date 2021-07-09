using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class Entry
    {
        public string Location { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public double TimeSpan { get; set; }
        public double Rate { get; set; }
        public double Billabe { get; set; }
        public string Notes { get; set; }

        public Entry(string location, DateTime inTime, DateTime outTime, double rate, string notes)
        {
            Location = location;
            InTime = inTime;
            OutTime = outTime;
            TimeSpan = CalcTimeSpan();
            Rate = rate;
            Billabe = CalcBillableAmount();
            Notes = notes;
        }

        public double CalcTimeSpan()
        {
            TimeSpan = Math.Round(OutTime.Subtract(InTime).TotalHours * 4, MidpointRounding.ToPositiveInfinity) / 4;
            return TimeSpan;
        }

        public double CalcBillableAmount()
        {
            Billabe = TimeSpan * Rate;
            return Billabe;
        }
    }
}
