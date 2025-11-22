    using Avalonia.Media.Imaging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace GalleryAvalonia.Model
    {
        public class GalleryPainting
        {
           public string name { get; }
            public string creator { get; }
            public string condition { get; }
            public int price { get; }
            public Bitmap cardimage { get; }
            public GalleryPainting(string name , string creator, string condition, int price, Bitmap cardimage)
            {
                this.name = name;
                this.creator = creator;
                this.condition = condition;
                this.price = price;
                this.cardimage = cardimage;
            }
        }
    }
