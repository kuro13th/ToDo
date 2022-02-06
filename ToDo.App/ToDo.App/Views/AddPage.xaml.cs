﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToDo.App.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.App.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage {
        public AddPage() {
            InitializeComponent();
        }

        private async void guardarBtn_Clicked(object sender, EventArgs e) {
            try {
                var item = new ToDoItem {
                    Name = nombreEntry.Text,
                    Description = descripcionEntry.Text,
                    DateTime = registerDate.Date + registerTime.Time
                };
                var result = await App.Context.InsertItemAsync(item);

                if (result == 1) {
                    await Navigation.PopAsync();
                } else {
                    await DisplayAlert("Error", "Hubo un error al guardar la tarea", "Aceptar");
                }
            } catch (Exception ex) {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}