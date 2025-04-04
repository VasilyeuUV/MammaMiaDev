using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using MammaMiaDev.Helpers;

namespace MammaMiaDev.ViewModels;

public partial class ImagePageViewModel : ViewModelBase
{
    /// <summary>
    /// Binding через Конвертер привязки (Binding converter)
    /// </summary>
    public string ImageSourceString
        => "/Assets/Images/img2.jpeg";

    /// <summary>
    /// 
    /// </summary>
    public Bitmap ImageSourceBitmapLocal
        => ImageHelper.LoadFromResource("/Assets/Images/bird.jpg");


    public Task<Bitmap?> ImageSourceBitmapWeb
        => ImageHelper.LoadFromWeb("https://uni-eng.ru/upload/resize_cache/iblock/033/360_360_1/Retrofit.png");
}
