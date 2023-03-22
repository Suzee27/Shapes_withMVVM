using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Shapes_Publisher.Model
{
    public class ShapeModel
    {
        
        public Shape? Shape { get; set; }

        public IList<ShapeModel> Shapes()
        {
            var shapes = new List<ShapeModel>();
            var rect = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.Red,
                Stroke = Brushes.Green
            };
            shapes.Add(new ShapeModel { Shape=rect});
            return shapes;
        }

        public Shape? CloneShape(Shape? shape)
        {
            var newShape = Activator.CreateInstance(shape.GetType()) as Shape;

            if (newShape == null) return null;
            newShape.Width = shape.Width;
            newShape.Height = shape.Height;
            newShape.Stroke = shape.Stroke;
            newShape.Fill = shape.Fill;
            
            var size = new Size(shape.Width, shape.Height);
            newShape.Measure(size);
            newShape.Arrange(new Rect(size));
            newShape.UpdateLayout();

            return newShape;
        }
    }
}
