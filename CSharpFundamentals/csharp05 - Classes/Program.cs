
namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Person newton = new Person("Isaac", "Newton", 373);
            newton.PrintPerson();

            Person galileo = new Person("Galileo", "Galilei", 452);
            galileo.PrintPerson();
        }
    }
}
