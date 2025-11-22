using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAvalonia.Model
{
    public class GalleryEventArgs : EventArgs
    {
       public GalleryPainting painting = null;
        public int paintingnumber { get; }
        public GalleryEventArgs(GalleryPainting painting,int paintingnumber)
        {
            this.paintingnumber = paintingnumber;
           this.painting = painting;
        }

    }
}
