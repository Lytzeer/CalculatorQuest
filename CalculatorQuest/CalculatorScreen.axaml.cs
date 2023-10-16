using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.OpenGL.Egl;

namespace CalculatorQuest;

public partial class CalculatorScreen : Window
{
    public CalculatorScreen()
    {
        this.Width = 300;
        this.Height = 600;
        InitializeComponent(); 
    }

    private void displayValue(object? sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        string s = button.Content.ToString();
        Console.WriteLine(s);
        this.Result.Content = s;
        this.Operation.Content += s;
    }

    private void Equal(object? sender, RoutedEventArgs e)
    {
        this.Result.Content=Calc.Operator(this.Operation.Content.ToString());
        this.Operation.Content = this.Result.Content;
    }

    private void Sign(object? sender, RoutedEventArgs e)
    {
        if (this.Operation.Content.ToString()[0].ToString() != "-")
        {
            this.Result.Content = "-" + this.Operation.Content;
            this.Operation.Content = this.Result.Content;
        }
        else
        {
            this.Result.Content = this.Operation.Content.ToString()[1..];
            this.Operation.Content = this.Result.Content;
        }
    }

    private void C(object? sender, RoutedEventArgs e)
    {
        this.Result.Content = "0";
        this.Operation.Content = "";
    }
    private void Del(object? sender, RoutedEventArgs e)
    {
        if (this.Result.Content.ToString().Length != 0)
        {
            this.Result.Content = this.Result.Content.ToString()
                .Substring(0, this.Result.Content.ToString().Length - 1);
            
        }
    }

    private void Ce(object? sender, RoutedEventArgs e)
    {
        this.Result.Content = "";
    }

    private void Square(object? sender, RoutedEventArgs e)
    {
        this.Result.Content = Calc.Square(this.Operation.Content.ToString());
        this.Operation.Content = this.Result.Content;
    }
    
    private void Sqrt(object? sender, RoutedEventArgs e)
    {
        this.Result.Content = Calc.Sqrt(this.Operation.Content.ToString());
        this.Operation.Content = this.Result.Content;
    }
    
    private void Invert(object? sender, RoutedEventArgs e)
    {
        this.Result.Content = Calc.Invert(this.Operation.Content.ToString());
        this.Operation.Content = this.Result.Content;
    }
}