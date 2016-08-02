using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstamojoAPI
{
  public  class PaymentOrderListResponse
    {

      public int? count { get; set; }
      public string next { get; set; }
      public string previous { get; set; }
      public Order[] orders { get; set; }

    }
}
