using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Nexus.App.Commons
{
    public class FilesCommons
    {

        public void ImageCompact(string caminhoDaImagemOriginal, string caminhoDaImagemCompactada, long qualidade)
        {
            using (var imagemOriginal = new Bitmap(caminhoDaImagemOriginal))
            {
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualidade);

                var codecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(encoder => encoder.FormatID == ImageFormat.Jpeg.Guid);

                if (codecInfo != null)
                {
                    imagemOriginal.Save(caminhoDaImagemCompactada, codecInfo, encoderParameters);
                }
            }
        }

        public static void ZipTextFile(string originFile, string destinationFile)
            {
                using (var inputFile = new FileStream(originFile, FileMode.Open))
                using (var outuputFile = new FileStream(destinationFile, FileMode.Create))
                using (var gzipStream = new GZipStream(outuputFile, CompressionMode.Compress))
                {
                    inputFile.CopyTo(gzipStream);
                }
            }

        public static void UnzipTextFile(string arquivoCompactado, string arquivoDestino)
        {
            using (var arquivoEntrada = new FileStream(arquivoCompactado, FileMode.Open))
            using (var arquivoSaida = new FileStream(arquivoDestino, FileMode.Create))
            using (var gzipStream = new GZipStream(arquivoEntrada, CompressionMode.Decompress))
            {
                gzipStream.CopyTo(arquivoSaida);
            }
        }

    }
}

