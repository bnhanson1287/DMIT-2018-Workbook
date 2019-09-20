namespace WestWindSystem.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class Address
    {
        //property
        [NotMapped]//This is NOT a column in the database
        public string FullAddress
        {
            get
            {
                string result = $"{Address1}, {City}, {Country}";

                return result;
            }
        }
    }
}
