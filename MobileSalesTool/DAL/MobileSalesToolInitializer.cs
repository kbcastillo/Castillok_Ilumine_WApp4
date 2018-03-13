using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MobileSalesTool.Models;

namespace MobileSalesTool.DAL
{
    public class MobileSalesToolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MobileSalesToolContext>
        
    {
        protected override void Seed(MobileSalesToolContext context)
        {
            var employees = new List<Employee>
            {
            new Employee{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Employee{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Employee{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Employee{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Employee{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Employee{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
            var promotions = new List<Promotion>
            {
            new Promotion{PromotionID=1050,Title="BOGO Galaxy S9 or S9+",Credits=3,},
            new Promotion{PromotionID=4022,Title="$200 off any Galaxy Note 8, S8, S8+",Credits=3,},
            new Promotion{PromotionID=4041,Title="$200 off any iPhone 8, 8 Plus",Credits=3,},
            new Promotion{PromotionID=1045,Title="$50 off new line activations",Credits=4,},
            new Promotion{PromotionID=3141,Title="$50 off LG G Pad 8.0",Credits=4,},
            new Promotion{PromotionID=2021,Title="$25 off promotional credit for switching",Credits=3,},
            new Promotion{PromotionID=2042,Title="IlumiCast TV Offer for new customers",Credits=4,}
            };
            promotions.ForEach(s => context.Promotions.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{EmployeeID=1,PromotionID=1050,Grade=Grade.A},
            new Enrollment{EmployeeID=1,PromotionID=4022,Grade=Grade.C},
            new Enrollment{EmployeeID=1,PromotionID=4041,Grade=Grade.B},
            new Enrollment{EmployeeID=2,PromotionID=1045,Grade=Grade.B},
            new Enrollment{EmployeeID=2,PromotionID=3141,Grade=Grade.F},
            new Enrollment{EmployeeID=2,PromotionID=2021,Grade=Grade.F},
            new Enrollment{EmployeeID=3,PromotionID=1050},
            new Enrollment{EmployeeID=4,PromotionID=1050,},
            new Enrollment{EmployeeID=4,PromotionID=4022,Grade=Grade.F},
            new Enrollment{EmployeeID=5,PromotionID=4041,Grade=Grade.C},
            new Enrollment{EmployeeID=6,PromotionID=1045},
            new Enrollment{EmployeeID=7,PromotionID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}