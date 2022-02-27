namespace GPDataTools.StormAlert.ViewModels;

public class GraphicsDrawable : IDrawable
{
    ICanvas _canvas;

    int i = 0;

    public void Draw(ICanvas canvas, RectangleF dirtyRect)
    {
        _canvas = canvas;

        _canvas.StrokeColor = Colors.Blue;
        _canvas.StrokeSize = 6;
        _canvas.DrawLine(10, 10, 10, i);
    }

    public void Increment(int num)
    {
        i++;
        //_canvas.DrawLine(10, 10, 10, i);
    }
}
