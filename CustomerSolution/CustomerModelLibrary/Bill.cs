using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModelLibrary
{
    public class Bill
    {
        private int billNumber;
        public int CustomerId { get; set; }
        public float Amount { get; set; }
        public DateTime? BillDate { get; set; }
        public int BillNumber { get => billNumber*1000; set => billNumber = value; }

       
        public override bool Equals(object obj)
        {
            if(obj != null )
            {
                int number = ((Bill)obj).BillNumber;
                return this.BillNumber == number ? true : false;
            }
            throw new ObjectNullException();
           
        }
    }
}
