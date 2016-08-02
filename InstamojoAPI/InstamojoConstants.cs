using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstamojoAPI
{
   public class InstamojoConstants
    {
       public InstamojoConstants()
       {
           INSTAMOJO_AUTH_ENDPOINT = "https://test.instamojo.com/oauth2/token/";
           CLIENT_ID = "tmLkZZ0zV41nJwhayBGBOI4m4I7bH55qpUBdEXGS";
           CLIENT_SECRET = "IDejdccGqKaFlGav9bntKULvMZ0g7twVFolC9gdrh9peMS0megSFr7iDpWwWIDgFUc3W5SlX99fKnhxsoy6ipdAv9JeQwebmOU6VRvOEQnNMWwZnWglYmDGrfgKRheXs";
           GRANT_TYPE = "client_credentials";
           INSTAMOJO_API_ENDPOINT = "https://test.instamojo.com/v2/";
       }
       public static string INSTAMOJO_AUTH_ENDPOINT { get; set; }
       public static string CLIENT_ID { get; set; }
       public static string CLIENT_SECRET { get; set; }
       public static string GRANT_TYPE { get; set; }
       public static string INSTAMOJO_API_ENDPOINT { get; set; }
    }
}
