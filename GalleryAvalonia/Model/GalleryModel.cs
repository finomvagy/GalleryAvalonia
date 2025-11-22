using Avalonia.Controls.Platform;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAvalonia.Model
{
    public class GalleryModel
    {

        private string[] _adjectives = { "Ethereal", "Fleeting", "Forgotten", "Golden", "Luminous", "Misty", "Nocturnal", "Radiant", "Silent", "Solitary" };

        private string[] _nouns = { "Dream", "Echo", "Garden", "Harbor", "Horizon", "Memory", "Passage", "Reflection", "Twilight", "Whisper" };

        private string[] _painterNames = { "Leonardo da Vinci", "Michelangelo", "Vincent van Gogh", "Claude Monet", "Pablo Picasso" };

        private string[] _artworkConditions = { "Pristine", "Lightly Aged", "Restored", "Weathered" };
        Random _random;
        private List<GalleryPainting> _paintings;
        private int currentpaintingnumber;
        public event EventHandler<GalleryEventArgs>? PaintingChanged;
        public GalleryModel(int numOfPaintings)
        {
            _random = new Random();
            _paintings = new List<GalleryPainting>();
            currentpaintingnumber = 0;
            generategallery(numOfPaintings);

        }
        private void generategallery(int manypainting)
        {
            for (int i = 0; i < manypainting; i++)
            {
                string randomname = $"{_adjectives[_random.Next(_adjectives.Length)]} {_nouns[_random.Next(_nouns.Length)]}";
                string randomcreator = _painterNames[_random.Next(_painterNames.Length)];
                string randomcocondition = _artworkConditions[_random.Next(_artworkConditions.Length)];
                int randomprice = _random.Next(100, 1001);
                switch (randomcocondition)
                {
                    case "Pristine":
                        randomprice = randomprice* 10;
                        break;
                    case "Lightly Aged":
                        randomprice = randomprice * 7;
                        break;
                    case "Restored":
                        randomprice = randomprice * 3;
                        break;
                    case "Weathered":
                        randomprice = randomprice * -50;
                        break;
                }
                int picnum = _random.Next(1, 8);

                Bitmap Img = null;
                Uri uri = new Uri($"avares://GalleryAvalonia/Assets/Painting{picnum}.jpg");
                try
                {
                    using (Stream stream = AssetLoader.Open(uri))
                    {
                        Img = new Bitmap(stream);
                    }
                }
                catch
                {

                    Img = null;
                }
                GalleryPainting newpaintings = new GalleryPainting(randomname, randomcreator, randomcocondition, randomprice, Img);
                _paintings.Add(newpaintings);
            }
         
        }
        public GalleryPainting getpainting(int wichpainting)
        {
            
            if (wichpainting<1&&_paintings.Count < wichpainting )
            {
                return _paintings[0];
            }
            else
            {
                return _paintings[wichpainting];
            }
        }
        public void nextpainting()
        {
            if (currentpaintingnumber < _paintings.Count-1)
            {
                currentpaintingnumber++;
                GalleryEventArgs args = new GalleryEventArgs(_paintings[currentpaintingnumber], currentpaintingnumber);
                PaintingChanged.Invoke(this, args);
            }
        }
        public void prevpainting()
        {
            if (currentpaintingnumber >0)
            {
                currentpaintingnumber--;
                GalleryEventArgs args = new GalleryEventArgs(_paintings[currentpaintingnumber], currentpaintingnumber);
                PaintingChanged.Invoke(this, args);
            }
        }
        public int getnumberofpaintings()
        {
            return _paintings.Count;
        }
    }
}

            
       


