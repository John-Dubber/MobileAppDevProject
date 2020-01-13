using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DartsAppFixed
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        int _Modifier = 1;
        int _NoOfSets = 1;
        int _RemainingThrows = 3;
        int _SetScore = 0;
        int _LastScoreP1 = 0;
        int _LastScoreP2 = 0;
        int _CurrentScoreP1 = 0;
        int _CurrentScoreP2 = 0;
        int _CurrentPlayer = 0;
        public MainPage()
        {
            InitializeComponent();
            _CurrentScoreP1 = int.Parse(StartingScore.Text);
            _CurrentScoreP2 = int.Parse(StartingScore2.Text);

        }

        private void BtnOuter_Clicked(object sender, EventArgs e)
        {
            SubmitThrow(25);
        }

        private void BtnMiss_Clicked(object sender, EventArgs e)
        {
            SubmitThrow(0);
        }

        private void BtnBull_Clicked(object sender, EventArgs e)
        {
            SubmitThrow(50);
        }

        private void BtnTriple_Clicked(object sender, EventArgs e)
        {
            ActiveModifier(BtnTriple);
            _Modifier = 3;
        }

        private void BtnDouble_Clicked(object sender, EventArgs e)
        {
            ActiveModifier(BtnDouble);
            _Modifier = 2;
        }

        private void BtnSingle_Clicked(object sender, EventArgs e)
        {
            ActiveModifier(BtnSingle);
            _Modifier = 1;
        }


        private void ActiveModifier(Button button)
        {
            BtnTriple.BackgroundColor = Color.LightGray;
            BtnDouble.BackgroundColor = Color.LightGray;
            BtnSingle.BackgroundColor = Color.LightGray;
            button.BackgroundColor = Color.Blue;
        }

        private void BtnThrow_Clicked(object sender, EventArgs e)
        {
            if (EntryThrow.Text.Equals(null))
            {
                DisplayAlert("No Number Entered",
                                "Please Throw a number 1-20 or use the buttons provided", "OK");
                return;
            }
            int score;
            score = int.Parse(EntryThrow.Text);
            score *= _Modifier;
            SubmitThrow(score);
        }

        private void SubmitThrow(int score)
        {
            //add the throw to current set of throws
            _SetScore += score;
            _RemainingThrows--;
            //every three throws take the score away from the last score

            if (_RemainingThrows == 0)
            {
                if (_CurrentPlayer == 0)
                {

                    _LastScoreP1 = _CurrentScoreP1;
                    _CurrentScoreP1 -= _SetScore;
                    _RemainingThrows = 3;
                    _CurrentPlayer = 1;
                    Label l = new Label();
                    l.Text = _CurrentScoreP1.ToString();
                    l.TextColor = Color.Blue;
                    l.VerticalOptions = LayoutOptions.Center;
                    l.HorizontalOptions = LayoutOptions.Center;
                    l.SetValue(Grid.RowProperty, _NoOfSets);
                    l.SetValue(Grid.ColumnProperty, _CurrentPlayer);
                    GrdPlayer1.Children.Add(l);
                    _SetScore = 0;
                }
                else
                {
                    _LastScoreP2 = _CurrentScoreP2;
                    _CurrentScoreP2 -= _SetScore;
                    _RemainingThrows = 3;
                    _CurrentPlayer = 0;
                    Label l = new Label();
                    l.Text = _CurrentScoreP2.ToString();
                    l.TextColor = Color.Blue;
                    l.VerticalOptions = LayoutOptions.Center;
                    l.HorizontalOptions = LayoutOptions.Center;
                    l.SetValue(Grid.RowProperty, _NoOfSets);
                    l.SetValue(Grid.ColumnProperty, _CurrentPlayer);
                    GrdPlayer2.Children.Add(l);
                    _SetScore = 0;
                    _NoOfSets++;
                }
            }




            //store all previous sets of throws as an array
        }


    }
}
