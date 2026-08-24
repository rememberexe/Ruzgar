using Microsoft.Maui.Graphics;

namespace Ruzgar.Controls;

public class AtmosphereView : GraphicsView, IDrawable
{
    public static readonly BindableProperty WeatherCodeProperty =
        BindableProperty.Create(
            nameof(WeatherCode),
            typeof(int),
            typeof(AtmosphereView),
            0,
            propertyChanged: OnVisualPropertyChanged);

    public static readonly BindableProperty AccentColorProperty =
        BindableProperty.Create(
            nameof(AccentColor),
            typeof(Color),
            typeof(AtmosphereView),
            Colors.SkyBlue,
            propertyChanged: OnVisualPropertyChanged);

    private readonly Random _random = new(73);
    private readonly List<Particle> _particles = new();
    private bool _isRunning;
    private float _phase;
    private int _lastWeatherCode = -1;

    public AtmosphereView()
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
        EnsureParticles();

        canvas.SaveState();
        canvas.Alpha = 0.42f;

        DrawAmbientGlow(canvas, dirtyRect);

        if (IsRain)
            DrawRain(canvas, dirtyRect);
        else if (IsSnow)
            DrawSnow(canvas, dirtyRect);
        else if (IsFog)
            DrawFog(canvas, dirtyRect);
        else if (IsStorm)
            DrawStorm(canvas, dirtyRect);
        else
            DrawWind(canvas, dirtyRect);

        canvas.RestoreState();
    }

    private static void OnVisualPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is AtmosphereView view)
        {
            view._particles.Clear();
            view.Invalidate();
        }
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

            _phase += 0.016f;
            Invalidate();
            return true;
        });
    }

    private void EnsureParticles()
    {
        if (_lastWeatherCode == WeatherCode && _particles.Count > 0)
            return;

        _lastWeatherCode = WeatherCode;
        _particles.Clear();

        int count = IsRain ? 38 : IsSnow ? 30 : IsFog ? 10 : 18;

        for (int i = 0; i < count; i++)
        {
            _particles.Add(new Particle(
                (float)_random.NextDouble(),
                (float)_random.NextDouble(),
                0.35f + (float)_random.NextDouble() * 1.25f,
                0.35f + (float)_random.NextDouble() * 0.65f));
        }
    }

    private void DrawAmbientGlow(ICanvas canvas, RectF rect)
    {
        canvas.FillColor = AccentColor.WithAlpha(IsStorm ? 0.18f : 0.12f);
        canvas.FillEllipse(rect.Width * 0.58f, -rect.Height * 0.08f, rect.Width * 0.58f, rect.Width * 0.58f);

        canvas.FillColor = Colors.White.WithAlpha(IsSnow ? 0.12f : 0.06f);
        canvas.FillEllipse(-rect.Width * 0.18f, rect.Height * 0.1f, rect.Width * 0.54f, rect.Width * 0.54f);
    }

    private void DrawWind(ICanvas canvas, RectF rect)
    {
        canvas.StrokeColor = Colors.White.WithAlpha(IsCloud ? 0.18f : 0.12f);
        canvas.StrokeSize = 1.4f;

        foreach (var particle in _particles)
        {
            float x = Wrap((particle.X + _phase * 0.08f * particle.Speed) * rect.Width, rect.Width + 160) - 80;
            float y = particle.Y * rect.Height;
            float length = 42 + particle.Depth * 36;

            canvas.DrawLine(x, y, x + length, y - 10);
        }
    }

    private void DrawRain(ICanvas canvas, RectF rect)
    {
        canvas.StrokeColor = Color.FromArgb("#BFE7FF").WithAlpha(0.34f);
        canvas.StrokeSize = 1.6f;

        foreach (var particle in _particles)
        {
            float x = particle.X * rect.Width;
            float y = Wrap((particle.Y + _phase * 0.85f * particle.Speed) * rect.Height, rect.Height + 90) - 45;

            canvas.DrawLine(x, y, x + 14, y + 48);
        }
    }

    private void DrawSnow(ICanvas canvas, RectF rect)
    {
        canvas.FillColor = Colors.White.WithAlpha(0.42f);

        foreach (var particle in _particles)
        {
            float sway = MathF.Sin((_phase * 2.3f) + particle.Depth * 8f) * 18f;
            float x = particle.X * rect.Width + sway;
            float y = Wrap((particle.Y + _phase * 0.18f * particle.Speed) * rect.Height, rect.Height + 30) - 15;
            float size = 2.2f + particle.Depth * 3.2f;

            canvas.FillCircle(x, y, size);
        }
    }

    private void DrawFog(ICanvas canvas, RectF rect)
    {
        canvas.StrokeColor = Colors.White.WithAlpha(0.12f);
        canvas.StrokeSize = 14f;

        foreach (var particle in _particles)
        {
            float y = rect.Height * (0.18f + particle.Y * 0.64f);
            float x = Wrap((particle.X + _phase * 0.025f * particle.Speed) * rect.Width, rect.Width + 260) - 130;
            canvas.DrawLine(x, y, x + 210 + particle.Depth * 80, y);
        }
    }

    private void DrawStorm(ICanvas canvas, RectF rect)
    {
        DrawRain(canvas, rect);

        float pulse = 0.12f + MathF.Max(0, MathF.Sin(_phase * 4.8f)) * 0.2f;
        canvas.StrokeColor = Color.FromArgb("#FDE68A").WithAlpha(pulse);
        canvas.StrokeSize = 3f;

        var cx = rect.Width * 0.76f;
        var cy = rect.Height * 0.18f;
        canvas.DrawLine(cx, cy, cx - 22, cy + 44);
        canvas.DrawLine(cx - 22, cy + 44, cx + 4, cy + 38);
        canvas.DrawLine(cx + 4, cy + 38, cx - 28, cy + 92);
    }

    private bool IsRain => WeatherCode is 51 or 53 or 55 or 61 or 63 or 65 or 66 or 67 or 80 or 81 or 82;
    private bool IsSnow => WeatherCode is 71 or 73 or 75 or 77 or 85 or 86;
    private bool IsFog => WeatherCode is 45 or 48;
    private bool IsStorm => WeatherCode is 95 or 96 or 99;
    private bool IsCloud => WeatherCode is 2 or 3;

    private static float Wrap(float value, float max)
    {
        value %= max;
        return value < 0 ? value + max : value;
    }

    private readonly record struct Particle(float X, float Y, float Speed, float Depth);
}
