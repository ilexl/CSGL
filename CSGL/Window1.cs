using CSGL;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;

class Window1 : Window
{
    internal override void Render(GameWindow window)
    {
        GL.ClearColor(0.3f, 0.4f, 0.5f, 1.0f); // Purpleish background
        GL.Clear(ClearBufferMask.ColorBufferBit); // Clear the window
    }
    internal override void Update(GameWindow window)
    {

    }

    public Window1( string title = "Window 1",
                    int width = 1920,
                    int height = 1080,
                    bool main = true)
        : base(title, width, height, main)
    {

    }
}
