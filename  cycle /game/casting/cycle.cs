namespace Namespace {
    
    using constants;
    
    using Actor = game.casting.actor.Actor;
    
    using Point = game.shared.point.Point;
    
    using Color = game.shared.color.Color;
    
    using System.Collections.Generic;
    
    using System;
    
    using System.Linq;
    
    public static class Module {
        
        // A fast motorcycle.
        //     The responsibility of Cycle is to move itself.
        //     Attributes:
        //     ---
        //         _segments (list): A list of actors that make up each cycle.
        //         _color (tuple): A tuple containing the values that make up a color.
        //         _prepare_cycle (method): A method that will create the cycle for each instance of Cycle.
        //         _name (str): An empty string that will hold each players name.
        //     
        public class Cycle
            : Actor {
            
            public Cycle(object position) {
                this._segments = new List<object>();
                this._color = Color(255, 255, 255);
                this._prepare_cycle(position);
                this._name = "";
            }
            
            // Gets the segments for each cycle.
            //         Returns:
            //         ---
            //             List: The list of actors for each cycle
            public virtual object get_segments() {
                return this._segments;
            }
            
            // Gets the players name.
            //         Returns:
            //         ---
            //             String: The players name as text.
            public virtual object get_name() {
                return this._name;
            }
            
            // Moves the actor to its next position according to its velocity. Will move each actor
            //         in _segments beginning from the last segment and ending with the first segment and
            //         stepping by -1 to iterate through the last backwards.
            public virtual object move_next() {
                // move all segments
                foreach (var segment in this._segments) {
                    segment.move_next();
                }
                // update velocities
                foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(0 - (this._segments.Count - 1)) / -1))).Select(_x_1 => this._segments.Count - 1 + _x_1 * -1)) {
                    var trailing = this._segments[i];
                    var previous = this._segments[i - 1];
                    var velocity = previous.get_velocity();
                    trailing.set_velocity(velocity);
                }
            }
            
            // Gets the first actor from _segments.
            //         Returns:
            //         ---
            //             Actor: The first actor from the list of actors in _segments.
            public virtual object get_cycle() {
                return this._segments[0];
            }
            
            // Builds the wall for each cycle.
            //         Args:
            //         ---
            //             Boolean: Sets the color for each cycle if game is not over. Changes each
            //             cycle color to white if game is over.
            //         
            public virtual object wall(object game_over) {
                var wall = this._segments[-1];
                var velocity = wall.get_velocity();
                var offset = velocity.reverse();
                var position = wall.get_position().add(offset);
                var segment = Actor();
                segment.set_position(position);
                segment.set_velocity(velocity);
                segment.set_text("#");
                if (!game_over) {
                    segment.set_color(this._color);
                } else {
                    segment.set_color(constants.WHITE);
                }
                this._segments.append(segment);
            }
            
            // Changes the direction for a cycle by changing the velocity.
            //         Args:
            //         ---
            //             Point: A given velocity to change direction.
            //         
            public virtual object turn_cycle(object velocity) {
                this._segments[0].set_velocity(velocity);
            }
            
            // Constructs a new cycle.
            //         Args:
            //         ---
            //             Point: A position to set the cycle position and direction which it will travel in.
            //         
            public virtual object _prepare_cycle(object position) {
                var x = position.get_x();
                var y = position.get_y();
                foreach (var i in Enumerable.Range(0, constants.CYCLE_LENGTH)) {
                    position = Point(x, y + i * constants.CELL_SIZE);
                    var velocity = Point(0, 1 * -constants.CELL_SIZE);
                    var text = i == 0 ? "O" : "#";
                    var segment = Actor();
                    segment.set_position(position);
                    segment.set_velocity(velocity);
                    segment.set_text(text);
                    segment.set_color(this._color);
                    this._segments.append(segment);
                }
            }
            
            // Sets the color for each segment of a cycle.
            //         Args:
            //         ---
            //             color (Color): The given color.
            //         
            public virtual object set_cycle_color(object color) {
                this._color = color;
                foreach (var segment in this._segments) {
                    segment.set_color(this._color);
                }
            }
            
            // Sets the name for each player.
            //         Args:
            //         ---
            //             String: The players given name as text.
            //         
            public virtual object set_name(object name) {
                this._name = name;
            }
        }
    }
}