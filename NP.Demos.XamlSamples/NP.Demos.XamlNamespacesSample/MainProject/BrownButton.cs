﻿using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace NP.Demos.XamlNamespacesSample
{
    public class BrownButton : Button, IStyleable
    {
        Type IStyleable.StyleKey => typeof(Button);

        public BrownButton()
        {
            Background = new SolidColorBrush(Colors.Brown);
            Width = 30;
            Height = 30;
        }
    }
}