using Shapes_Publisher.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shapes_Publisher.ViewModel
{
    public class ShapeViewModel: INotifyPropertyChanged
    {
        public ShapeViewModel()
        {
            SelectedShape = new ShapeModel();
            Shapes = new ObservableCollection<ShapeModel>(SelectedShape.Shapes());
        }
        private ShapeModel? selectedShape;

        

        public ShapeModel? SelectedShape
        {
            get { return selectedShape; }
            set { selectedShape = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ShapeModel> Shapes { get; set; }

        internal void AddShapesToCanvas(CustomCanvas canvas, double x, double y)
        {
            var shape = SelectedShape?.CloneShape(SelectedShape.Shape);
            CustomCanvas.SetLeft(shape, x);
            CustomCanvas.SetTop(shape, y);
            canvas.Children.Add(shape);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
