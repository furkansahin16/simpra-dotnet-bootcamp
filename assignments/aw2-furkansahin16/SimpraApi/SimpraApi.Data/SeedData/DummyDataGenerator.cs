using Bogus;
using Bogus.Extensions;

namespace SimpraApi.Data.SeedData;

public static class DummyDataGenerator
{
    public static IEnumerable<Staff> GenerateDummyData(int dataCount)
    {
        var faker = new Faker<Staff>()
            .Ignore(x => x.DeletedBy)
            .Ignore(x => x.DeletedAt)
            .Ignore(x => x.UpdatedAt)
            .Ignore(x => x.UpdatedBy)
            .RuleFor(x => x.CreatedAt, f => DateTime.UtcNow)
            .RuleFor(x => x.CreatedBy, f => "admin")
            .RuleFor(x => x.Status, f => Status.Added)
            .RuleFor(x => x.Id, f => f.IndexFaker + 1)
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Email, f => f.Internet.Email().ToLower())
            .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber("###########"))
            .RuleFor(x => x.DateOfBirth, f => f.Person.DateOfBirth)
            .RuleFor(x => x.AddressLine, f => f.Address.SecondaryAddress().ClampLength(max: 50))
            .RuleFor(x => x.City, f => f.Address.City().ClampLength(max: 30))
            .RuleFor(x => x.Country, f => f.Address.Country().ClampLength(max: 20))
            .RuleFor(x => x.Province, f => f.Address.State().ClampLength(max: 30));

        var dummyData = faker.Generate(dataCount);
        return dummyData;
    }
}
