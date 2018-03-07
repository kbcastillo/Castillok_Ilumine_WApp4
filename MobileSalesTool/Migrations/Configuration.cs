namespace MobileSalesTool.Migrations
{
    using MobileSalesTool.Models;
    using MobileSalesTool.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MobileSalesToolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MobileSalesToolContext context)
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
                    EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            employees.ForEach(s => context.Employees.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var consumers = new List<Consumer>
            {
                new Consumer { FirstMidName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Consumer { FirstMidName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Consumer { FirstMidName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Consumer { FirstMidName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Consumer { FirstMidName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            consumers.ForEach(s => context.Consumers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    ConsumerID  = consumers.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    ConsumerID  = consumers.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    ConsumerID  = consumers.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    ConsumerID  = consumers.Single( i => i.LastName == "Kapoor").ID }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var promotions = new List<Promotion>
            {
                new Promotion {PromotionID = 1050, Title = "Chemistry",      Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Consumers = new List<Consumer>()
                },
                new Promotion {PromotionID = 4022, Title = "Microeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Consumers = new List<Consumer>()
                },
                new Promotion {PromotionID = 4041, Title = "Macroeconomics", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID,
                  Consumers = new List<Consumer>()
                },
                new Promotion {PromotionID = 1045, Title = "Calculus",       Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Consumers = new List<Consumer>()
                },
                new Promotion {PromotionID = 3141, Title = "Trigonometry",   Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Consumers = new List<Consumer>()
                },
                new Promotion {PromotionID = 2021, Title = "Composition",    Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Consumers = new List<Consumer>()
                },
                new Promotion {PromotionID = 2042, Title = "Literature",     Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Consumers = new List<Consumer>()
                },
            };
            promotions.ForEach(s => context.Promotions.AddOrUpdate(p => p.PromotionID, s));
            context.SaveChanges();

            var AccountTypes = new List<AccountType>
            {
                new AccountType {
                    ConsumerID = consumers.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new AccountType {
                    ConsumerID = consumers.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new AccountType {
                    ConsumerID = consumers.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };
            AccountTypes.ForEach(s => context.AccountTypes.AddOrUpdate(p => p.ConsumerID, s));
            context.SaveChanges();

            AddOrUpdateConsumer(context, "Chemistry", "Kapoor");
            AddOrUpdateConsumer(context, "Chemistry", "Harui");
            AddOrUpdateConsumer(context, "Microeconomics", "Zheng");
            AddOrUpdateConsumer(context, "Macroeconomics", "Zheng");

            AddOrUpdateConsumer(context, "Calculus", "Fakhouri");
            AddOrUpdateConsumer(context, "Trigonometry", "Harui");
            AddOrUpdateConsumer(context, "Composition", "Abercrombie");
            AddOrUpdateConsumer(context, "Literature", "Abercrombie");

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

        void AddOrUpdateConsumer(MobileSalesToolContext context, string PromotionTitle, string ConsumerName)
        {
            var prm = context.Promotions.SingleOrDefault(c => c.Title == PromotionTitle);
            var cru = prm.Consumers.SingleOrDefault(i => i.LastName == ConsumerName);
            if (cru == null)
                prm.Consumers.Add(context.Consumers.Single(i => i.LastName == ConsumerName));
        }
    }
}