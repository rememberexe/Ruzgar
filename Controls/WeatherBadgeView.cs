using Microsoft.Maui.Graphics;

namespace Ruzgar.Controls;

public class WeatherBadgeView : GraphicsView, IDrawable
{
    public static readonly BindableProperty WeatherCodeProperty =
        BindableProperty.Create(
            nameof(WeatherCode),
            typeof(int),
            typeof(WeatherBadgeView),
            0,
            propertyChanged: OnVisualPropertyChanged);

    public static readonly BindableProperty AccentColorProperty =
        BindableProperty.Create(
            nameof(AccentColor),
            typeof(Color),
            typeof(WeatherBadgeView),
            Colors.DeepSkyBlue,
            propertyChanged: OnVisualPropertyChanged);

    private bool _isRunning;
    private float _phase;

    public WeatherBadgeView()
    {
        Drawable = this;
        InputTransparent = true;

        Loaded += (_, _) => Start();
        Unloaded += (_, _) => _isRunning = false;
    }

    public int WeatherCode
    {
        get => (int)GetValue(WeatherCodeProperty);
        set => SetValue(WeatherCodeProperty, value);
    }

    public Color AccentColor
    {
        get => (Color)GetValue(AccentColorProperty);
        set => SetValue(AccentColorProperty, value);
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        float size = Math.Min(dirtyRect.Width, dirtyRect.Height);
        float left = dirtyRect.Center.X - size / 2f;
        float top = dirtyRect.Center.Y - size / 2f;
        var rect = new RectF(left, top, size, size);

        canvas.SaveState();
        DrawGlassOrb(canvas, rect);

        if (IsStorm)
            DrawStorm(canvas, rect);
        else if (IsRain)
            DrawRain(canvas, rect);
        else if (IsSnow)
            DrawSnow(canvas, rect);
        else if (IsFog)
            DrawFog(canvas, rect);
        else if (IsCloud)
            DrawCloudy(canvas, rect);
        else
            DrawSunny(canvas, rect);

        canvas.RestoreState();
    }

    private static void OnVisualPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is WeatherBadgeView view)
            view.Invalidate();
    }

    private void Start()
    {
        if (_isRunning)
            return;

        _isRunning = true;

        Dispatcher.StartTimer(TimeSpan.FromMilliseconds(33), () =>
        {
            if (!_isRunning)
                return false;

            _phase += 0.018f;
            Invalidate();
            return true;
        });
    }

    private void DrawGlassOrb(ICanvas canvas, RectF rect)
    {
        canvas.FillColor = Colors.White.WithAlpha(0.10f);
        canvas.FillEllipse(rect);

        canvas.FillColor = AccentColor.WithAlpha(0.16f);
        canvas.FillEllipse(rect.Inflate(-rect.Width * 0.08f, -rect.Height * 0.08f));

        canvas.StrokeSize = Math.Max(1.2f, rect.Width * 0.015f);
        canvas.StrokeColor = Colors.White.WithAlpha(0.42f);
        canvas.DrawEllipse(rect.Inflate(-1.5f, -1.5f));

        canvas.StrokeColor = Colors.White.WithAlpha(0.20f);
        canvas.DrawArc(
            rect.X + rect.Width * 0.16f,
            rect.Y + rect.Height * 0.12f,
            rect.Width * 0.68f,
            rect.Height * 0.68f,
            205,
            314,
            false,
            false);
    }

    private void DrawSunny(ICanvas canvas, RectF rect)
    {
        float cx = rect.Center.X;
        float cy = rect.Center.Y;
        float pulse = 1f + MathF.Sin(_phase * 2.2f) * 0.035f;
        float radius = rect.Width * 0.2f * pulse;

        canvas.StrokeColor = Color.FromArgb("#FDE68A").WithAlpha(0.78f);
        canvas.StrokeSize = rect.Width * 0.035f;

        for (int i = 0; i < 10; i++)
        {
            float angle = (MathF.PI * 2f / 10f) * i + _phase * 0.28f;
            float start = rect.Width * 0.3f;
            float end = rect.Width * 0.41f;
            canvas.DrawLine(
                cx + MathF.Cos(angle) * start,
                cy + MathF.Sin(angle) * start,
                cx + MathF.Cos(angle) * end,
                cy + MathF.Sin(angle) * end);
        }

        canvas.FillColor = Color.FromArgb("#FBBF24");
        canvas.FillCircle(cx, cy, radius);
        canvas.FillColor = Colors.White.WithAlpha(0.26f);
        canvas.FillCircle(cx - radius * 0.28f, cy - radius * 0.35f, radius * 0.36f);
    }

    private void DrawCloudy(ICanvas canvas, RectF rect)
    {
        float drift = MathF.Sin(_phase * 1.5f) * rect.Width * 0.025f;
        DrawSunBehindCloud(canvas, rect, drift);
        DrawCloud(canvas, rect, rect.Width * 0.15f + drift, rect.Height * 0.45f, rect.Width * 0.68f, Colors.White.WithAlpha(0.82f));
    }

    private void DrawRain(ICanvas canvas, RectF rect)
    {
        DrawCloud(canvas, rect, rect.Width * 0.13f, rect.Height * 0.34f, rect.Width * 0.72f, Color.FromArgb("#D8EEFF").WithAlpha(0.82f));

        canvas.StrokeColor = Color.FromArgb("#7DD3FC").WithAlpha(0.9f);
        canvas.StrokeSize = rect.Width * 0.035f;

        for (int i = 0; i < 4; i++)
        {
            float x = rect.X + rect.Width * (0.26f + i * 0.14f);
            float y = rect.Y + rect.Height * (0.65f + ((i % 2) * 0.05f));
            float offset = (_phase * 34f + i * 7f) % 12f;
            canvas.DrawLine(x, y + offset, x - rect.Width * 0.06f, y + rect.Height * 0.16f + offset);
        }
    }

    private void DrawSnow(ICanvas canvas, RectF rect)
    {
        DrawCloud(canvas, rect, rect.Width * 0.13f, rect.Height * 0.32f, rect.Width * 0.72f, Colors.White.WithAlpha(0.86f));

        canvas.FillColor = Colors.White.WithAlpha(0.92f);

        for (int i = 0; i < 5; i++)
        {
            float sway = MathF.Sin(_phase * 2.4f + i) * rect.Width * 0.025f;
            float x = rect.X + rect.Width * (0.24f + i * 0.12f) + sway;
            float y = rect.Y + rect.Height * (0.66f + (i % 2) * 0.08f);
            canvas.FillCircle(x, y, rect.Width * 0.025f);
        }
    }

    private void DrawFog(ICanvas canvas, RectF rect)
    {
        DrawCloud(canvas, rect, rect.Width * 0.14f, rect.Height * 0.30f, rect.Width * 0.7f, Colors.White.WithAlpha(0.66f));

        canvas.StrokeColor = Colors.White.WithAlpha(0.58f);
        canvas.StrokeSize = rect.Width * 0.035f;
        canvas.StrokeLineCap = LineCap.Round;

        for (int i = 0; i < 3; i++)
        {
            float y = rect.Y + rect.Height * (0.62f + i * 0.1f);
            float x = rect.X + rect.Width * (0.2f + (i % 2) * 0.08f);
            canvas.DrawLine(x, y, x + rect.Width * 0.58f, y);
        }
    }

    private void DrawStorm(ICanvas canvas, RectF rect)
    {
        DrawCloud(canvas, rect, rect.Width * 0.12f, rect.Height * 0.32f, rect.Width * 0.74f, Color.FromArgb("#CBD5E1").WithAlpha(0.76f));

        canvas.FillColor = Color.FromArgb("#FDE68A");
        var path = new PathF();
        path.MoveTo(rect.X + rect.Width * 0.5f, rect.Y + rect.Height * 0.56f);
        path.LineTo(rect.X + rect.Width * 0.38f, rect.Y + rect.Height * 0.78f);
        path.LineTo(rect.X + rect.Width * 0.52f, rect.Y + rect.Height * 0.74f);
        path.LineTo(rect.X + rect.Width * 0.43f, rect.Y + rect.Height * 0.94f);
        path.LineTo(rect.X + rect.Width * 0.68f, rect.Y + rect.Height * 0.66f);
        path.LineTo(rect.X + rect.Width * 0.54f, rect.Y + rect.Height * 0.69f);
        path.Close();
        canvas.FillPath(path);
    }

    private void DrawSunBehindCloud(ICanvas canvas, RectF rect, float drift)
    {
        canvas.FillColor = Color.FromArgb("#FBBF24").WithAlpha(0.84f);
        canvas.FillCircle(rect.X + rect.Width * 0.36f + drift, rect.Y + rect.Height * 0.38f, rect.Width * 0.18f);
    }

    private static void DrawCloud(ICanvas canvas, RectF rect, float x, float y, float width, Color color)
    {
        float left = rect.X + x;
        float top = rect.Y + y;
        float height = width * 0.42f;

        canvas.FillColor = color;
        canvas.FillRoundedRectangle(left + width * 0.05f, top + height * 0.35f, width * 0.88f, height * 0.5f, height * 0.25f);
        canvas.FillCircle(left + width * 0.28f, top + height * 0.43f, width * 0.2f);
        canvas.FillCircle(left + width * 0.48f, top + height * 0.28f, width * 0.26f);
        canvas.FillCircle(left + width * 0.68f, top + height * 0.46f, width * 0.19f);

        canvas.FillColor = Colors.White.WithAlpha(0.18f);
        canvas.FillCircle(left + width * 0.37f, top + height * 0.23f, width * 0.08f);
    }

    private bool IsRain => WeatherCode is 51 or 53 or 55 or 61 or 63 or 65 or 66 or 67 or 80 or 81 or 82;
    private bool IsSnow => WeatherCode is 71 or 73 or 75 or 77 or 85 or 86;
    private bool IsFog => WeatherCode is 45 or 48;
    private bool IsStorm => WeatherCode is 95 or 96 or 99;
    private bool IsCloud => WeatherCode is 2 or 3;
}
