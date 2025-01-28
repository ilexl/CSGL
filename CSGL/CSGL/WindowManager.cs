using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;

namespace CSGL
{
    internal class WindowManager
    {
        public static WindowManager? Singleton { get; private set; }

        List<Window> windows;
        public WindowManager()
        {
            if (Singleton == null) { Singleton = this; }
            else { throw new Exception("WindowManager can only have ONE instance..."); }
            Console.WriteLine($"** WindowManager created");
            windows = new List<Window>();
        }

        public void AddWindowToProgram(Window window)
        {
            windows.Add(window);
        }

        public void Run()
        {
            Console.WriteLine($"** WindowManager running...");
            // Main loop to process events for all windows and call RenderManually for each
            while (windows.Count > 0)
            {
                try
                {
                    foreach (var window in windows.ToArray()) // Use ToArray to avoid modifying collection during iteration
                    {
                        if (!window.IsExiting)
                        {
                            // Ensure window context is processed
                            window.ProcessEvents(0.001);

                            // Manually call render method
                            window.RenderManually();
                            window.UpdateMannually();
                        }
                        else if(window.MainWindow)
                        {
                            windows.Clear();
                            break;
                        }
                        else
                        {
                            // Dispose of closed windows
                            window.Dispose();
                            windows.Remove(window);
                        }
                    }
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            Console.WriteLine($"** WindowManager stopping...");
        }


    }
}
