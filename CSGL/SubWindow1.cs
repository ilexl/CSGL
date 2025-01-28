using CSGL;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Desktop;

class SubWindow1 : Window
{
    internal override void Render(GameWindow window)
    {
        GL.ClearColor(0.3f, 0.4f, 0.5f, 1.0f); // Purpleish background
        GL.Clear(ClearBufferMask.ColorBufferBit); // Clear the window
    }

    internal override void Update(GameWindow window)
    {
        
    }

    public SubWindow1(string title = "SubWindow 1",
                    int width = 1920,
                    int height = 1080,
                    bool main = false)
        : base(title, width, height, main)
    {

    }
}
