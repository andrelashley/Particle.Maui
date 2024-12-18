using Particle.Maui.ParticleSystem;
using SkiaSharp.Extended.UI.Controls;

namespace Particle.Maui.Pages;

public partial class ConfettiPage : ContentPage
{
    private string configName = "Top";

    public ConfettiPage()
    {
        InitializeComponent();

        Configs = new Dictionary<string, ConfettiConfig>
        {
            ["Top"] = new ConfettiConfig
            {
                Duration = 150,
            },
            ["Center"] = new ConfettiConfig
            {
                MinSpeed = 30,
                MaxSpeed = 150,
                Duration = 0,
                OnCreateSystem = (i, system) =>
                {
                    system.Emitter = SKConfettiEmitter.Burst(100);
                    system.EmitterBounds = SKConfettiEmitterBounds.Center;
                }
            },
            ["Sides"] = new ConfettiConfig(2)
            {
                MinSpeed = 50,
                MaxSpeed = 400,
                Duration = 0,
                OnCreateSystem = (i, system) =>
                {
                    system.Emitter = SKConfettiEmitter.Burst(100);
                    if (i % 2 == 0)
                    {
                        system.EmitterBounds = SKConfettiEmitterBounds.Point(0, Height);
                        system.StartAngle = -85;
                        system.EndAngle = -35;
                    }
                    else
                    {
                        system.EmitterBounds = SKConfettiEmitterBounds.Point(Width, Height);
                        system.StartAngle = 265;
                        system.EndAngle = 215;
                    }
                }
            },
        };

        BindingContext = this;

        StartConfetti();
    }

    public string ConfigName
    {
        get => configName;
        set
        {
            configName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CurrentConfig));
        }
    }

    public Dictionary<string, ConfettiConfig> Configs { get; }

    public ConfettiConfig CurrentConfig => Configs[ConfigName];

    private void StartConfetti()
    {
        foreach (var system in CurrentConfig.CreateSystems())
            confettiView.Systems!.Add(system);
    }
}