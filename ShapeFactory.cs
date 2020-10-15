using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    /// <summary>
    /// ShapeFactory Class: Returns the shape based on the shape type
    /// </summary>
    /// <remarks>
    /// This implements the factory pattern, to obtain the concrete shape objects
    /// based on the shape type passed as the parameter.
    /// </remarks>
    public class ShapeFactory
    {
        /// <summary>
        /// Static function to return the concrete shape object based on the parameter
        /// </summary>
        /// <param name="shapeType"> the integer shape type </param>
        /// <returns> the appropriate shape object </returns>
        public static Shape GetShape(int shapeType)
        {
            switch(shapeType)
            {
                case 1: return new ShapeRectangle();
                case 2: return new ShapeCircle();
                case 3: return new ShapeTriangle();
                default: return null;
            }
        }
    }
}
