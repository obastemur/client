﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OpenT2T.Test
{
    public class TestLogView : ScrollView
    {
        StackLayout stackLayout;

        public TestLogView()
        {
            this.stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 0,
                Padding = new Thickness(8),
                VerticalOptions = LayoutOptions.Start,
            };
            this.Content = this.stackLayout;
        }

        public void AppendLine(string text)
        {
            this.AppendLine(text, Color.Black, false);
        }

        public void AppendLine(string text, Color textColor, bool important)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                Label line = new Label
                {
                    FontSize = (important ? 14 : 12),
                    FontAttributes = (important ? FontAttributes.Bold : FontAttributes.None),
                    TextColor = textColor,
                    Text = text,
                };
                this.stackLayout.Children.Add(line);
                await Task.Yield();

                // Why doesn't this work??
                await this.ScrollToAsync(this.stackLayout, ScrollToPosition.End, false);
            });
        }


        public void Clear()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.stackLayout.Children.Clear();
            });
        }
    }
}

