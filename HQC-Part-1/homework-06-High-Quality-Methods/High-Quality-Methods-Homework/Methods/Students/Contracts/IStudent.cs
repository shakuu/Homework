using Methods.OtherInfo.Contracts;

namespace Methods.Students.Contracts
{
    public interface IStudent
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        IOtherInformation OtherInfo { get; set; }
    }
}
