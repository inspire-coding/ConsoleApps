using RecordType;

class Program
{
    public static void Main(string[] args)
    {
        MemberClass memberClass1 = new MemberClass
        {
            Name = "Peti",
            Age = 34,
            MemberSince = DateTime.Now
        };
        MemberClass memberClass2 = memberClass1;
        memberClass2.MemberSince = DateTime.Now.AddDays(1);

        MemberRecord memberRecord1 = new MemberRecord("Peti", 34)
        {
            MemberSince = DateTime.Now,
            LoyaltyPoints = 10
        };
        memberRecord1.MemberSince = DateTime.Now.AddDays(2);
        MemberRecord memberRecord2 = memberRecord1; //with { MemberSince = DateTime.Now.AddDays(3), LoyaltyPoints = 12 };

        System.Console.WriteLine(memberClass1);
        System.Console.WriteLine(memberClass2);
        System.Console.WriteLine(memberClass1.Equals(memberClass2));

        System.Console.WriteLine(memberRecord1);
        System.Console.WriteLine(memberRecord2);
        // memberRecord2.MemberSince = DateTime.Now.AddDays(4);
        System.Console.WriteLine(memberRecord2);
        System.Console.WriteLine(memberRecord1.Equals(memberRecord2));

        var propertyInfo = typeof(MemberRecord).GetProperties().FirstOrDefault(p => p.Name == nameof(MemberRecord.Name));
        propertyInfo.SetValue(memberRecord2, "Viki");
        System.Console.WriteLine(memberRecord1);
        System.Console.WriteLine(memberRecord2);
        System.Console.WriteLine(memberRecord1.Equals(memberRecord2));
        System.Console.WriteLine(memberRecord1.Name.Equals(memberRecord2.Name));
        System.Console.WriteLine(memberRecord1.Name);
        System.Console.WriteLine(memberRecord2.Name);

        string name;
        int age;
        (name, age) = (MemberRecord)memberRecord1;
        System.Console.WriteLine($"Name: {name}, Age: {age}");

        MemberStruct memberStruct = new MemberStruct();
        memberStruct.Age = 12;
    }
}