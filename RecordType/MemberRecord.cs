using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordType
{
    public record MemberRecord(string Name, int Age): PersonRecord(Name, Age)
    {
        public DateTime MemberSince { get; set; }
        public int LoyaltyPoints { get; set; }
    };
}