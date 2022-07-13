namespace Namespace {
    
    public static class Module {
        
        // A distance from a relative origin (0, 0).
        //     The responsibility of Point is to hold and provide information about itself. Point has a few
        //     convenience methods for adding, scaling, and comparing them.
        //     Attributes:
        //     ---
        //         _x (integer): The horizontal distance from the origin.
        //         _y (integer): The vertical distance from the origin.
        //     
        public class Point {
            
            public Point(object x, object y) {
                this._x = x;
                this._y = y;
            }
            
            // Gets a new point that is the sum of this and the given one.
            //         Args:
            //         ---
            //             other (Point): The Point to add.
            //         Returns:
            //             Point: A new Point that is the sum.
            //         
            public virtual object add(object other) {
                var x = this._x + other.get_x();
                var y = this._y + other.get_y();
                return Point(x, y);
            }
            
            // Whether or not this Point is equal to the given one.
            //         Args:
            //         ---
            //             other (Point): The Point to compare.
            //         Returns:
            //             boolean: True if both x and y are equal; false if otherwise.
            //         
            public virtual object equals(object other) {
                return this._x == other.get_x() && this._y == other.get_y();
            }
            
            // Gets the horizontal distance.
            //         Returns:
            //         ---
            //             integer: The horizontal distance.
            //         
            public virtual object get_x() {
                return this._x;
            }
            
            // Gets the vertical distance.
            //         Returns:
            //         ---
            //             integer: The vertical distance.
            //         
            public virtual object get_y() {
                return this._y;
            }
            
            // Reverses the point by inverting both x and y values.
            //         Returns:
            //         ---
            //             Point: A new point that is reversed.
            //         
            public virtual object reverse() {
                var new_x = this._x * -1;
                var new_y = this._y * -1;
                return Point(new_x, new_y);
            }
            
            // 
            //         Scales the point by the provided factor.
            //         Args:
            //         ---
            //             factor (int): The amount to scale.
            //         Returns:
            //         ---
            //             Point: A new Point that is scaled.
            //         
            public virtual object scale(object factor) {
                return Point(this._x * factor, this._y * factor);
            }
        }
    }
}