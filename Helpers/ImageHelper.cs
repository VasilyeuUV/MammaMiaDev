using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace MammaMiaDev.Helpers;

public static class ImageHelper
{
    public static Bitmap LoadFromResource(string resourcePath)
    {
        Uri resourceUri;

        if (!resourcePath.StartsWith("avares://"))
        {
            var assemblyName = Assembly.GetEntryAssembly()?.GetName().Name;
            resourceUri = new Uri($"avares://{assemblyName}/{resourcePath.TrimStart('/')}");
        }
        else
        {
            resourceUri = new Uri(resourcePath);
        }
        return new Bitmap(AssetLoader.Open(resourceUri));
    }


    public static async Task<Bitmap?> LoadFromWeb(string resourcePath)
    {
        Uri uri = new(resourcePath);
        using HttpClient httpClient = new();
        try
        {
            httpClient.DefaultRequestHeaders.UserAgent
                .Add(new System.Net.Http.Headers.ProductInfoHeaderValue("MammaMiaDev", "0.1"));
            var data = await httpClient.GetByteArrayAsync(uri);
            return new Bitmap(new MemoryStream(data));
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
