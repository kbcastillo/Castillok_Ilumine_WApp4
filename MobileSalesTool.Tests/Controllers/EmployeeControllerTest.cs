using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileSalesTool;
using MobileSalesTool.Controllers;

namespace MobileSalesTool.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
 
    {

        public void Create()
        {
            EmployeeController empController = new EmployeeController();

            Assert.IsNotNull(empController, "An employee can not have null values!");
        }
    }
}
