using ZXing.Net.Maui;
namespace RSA.Presentation

{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private Task<string> task;

        public MainPage()
        {
            InitializeComponent();
            barcodeReader.Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormat.Code128
            };
        }

        private void barcodeReader_BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
        {
            var cod= e.Results?.FirstOrDefault();

            if (cod is null)
                return;
            Dispatcher.DispatchAsync(async () =>
            {
                await DisplayAlertAsync("Barcode detected", cod.Value, "ok");
                await DisplayPromptAsync("Quantidade", "Digite a quantidade:");

            });
        }
    }
}
