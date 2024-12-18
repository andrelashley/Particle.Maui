using SkiaSharp.Extended.UI.Controls;
using SkiaSharp.Extended;
using SkiaSharp;

namespace Particle.Maui.ParticleSystem
{
    public class ConfettiStar : SKConfettiShape
    {
        public ConfettiStar(int points)
        {
            Points = points;
        }

        public int Points { get; }

        protected override void OnDraw(SKCanvas canvas, SKPaint paint, float size)
        {
            using var star = SKGeometry.CreateRegularStarPath(size, size / 2, Points);

            canvas.DrawPath(star, paint);
        }
    }
}
