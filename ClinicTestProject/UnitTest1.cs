using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace ClinicTestProject
{
    public class Tests
    {


        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        private ClinicDbContext _context; // DbContext

        [SetUp]
        public void Setup()
        {

            _context = new ClinicDbContext();
        }

        [Test]
        public void EmailIsRequired()
        {
            var admin = new Manager(); //Admin Class

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        }

        [Test]
        public void PasswordIsRequired()
        {
            var admin = new Manager();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        }

        [Test]
        public void EmailValidation()
        {
            var admin = new Manager { Email = "invalidemail" }; // Invalid email 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(admin, new ValidationContext(admin), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        }

        [Test]
        public void PasswordValidation()
        {
            var user = new Manager { Password = "weakpassword" };

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Password must contains a Uppercase,Lowercase letter,number"));
        }
        [Test]
        public void Valid_Model_Correct_Credentials()
        {
            // Arrange
            var loginView = new Manager {Name="Naveen", Email = "naveen@gmail.com", Password = "Naveen@123" };

            // Act & Assert
            Assert.DoesNotThrow(() => ValidateModel(loginView));
        }

        private void ValidateModel(Manager model)
        {
            // Perform model validation using DataAnnotations
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = ValidateModel(model, validationContext);

            if (validationResults.Length > 0)
            {
                var errorMessage = FormatValidationResults(validationResults);
                throw new ValidationException(errorMessage);
            }

            // Now check the credentials against the database using your data access logic
            if (!AdminExistsInDatabase(model))
            {
                throw new ValidationException("Admin does not exist in the database");
            }
        }

        private ValidationResult[] ValidateModel(object model, ValidationContext validationContext)
        {
            // Helper method for model validation
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults.ToArray();
        }

        private string FormatValidationResults(IEnumerable<ValidationResult> validationResults)
        {
            // Helper method to format validation results as a string
            var messages = validationResults.Select(result => result.ErrorMessage);
            return string.Join(Environment.NewLine, messages);
        }

        public bool AdminExistsInDatabase(Manager model)
        {
            var connectionString = "data source=NAVEEN-BOOK-8C9;initial catalog=CLinicDb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if there is an Manager with the specified credentials in the database
                using (var command = new SqlCommand($"SELECT COUNT(*) FROM Managers WHERE Email = '{model.Email}' AND Password = '{model.Password}'", connection))
                {
                    return (int)command.ExecuteScalar() > 0;
                }
            }
        }

        [Test]
        public void StatusIsRequired()
        {
            var appointment = new Appointment();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(appointment, new ValidationContext(appointment), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "The Status field is required."));
        }
        [Test]
        public void DetailsIsRequired()
        {
            var appointment = new Appointment();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(appointment, new ValidationContext(appointment), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Select Details"));
        }
        [Test]
        public void DoctorNameIsRequired()
        {
            var doctor = new Doctor(); // Doctor Class

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Name"));
        }

        [Test]
        public void PhoneIsRequired()
        {
            var doctor = new Doctor();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Phone Number"));
        }

        // New test method for Address validation
        [Test]
        public void AddressIsRequired()
        {
            var doctor = new Doctor();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Address"));
        }

        // New test method for Specialization validation
        [Test]
        public void SpecializationIsRequired()
        {
            var doctor = new Doctor();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Specialization"));
        }

        // New test method for Timings validation
        [Test]
        public void TimingsIsRequired()
        {
            var doctor = new Doctor();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Select Timings"));
        }
        [Test]
        public void MedicineNameIsRequired()
        {
            var medicine = new Medicine();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(medicine, new ValidationContext(medicine), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please enter medicine name"));
        }

        // Method to check if a medicine with given properties exists in the database
        private bool MedicineExistsInDatabase(string medicineName, float price, float discount)
        {
            // Perform database check
            var exists = _context.Medicines.Any(m => m.MedicineName == medicineName && m.Price == price && m.Discount == discount);

            return exists;
        }

        [Test]
        public void NameIsRequired()
        {
            var patient = new Patient();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Name"));
        }


        [Test]
        public void PhoneIsRequiredP()
        {
            var patient = new Patient();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Phone Number"));
        }

        [Test]
        public void AddressIsRequiredP()
        {
            var patient = new Patient();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Address"));
        }

        [Test]
        public void GenderIsRequired()
        {
            var patient = new Patient();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please select Gender"));
        }

        [Test]
        public void EmailIsRequiredP()
        {
            var patient = new Patient();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        }

        [Test]
        public void EmailValidationP()
        {
            var patient = new Patient { Email = "invalidemail" }; // Invalid email 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        }

        [Test]
        public void PasswordIsRequiredP()
        {
            var patient = new Patient();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        }

        [Test]
        public void PasswordValidationP()
        {
            var patient = new Patient { Password = "weakpassword" }; // Invalid password 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(patient, new ValidationContext(patient), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Password must contains a Uppercase,Lowercase letter,number and symbol"));
        }
        [Test]
        public void NameIsRequiredPh()
        {
            var pharmacist = new Pharmacist();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(pharmacist, new ValidationContext(pharmacist), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Name"));
        }

        [Test]
        public void EmailIsRequiredPh()
        {
            var pharmacist = new Pharmacist();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(pharmacist, new ValidationContext(pharmacist), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        }

        [Test]
        public void EmailValidationPh()
        {
            var pharmacist = new Pharmacist { Email = "invalidemail" }; // Invalid email 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(pharmacist, new ValidationContext(pharmacist), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        }

        [Test]
        public void PasswordIsRequiredPh()
        {
            var pharmacist = new Pharmacist();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(pharmacist, new ValidationContext(pharmacist), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        }

        [Test]
        public void PasswordValidationPh()
        {
            var pharmacist = new Pharmacist { Password = "weakpassword" }; // Invalid password 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(pharmacist, new ValidationContext(pharmacist), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Password must contains a Uppercase,Lowercase letter,number and symbol"));
        }
       
       
        [Test]
        public void NameIsRequiredD()
        {
            var doctor = new Doctor();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Name"));
        }

        [Test]
        public void EmailIsRequiredD()
        {
            var doctor = new Doctor();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        }

        [Test]
        public void EmailValidationD()
        {
            var doctor = new Doctor { Email = "invalidemail" }; // Invalid email 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        }

        [Test]
        public void PasswordIsRequiredD()
        {
            var doctor = new Doctor();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(doctor, new ValidationContext(doctor), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        }
        [Test]
        public void NameIsRequiredfo()
        {
            var frontOfficer = new Front_Officer();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(frontOfficer, new ValidationContext(frontOfficer), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Name"));
        }

        [Test]
        public void EmailIsRequiredfo()
        {
            var frontOfficer = new Front_Officer();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(frontOfficer, new ValidationContext(frontOfficer), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Email"));
        }

        [Test]
        public void EmailValidationfo()
        {
            var frontOfficer = new Front_Officer { Email = "invalidemail" }; // Invalid email 

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(frontOfficer, new ValidationContext(frontOfficer), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Invalid email"));
        }

        [Test]
        public void PasswordIsRequiredfo()
        {
            var frontOfficer = new Front_Officer();

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(frontOfficer, new ValidationContext(frontOfficer), validationResults, true);

            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(v => v.ErrorMessage == "Please Enter Password"));
        }
        


    }
}