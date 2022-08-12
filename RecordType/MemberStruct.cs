using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecordType
{
    public struct MemberStruct
    {
        public MemberStruct(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
}