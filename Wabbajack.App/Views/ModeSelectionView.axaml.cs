using System;
using System.Reactive.Disposables;
using ReactiveUI;
using Wabbajack.App.Messages;
using Wabbajack.App.Screens;
using Wabbajack.App.ViewModels;

namespace Wabbajack.App.Views;

public partial class ModeSelectionView : ScreenBase<ModeSelectionViewModel>
{
    public ModeSelectionView(IServiceProvider provider) : base("")
    {
        InitializeComponent();
        this.WhenActivated(disposables =>
        {
            InstallButton.Button.Command = ReactiveCommand.Create(() =>
            {
                MessageBus.Current.SendMessage(new NavigateTo(typeof(InstallConfigurationViewModel)));
            }).DisposeWith(disposables);

            BrowseButton.Button.Command = ReactiveCommand.Create(() =>
            {
                MessageBus.Current.SendMessage(new NavigateTo(typeof(BrowseViewModel)));
            }).DisposeWith(disposables);

            CompileButton.Button.Command = ReactiveCommand.Create(() =>
            {
                MessageBus.Current.SendMessage(new NavigateTo(typeof(CompilerConfigurationViewModel)));
            }).DisposeWith(disposables);

            LaunchButton.Button.Command = ReactiveCommand.Create(() =>
            {
                MessageBus.Current.SendMessage(new NavigateTo(typeof(PlaySelectViewModel)));
            });
        });
    }
}