﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppCocacolaNayMobiV2.Models;
using AppCocacolaNayMobiV2.ViewModels;
using AppCocacolaNayMobiV2.Models.Menu;

namespace AppCocacolaNayMobiV2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}