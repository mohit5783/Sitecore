using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public RescaledImageProperties ThumbnailProps { get; set; }
        public RescaledImageProperties PreviewProps { get; set; }

        public string publicURL = "http://wallpaperswide.com/download/colorful_apple-wallpaper-1920x1200.jpg";
        public string localFileName = "Resized/Apple.jpg";
        public void Run()
        {
            // TODO:
            // Grab an image from a public URL and write a function thats rescale the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)
            ThumbnailProps = new RescaledImageProperties()
            {
                Height = 100,
                Width = 80,
                DesiredFormat = "jpg",
                Suffix = "_thumb"
            };
            PreviewProps = new RescaledImageProperties()
            {
                Height = 1200,
                Width = 1600,
                DesiredFormat = "png",
                Suffix = "_preview"
            };
            SaveRescaledImages();
            Console.WriteLine(new String('x', 40));
        }

        private void SaveRescaledImages()
        {
            Dictionary<string, string> versions = new Dictionary<string, string>();
            versions.Add(ThumbnailProps.Suffix, "width=" + ThumbnailProps.Width + "&height=" + ThumbnailProps.Height + "&crop=auto&format=" + ThumbnailProps.DesiredFormat);
            versions.Add(PreviewProps.Suffix, "maxwidth=" + PreviewProps.Width + "&maxheight=" + PreviewProps.Height + "&format=" + PreviewProps.DesiredFormat + "&mode=max");
            string basePath = Path.GetFileNameWithoutExtension(localFileName);
            byte[] pic;
            using (WebClient client = new WebClient())
            {
                pic = client.DownloadData(publicURL);
            }
            foreach (string suffix in versions.Keys)
            {
                var job = new ImageJob
                {
                    Source = pic,
                    Dest = basePath + suffix,
                    Instructions = new Instructions(versions[suffix]),
                    DisposeSourceObject = false,
                    AddFileExtension = true,
                    ResetSourceStream = true,
                };
                ImageBuilder.Current.Build(job);
                Console.WriteLine("The Image has been created at " + job.FinalPath + " in " + TimeSpan.FromTicks(job.TotalTicks).TotalSeconds.ToString("F") + " Seconds");
            }
        }
    }
    public class RescaledImageProperties
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Suffix { get; set; }
        public string DesiredFormat { get; set; }
    }
}
