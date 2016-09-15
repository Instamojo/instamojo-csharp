namespace InstamojoAPI
{
   public class AccessTokenResponse
    {
       public string access_token { get; set; }
       public string token_type { get; set; }
       public long expires_in { get; set; }
       public string scope { get; set; }
       public string error { get; set; }
    }
}
