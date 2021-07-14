using System;
using System.Collections.Generic;
using System.Globalization;

namespace Models
{
    public class Customers
    {
        public DateTime _cBDay=DateTime.Today;
        private string _cBDayString;
        public string BirthDayFormat = "MM-dd-yyyy";
        public string ageNullIfZero;
        private int _cAge;
        private List<string> _cSystems=new List<string>();
        public string cName { get; set; }
        public string cStreet { get; set; }
        public string cCity { get; set; }
        public string cState { get; set; }
        public string cPhone { get; set; }
        public string cEmail { get; set; }
        public string cBDay
        { get
        {
            return _cBDayString;
        }
        set
        {
            DateTime.TryParseExact(value,BirthDayFormat,CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _cBDay);
            this.cAge=(int)((DateTime.Today-_cBDay).TotalDays/365.25);
            _cBDayString=value;
        }
        }
        public int cAge
        { get
        {
            return _cAge;
        }
        private set
        {
            _cAge=value;
            ageNullIfZero=_cAge.ToString();
        }
        }
        public List<Orders> cOrders { get; set; }
        public List<string> cSystems
        { get
        {
            return _cSystems;
        }
        set
        {
            _cSystems.AddRange(value);
        }
        }
        public string cStoreAddedAt { get; set; }
        public string cID { get; set; }
    }
}