using CSGL;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Program starting!");

        WindowManager wm = new WindowManager();
        wm.AddWindowToProgram(new Window1());
        wm.AddWindowToProgram(new Window2());
        wm.Run();

        Console.WriteLine($"Program closing!");
    }
}
