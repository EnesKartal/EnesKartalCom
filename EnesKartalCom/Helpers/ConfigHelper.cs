namespace EnesKartalCom.Helpers
{
    public class Config
    {
        public string ConnectionString { get; set; }
        public bool ForceSsl { get; set; }
        public string Secret { get; set; }
        public int TokenExpireDay { get; set; }
    }
}
