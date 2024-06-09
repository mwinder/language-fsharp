namespace ConsoleApplication1
{
    using System;

    using CoreLibrary;

    class Program
    {
        static void Main()
        {
            MessageHandlers.Handle(new RegisterUser("Matthew", "password"));
            MessageHandlers.Handle(new DeactivateUser("Matthew"));

            Console.ReadLine();
        }
    }
}
