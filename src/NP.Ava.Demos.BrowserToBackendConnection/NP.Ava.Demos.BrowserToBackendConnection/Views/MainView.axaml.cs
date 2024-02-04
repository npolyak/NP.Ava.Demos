using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NP.Ava.Demos.BrowserToBackendConnection.Views;

public partial class MainView : UserControl
{
    readonly HttpClient client = new HttpClient();
    public MainView()
    {
        InitializeComponent();

        System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

       // client.BaseAddress = new System.Uri("https://localhost:5185/");

        GetStringFromBackendButton.Click += GetStringFromBackendButton_Click;

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    private async void 
        GetStringFromBackendButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            using HttpResponseMessage response =
                await client.GetAsync("https://localhost:7168/api/HelloWorld/Hello");

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
        }
        catch(Exception ex)
        {

        }
    }
}
