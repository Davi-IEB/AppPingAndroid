using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace AppPingAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalhes : ContentPage
    {
        ZXingBarcodeImageView barcode;
        public Detalhes()
        {
            InitializeComponent();
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;            
            barcode.BarcodeOptions.Width = 200;
            barcode.BarcodeOptions.Height = 200;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = "123456789";

            //stlQRCode.Children.Add(barcode);
            Content = barcode;
            
           
            
        }
    }
}