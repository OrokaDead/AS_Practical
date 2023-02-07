namespace _211787P_Practical_Assn.Model
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public string Values { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }

}
