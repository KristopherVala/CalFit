using MobileFitnessCalorieTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileFitnessCalorieTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        ProfileModel loggedInUser;

        public Profile(ProfileModel passedUser)
        {
            InitializeComponent();

            loggedInUser = passedUser;

            BindingContext = loggedInUser;

        }


        async private void BackButton(object sender, EventArgs e)
        {

            await Navigation.PopAsync(true);


        }

    }
}