using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft
    }
    
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Desc { get; set; }
        public double ClaimAmount { get; set; }

        //DATE OF INCIDENT 
        public DateTime IncidentDate { get; set; }

        //Date of Claim
        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(int claimID, ClaimType claimType, string desc, double claimAmount,DateTime incidentDate, DateTime dateOfClaim, bool isValid)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Desc = desc;
            ClaimAmount = claimAmount;
            IncidentDate = incidentDate;
            DateOfClaim = dateOfClaim;

            IsValid = isValid;
        } 
        

    }
}
