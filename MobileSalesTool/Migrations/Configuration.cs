namespace MobileSalesTool.Migrations
{
    using MobileSalesTool.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MobileSalesTool.DAL.MobileSalesToolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.MobileSalesToolContext context)
        {
            var employees = new List<Employee>
            {
                new Employee { FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01") },
                new Employee { FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Employee { FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Employee { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Employee { FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01") },
                new Employee { FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01") },
                new Employee { FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01") },
                new Employee { FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-08-11") }
            };
            employees.ForEach(s => context.Employees.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var promotions = new List<Promotion>
            {
                new Promotion {PromotionID = 1050, Title = "Chemistry",      Credits = 3, },
                new Promotion {PromotionID = 4022, Title = "Microeconomics", Credits = 3, },
                new Promotion {PromotionID = 4041, Title = "Macroeconomics", Credits = 3, },
                new Promotion {PromotionID = 1045, Title = "Calculus",       Credits = 4, },
                new Promotion {PromotionID = 3141, Title = "Trigonometry",   Credits = 4, },
                new Promotion {PromotionID = 2021, Title = "Composition",    Credits = 3, },
                new Promotion {PromotionID = 2042, Title = "Literature",     Credits = 4, }
            };
            promotions.ForEach(s => context.Promotions.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Alexander").ID,
                    PromotionID = promotions.Single(c => c.Title == "Chemistry" ).PromotionID,
                    Grade = Grade.A
                },
                 new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Alexander").ID,
                    PromotionID = promotions.Single(c => c.Title == "Microeconomics" ).PromotionID,
                    Grade = Grade.C
                 },
                 new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Alexander").ID,
                    PromotionID = promotions.Single(c => c.Title == "Macroeconomics" ).PromotionID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     EmployeeID = employees.Single(s => s.LastName == "Alonso").ID,
                    PromotionID = promotions.Single(c => c.Title == "Calculus" ).PromotionID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     EmployeeID = employees.Single(s => s.LastName == "Alonso").ID,
                    PromotionID = promotions.Single(c => c.Title == "Trigonometry" ).PromotionID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Alonso").ID,
                    PromotionID = promotions.Single(c => c.Title == "Composition" ).PromotionID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Anand").ID,
                    PromotionID = promotions.Single(c => c.Title == "Chemistry" ).PromotionID
                 },
                 new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Anand").ID,
                    PromotionID = promotions.Single(c => c.Title == "Microeconomics").PromotionID,
                    Grade = Grade.B
                 },
                new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Barzdukas").ID,
                    PromotionID = promotions.Single(c => c.Title == "Chemistry").PromotionID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Li").ID,
                    PromotionID = promotions.Single(c => c.Title == "Composition").PromotionID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    EmployeeID = employees.Single(s => s.LastName == "Justice").ID,
                    PromotionID = promotions.Single(c => c.Title == "Literature").PromotionID,
                    Grade = Grade.B
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Employees.ID == e.EmployeeID &&
                         s.Promotions.PromotionID == e.PromotionID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}