using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALLibrary.Domain_Classes;
using System.Data.Entity.SqlServer;
using DALLibrary.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace UnitTestClinic
{
    public class Manager
    {
        private ClinicDbContext _context; // DbContext

        //[SetUp]
        //public void Setup()
        //{

        //    _context = new ClinicDbContext();
        //}

        //[Test]
        //public void EmailIsRequired()
        //{
        //    var admin = new Admin(); //Admin Class

        //    var validationResults = new List<ValidationResult>();
        //    var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

        //    Assert.IsFalse(isValid);
        //    Assert.Equals(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        //}

        //[Test]
        //public void PasswordIsRequired()
        //{
        //    var admin = new Admin();

        //    var validationResults = new List<ValidationResult>();
        //    var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

        //    Assert.IsFalse(isValid);
        //    Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        //}

        //[Test]
        //public void EmailValidation()
        //{
        //    var admin = new Admin { Email = "invalidemail" }; // Invalid email 

        //    var validationResults = new List<ValidationResult>();
        //    var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

        //    Assert.IsFalse(isValid);
        //    Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        //}

        //[Test]
        //public void PasswordValidation()
        //{
        //    var user = new Admin { Password = "weakpassword" };

        //    var validationResults = new List<ValidationResult>();
        //    var isValid = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

        //    Assert.IsFalse(isValid);
        //    Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Password must contains a Uppercase,Lowercase letter,number"));
        //}
        //[Test]
        //public void EmailAndPasswordExistInDatabase()
        //{
        //    var email = "luffy1@gmail.com";
        //    var password = "Luffy12345";

        //    // Perform database check
        //    var isValid = _context.Admins.Any(u => u.Email == email && u.Password == password);

        //    Assert.IsTrue(isValid);
        //}

        //[Test]
        //public void EmailAndPasswordDoNotExistInDatabase()
        //{
        //    var email = "nonexistent@example.com";
        //    var password = "WeakPassword123";

        //    // Perform database check
        //    var isValid = _context.Admins.Any(u => u.Email == email && u.Password == password);

        //    Assert.IsFalse(isValid);
        //}

    }
}
