using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsLibrary
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimList = new Queue<Claim>();


        public Queue<Claim> GetClaimList()
        {
            return _claimList;
        }

        public void AddNewClaim(Claim claimItem)
        {
            _claimList.Enqueue(claimItem);
        }

        public Claim SeeNextClaim()
        {
           return _claimList.Peek();

        }
        public void RemoveNextClaim()
        {
             _claimList.Dequeue();
        }


    }
}
