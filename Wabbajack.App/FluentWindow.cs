using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Platform;
using Avalonia.Styling;

namespace Wabbajack.App;

public class FluentWindow : Window, IStyleable
{
    public FluentWindow()
    {
        ExtendClientAreaToDecorationsHint = true;
        ExtendClientAreaTitleBarHeightHint = -1;

        TransparencyLevelHint = WindowTransparencyLevel.AcrylicBlur;

        this.GetObservable(WindowStateProperty)
            .Subscribe(x =>
            {
                PseudoClasses.Set(":maximized", x == WindowState.Maximized);
                PseudoClasses.Set(":fullscreen", x == WindowState.FullScreen);
            });

        this.GetObservable(IsExtendedIntoWindowDecorationsProperty)
            .Subscribe(x =>
            {
                if (!x)
                {
                    SystemDecorations = SystemDecorations.Full;
                    TransparencyLevelHint = WindowTransparencyLevel.Blur;
                }
            });
    }

    Type IStyleable.StyleKey => typeof(Window);

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        ExtendClientAreaChromeHints =
            ExtendClientAreaChromeHints.PreferSystemChrome |
            ExtendClientAreaChromeHints.OSXThickTitleBar;
    }
}