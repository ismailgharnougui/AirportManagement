using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{


    public enum PlaneType
    {
        Boing,
        Airbus
    }
    public class Plane

    {

        #region exemple 
        //public string name;
        //public string GetName() { 
        //    return name;
        //}

        //public void setName(string value)

        //    {
        //        this.name = value;   
        //    }

        #endregion

        #region version 

        // prop + 2 tab : light version

        //public string Name { get; set; }

        //propg + 2 tab : secure version 
        //public string Prenom { get; private set; }

        //propfull + 2 tab : full version 
        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}
        #endregion

        #region prop de base
        public int PlaneId { get; set; }

        public PlaneType PlaneType { get; set; }

        public DateTime ManufactureDate { get; set; }
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        #endregion

        #region prop de navigation
        public virtual IList<Flight> Flights { get; set; }


        #endregion

     
    }
}
