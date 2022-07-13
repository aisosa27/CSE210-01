namespace Namespace {
    
    public static class Module {
        
        // A person who directs the game.
        //     The responsibility of a Director is to control the sequence of play.
        //     Attributes:
        //     ---
        //         _video_service (VideoService): For providing video output.
        //     
        public class Director {
            
            public Director(object video_service) {
                this._video_service = video_service;
            }
            
            // Starts the game using the given cast and script. Runs the main game loop.
            //         Args:
            //         ---
            //             cast (Cast): The cast of actors.
            //             script (Script): The script of actions.
            //         
            public virtual object start_game(object cast, object script) {
                this._video_service.open_window();
                while (this._video_service.is_window_open()) {
                    this._execute_actions("input", cast, script);
                    this._execute_actions("update", cast, script);
                    this._execute_actions("output", cast, script);
                }
                this._video_service.close_window();
            }
            
            // Calls execute for each action in the given group.
            //         Args:
            //         ---
            //             group (string): The action group name.
            //             cast (Cast): The cast of actors.
            //             script (Script): The script of actions.
            //         
            public virtual object _execute_actions(object group, object cast, object script) {
                var actions = script.get_actions(group);
                foreach (var action in actions) {
                    action.execute(cast, script);
                }
            }
        }
    }
}