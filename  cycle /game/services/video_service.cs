namespace Namespace {
    
    using pyray;
    
    using constants;
    
    using System;
    
    using System.Linq;
    
    public static class Module {
        
        // Outputs the game state. The responsibility of the class of objects is to draw the game state
        //     on the screen.
        //     
        public class VideoService {
            
            public VideoService(object debug = false) {
                this._debug = debug;
            }
            
            // Closes the window and releases all computing resources.
            public virtual object close_window() {
                pyray.close_window();
            }
            
            // Clears the buffer in preparation for the next rendering. This method should be called at
            //         the beginning of the game's output phase.
            //         
            public virtual object clear_buffer() {
                pyray.begin_drawing();
                pyray.clear_background(pyray.BLACK);
                if (this._debug == true) {
                    this._draw_grid();
                }
            }
            
            // Draws the given actor's text on the screen.
            //         Args:
            //         ---
            //             actor (Actor): The actor to draw.
            //         
            public virtual object draw_actor(object actor, object centered = false) {
                var text = actor.get_text();
                var x = actor.get_position().get_x();
                var y = actor.get_position().get_y();
                var font_size = actor.get_font_size();
                var color = actor.get_color().to_tuple();
                if (centered) {
                    var width = pyray.measure_text(text, font_size);
                    var offset = Convert.ToInt32(width / 2);
                    x -= offset;
                }
                pyray.draw_text(text, x, y, font_size, color);
            }
            
            // Draws the text for the given list of actors on the screen.
            //         Args:
            //         ---
            //             actors (list): A list of actors to draw.
            //         
            public virtual object draw_actors(object actors, object centered = false) {
                foreach (var actor in actors) {
                    this.draw_actor(actor, centered);
                }
            }
            
            // Copies the buffer contents to the screen. This method should be called at the end of
            //         the game's output phase.
            //         
            public virtual object flush_buffer() {
                pyray.end_drawing();
            }
            
            // Whether or not the window was closed by the user.
            //         Returns:
            //         ---
            //             bool: True if the window is closing; false if otherwise.
            //         
            public virtual object is_window_open() {
                return !pyray.window_should_close();
            }
            
            // Opens a new window with the provided title.
            //         Args:
            //         ---
            //             title (string): The title of the window.
            //         
            public virtual object open_window() {
                pyray.init_window(constants.MAX_X, constants.MAX_Y, constants.CAPTION);
                pyray.set_target_fps(constants.FRAME_RATE);
            }
            
            // Draws a grid on the screen.
            public virtual object _draw_grid() {
                foreach (var y in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(constants.MAX_Y - 0) / constants.CELL_SIZE))).Select(_x_1 => 0 + _x_1 * constants.CELL_SIZE)) {
                    pyray.draw_line(0, y, constants.MAX_X, y, pyray.GRAY);
                }
                foreach (var x in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(constants.MAX_X - 0) / constants.CELL_SIZE))).Select(_x_2 => 0 + _x_2 * constants.CELL_SIZE)) {
                    pyray.draw_line(x, 0, x, constants.MAX_Y, pyray.GRAY);
                }
            }
            
            // Gets the offset measurement for the text.
            //         
            //         Args:
            //         ---
            //             text (string): The actor's textual representation.
            //             font_size (constant): The size of an actor.
            //         
            public virtual object _get_x_offset(object text, object font_size) {
                var width = pyray.measure_text(text, font_size);
                return Convert.ToInt32(width / 2);
            }
        }
    }
}