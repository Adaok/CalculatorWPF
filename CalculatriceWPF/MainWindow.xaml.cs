using System;
using System.Windows;
using System.Windows.Controls;

namespace CalculatriceWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string valueDisplay1;
        private float valueResult = 0;
        private float lastValue;
        private string lastOperator;
        private string mOperation;

        public MainWindow()
        {
            InitializeComponent();
            LineDetails.Text = string.Empty;
            LineValue.Text = string.Empty;
        }

        private void btn_click_Value(object sender, RoutedEventArgs e)
        {
            if(valueDisplay1 == string.Empty) //never click on a number or click on equals
            {
                //TODO save previous operation.
                mOperation = string.Empty;
                valueResult = 0;
                lastValue = 0;
                lastOperator = string.Empty;
                LineDetails.Text = string.Empty;
                valueDisplay1 = (String)((Button)sender).Content;
            }
            else if (valueDisplay1 == "operatorPressedBefore")//previous click on a operator : + - * /
            {
                LineValue.Text = string.Empty;
                valueDisplay1 = (String)((Button)sender).Content;
            }
            else //other previous click case, dot inclused
            {
                valueDisplay1 = valueDisplay1 + (String)((Button)sender).Content;
            }

            LineValue.Text = valueDisplay1;
        }

        private void btn_click_Operator(object sender, RoutedEventArgs e)
        {
            //we catch the string value of the operator button pressed
            string mOperator = (String)((Button)sender).Content;

            // if the button pressed is .
            if (mOperator == ".")
            {
                valueDisplay1 = valueDisplay1 + ".";
                LineValue.Text = valueDisplay1;
                return;
            }
            //if button pressed is =
            else if (mOperator == "=")
            {
                //TODO
                lastValue = float.Parse(valueDisplay1);

                switch (lastOperator)
                {
                    case "+":
                        valueResult = valueResult + lastValue;
                        break;

                    case "-":
                        valueResult = valueResult - lastValue;
                        break;

                    case "X":
                        valueResult = valueResult * lastValue;
                        break;

                    case "/":
                        valueResult = valueResult / lastValue;
                        break;
                }

                mOperation = mOperation + valueDisplay1 + mOperator;
                LineDetails.Text = mOperation;
                LineValue.Text = valueResult.ToString();
                valueDisplay1 = string.Empty;

                return;
            }
            //if operator is + or - or * or /
            else
            {
                if(valueDisplay1 == "operatorPressedBefore")
                {
                    return;
                }

                lastValue = float.Parse(valueDisplay1);

                //if is the first operator clicked
                if (valueResult == 0)
                {
                    valueResult = lastValue;
                    mOperation = mOperation + valueDisplay1 + mOperator;
                    valueDisplay1 = "operatorPressedBefore";
                    lastOperator = mOperator;
                }
                else
                {
                    switch (lastOperator)
                    {
                        case "+":
                            valueResult = valueResult + lastValue;
                            break;

                        case "-":
                            valueResult = valueResult - lastValue;
                            break;

                        case "X":
                            valueResult = valueResult * lastValue;
                            break;

                        case "/":
                            valueResult = valueResult / lastValue;
                            break;
                    }

                    mOperation = mOperation + valueDisplay1 + mOperator;
                    valueDisplay1 = "operatorPressedBefore";
                    lastOperator = mOperator;
                }

                LineDetails.Text = mOperation;
            }
        }

        private void btn_click_CE(object sender, RoutedEventArgs e)
        {
            valueDisplay1 = string.Empty;
            LineValue.Text = string.Empty;
        }

        private void btn_click_C(object sender, RoutedEventArgs e)
        {
            mOperation = string.Empty;
            valueDisplay1 = string.Empty;
            valueResult = 0;
            lastValue = 0;
            lastOperator = string.Empty;
            LineDetails.Text = string.Empty;
            LineValue.Text = string.Empty;
        }

        private void btn_click_back(object sender, RoutedEventArgs e)
        {

        }
    }
}
