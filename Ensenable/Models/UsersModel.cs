namespace Ensenable.Models
{
    public class UsersModel
    {
        public int id_user { get; set; }
        public string user_name { get; set; }
        public string user_firstlastname { get; set; }
        public string user_secondlastname { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
        public int user_role { get; set; }
        public string user_status { get; set; }
    }
}
