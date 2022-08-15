using System;
using System.ComponentModel.DataAnnotations;

namespace AMS.Data
{
    
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NextOfKinFullName { get; set; }
        public string NextOfKinNumber { get; set; }
        public string NextOfKinAdress { get; set; }
        public string HomeAddress { get; set; }
        public string Photo { get; set; }
        public string ProofOfIncome { get; set; }
        public string fileAttached { get; set; }
        //  public string City { get; set; }
        //   public  string Province { get; set; }
        //  public string Zip { get; set; }
    }
}
