namespace MobileSalesTool.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int PromotionID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Promotion Promotions { get; set; }
        public virtual Employee Employees { get; set; }
    }
}