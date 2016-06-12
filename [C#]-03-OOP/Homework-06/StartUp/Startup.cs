namespace StartUp
{
    class Startup
    {
        static void Main()
        {
            _01_StudentAssembly_Tests.BasicTests.TestEquals();
            _01_StudentAssembly_Tests.BasicTests.TestHash();
            _01_StudentAssembly_Tests.BasicTests.TestClone();
        }
    }
}
