using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;


namespace CSGL
{
    public class Window
    {
        private GameWindow _window;
        private Action<GameWindow> _renderAction;
        private Action<GameWindow> _updateAction;

        public bool IsExiting => _window.IsExiting;
        public bool MainWindow;

        public Window(string title, int width, int height, bool main)
        {
            Console.WriteLine($"** {title} created");

            _renderAction = Render;
            _updateAction = Update;

            var nativeWindowSettings = new NativeWindowSettings
            {
                Title = title,
                Size = new OpenTK.Mathematics.Vector2i(width, height),
                StartVisible = true
            };

            _window = new GameWindow(GameWindowSettings.Default, nativeWindowSettings);
            MainWindow = main;

            // Hook into OpenTK's event lifecycle
            _window.Load += OnLoad;

            _window.RenderFrame += OnRenderFrame;
            _window.UpdateFrame += OnUpdateFrame;
            _window.Closing += OnClosing;
        }

        internal virtual void Render(GameWindow window)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Default to black
            GL.Clear(ClearBufferMask.ColorBufferBit); // Clear the window
        }
        internal virtual void Update(GameWindow window)
        {
            // do nothing
        }

        private void OnLoad()
        {
            _window.MakeCurrent();
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Default to black
        }

        private void OnRenderFrame(OpenTK.Windowing.Common.FrameEventArgs e)
        {
            _window.MakeCurrent(); // Ensure the context is current before rendering
            _renderAction?.Invoke(_window); // Call the user-defined render action
            _window.SwapBuffers(); // Swap buffers to display the rendered frame
        }

        private void OnUpdateFrame(OpenTK.Windowing.Common.FrameEventArgs e)
        {
            _updateAction?.Invoke(_window); // Call the user-defined update action
        }

        private void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _window.MakeCurrent();
            // Cleanup or save state if needed
        }

        public void ProcessEvents(double timeout = 0.001)
        {
            _window.ProcessEvents(timeout); // Process window events (non-blocking)
        }

        public void Dispose()
        {
            Console.WriteLine($"** {_window.Title} destroyed");
            _window?.Close();
            _window?.Dispose();
        }

        // Call the render action manually in the main loop
        public void RenderManually()
        {
            _window.MakeCurrent(); // Ensure context is current
            _renderAction?.Invoke(_window); // Invoke the custom render action
            _window.SwapBuffers(); // Swap buffers
        }

        public void UpdateMannually()
        {
            _window.MakeCurrent();
            _updateAction?.Invoke(_window);
        }
    }
}
