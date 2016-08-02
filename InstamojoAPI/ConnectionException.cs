using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstamojoAPI
{
  public  class ConnectionException:BaseException
    {
        public ConnectionException(string message)
            : base()
        { }
    }
}
