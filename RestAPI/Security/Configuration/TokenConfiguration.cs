namespace RestAPI.Security.Configuration
{

    /*CLASSE RESPONSÁVEL  PELO QUE IRÁ COMPOR O JWT*/


    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
