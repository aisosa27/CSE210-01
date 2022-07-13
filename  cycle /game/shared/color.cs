namespace Namespace {
    
    public static class Module {
        
        // A color.
        //     The responsibility of Color is to hold and provide information about itself. Color has a few
        //     convenience methods for comparing them and converting to a tuple.
        //     Attributes:
        //     ---
        //         _red (int): The red value.
        //         _green (int): The green value.
        //         _blue (int): The blue value.
        //         _alpha (int): The alpha or opacity.
        //     
        public class Color {
            
            public Color(object red, object green, object blue, object alpha = 255) {
                this._red = red;
                this._green = green;
                this._blue = blue;
                this._alpha = alpha;
            }
            
            // Gets the color as a tuple of four values (red, green, blue, alpha).
            //         Returns:
            //         ---
            //             Tuple(int, int, int, int): The color as a tuple.
            //         
            public virtual object to_tuple() {
                return (this._red, this._green, this._blue, this._alpha);
            }
        }
    }
}