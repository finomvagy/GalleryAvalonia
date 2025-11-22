using CommunityToolkit.Mvvm.Input;
using GalleryAvalonia.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAvalonia.ViewModels
{
    public class GalleryViewModel : ViewModelBase
    {
        private int currrentpaintingnumber;
        private GalleryModel _model;
        public string PaintingNumber
        {
            get
            {
                return $"{currrentpaintingnumber} / {_model.getnumberofpaintings()}";
            }
        }
        public ObservableCollection<GalleryPainting> paintings { get; }
        public bool notfirst
        {
            get
            {
                if (currrentpaintingnumber != 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       public bool notlast
        {
            get
            {
                if (currrentpaintingnumber!= _model.getnumberofpaintings())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       public  RelayCommand prviuscommand { get; private set; }
       public  RelayCommand nextcommand { get; private set; }
        public GalleryViewModel(GalleryModel model)
        {
            _model = model;
            paintings = new ObservableCollection<GalleryPainting>();
            paintings.Add(model.getpainting(0));
            currrentpaintingnumber = 1;
            prviuscommand = new RelayCommand(_model.prevpainting);
            nextcommand = new RelayCommand(_model.nextpainting);
            _model.PaintingChanged += modelpaintingchanged;
        }

        private void modelpaintingchanged(object? sender, GalleryEventArgs e)
        {
            paintings.Clear();
            paintings.Add(e.painting);
            currrentpaintingnumber = e.paintingnumber + 1;
            OnPropertyChanged(nameof(notfirst));
            OnPropertyChanged(nameof(notlast));
            OnPropertyChanged(nameof(PaintingNumber));
        }
    }
}
