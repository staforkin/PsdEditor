using Aspose.PSD;
using Aspose.PSD.FileFormats.Png;
using Aspose.PSD.FileFormats.Psd;
using Aspose.PSD.FileFormats.Psd.Layers;
using Aspose.PSD.ImageLoadOptions;
using Aspose.PSD.ImageOptions;

internal class Program
{
    private static void Main(string[] args)
    {
        var license = new License();
        license.SetLicense(@".lic");
        // If you want to use Blending Effects, please specify the following options:
        var options = new PsdLoadOptions() { LoadEffectsResource = true };
        using (var img = (PsdImage)Image.Load("color-theme.psd", options))
        {
            foreach (var layer in img.Layers)
            {
                if (layer is TextLayer)
                {
                    try
                    {
                        TextLayer textLayer = layer as TextLayer;
                        textLayer.UpdateText("666");
                    }
                    catch (System.ComponentModel.LicenseException licenseEx)
                    {
                        Console.WriteLine("licence exception");
                    }

                }
            }

            img.Save("Output.psd");
            img.Save("Output.png", new PngOptions() { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}