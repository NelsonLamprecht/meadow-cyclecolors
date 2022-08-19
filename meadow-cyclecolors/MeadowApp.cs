using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Leds;

namespace Meadow_CycleColors
{
    // Change F7FeatherV2 to F7FeatherV1 for V1.x boards
    [SuppressMessage("ReSharper", "FunctionNeverReturns")]
    public class MeadowApp : App<F7FeatherV1, MeadowApp>
    {
        private RgbPwmLed _onboardLed;

        public MeadowApp()
        {
            Initialize();
            CycleColors(TimeSpan.FromMilliseconds(500));
        }

        void Initialize()
        {
            Console.WriteLine("Initialize hardware...");

            _onboardLed = new RgbPwmLed(device: Device,
                redPwmPin: Device.Pins.OnboardLedRed,
                greenPwmPin: Device.Pins.OnboardLedGreen,
                bluePwmPin: Device.Pins.OnboardLedBlue,
                Meadow.Peripherals.Leds.IRgbLed.CommonType.CommonAnode);
        }

        void CycleColors(TimeSpan duration)
        {
            Console.WriteLine("Cycle colors...");

            while (true)
            {
                ShowColorPulse(Color.Blue, duration);
                ShowColorPulse(Color.Cyan, duration);
                ShowColorPulse(Color.Green, duration);
                ShowColorPulse(Color.GreenYellow, duration);
                ShowColorPulse(Color.Yellow, duration);
                ShowColorPulse(Color.Orange, duration);
                ShowColorPulse(Color.OrangeRed, duration);
                ShowColorPulse(Color.Red, duration);
                ShowColorPulse(Color.MediumVioletRed, duration);
                ShowColorPulse(Color.Purple, duration);
                ShowColorPulse(Color.Magenta, duration);
                ShowColorPulse(Color.Pink, duration);
            }
        }

        void ShowColorPulse(Color color, TimeSpan duration)
        {
            _onboardLed.StartPulse(color, duration / 2);
            Thread.Sleep(duration);
            _onboardLed.Stop();
        }

        void ShowColor(Color color, TimeSpan duration)
        {
            Console.WriteLine($"Color: {color}");
            _onboardLed.SetColor(color);
            Thread.Sleep(duration);
            _onboardLed.Stop();
        }
    }
}
