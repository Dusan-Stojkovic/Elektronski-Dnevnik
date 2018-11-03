

namespace DemoLibrary
{
    public interface IPersons
    {
        string Name { get; set; }
        string Surname { get; set; }
        int UniqueID { get; set; }

        void ReadFullNameFromDB();
        void ReadListOfPersons();
    }
}
