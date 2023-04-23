﻿namespace DotNetAnnuaireApp.View;

public partial class MainPage : ContentPage
{
    SalariesViewModel viewModel;

    public MainPage(SalariesViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

}