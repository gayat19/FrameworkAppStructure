using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerModelLibrary
{
    public class UnableToAddCustomerException:Exception
    {
        string message;
        public UnableToAddCustomerException()
        {

        }
        public UnableToAddCustomerException(string message) :base(message)
        {
        }

    }
    public class NoCustomerAvailableException:Exception
    {

    }
}

