namespace Namespace {
    
    using Action = game.scripting.action.Action;
    
    public static class Module {
        
        // 
        //     An output action that draws all the actors.
        //     The responsibility of DrawActorsAction is to draw all the actors.
        //     Attributes:
        //     ---
        //         _video_service (VideoService): An instance of VideoService.
        //     
        public class DrawActorsAction
            : Action {
            
            public DrawActorsAction(object video_service) {
                this._video_service = video_service;
            }
            
            // Executes the draw actors action.
            //         Args:
            //         ---
            //             cast (Cast): The cast of Actors in the game.
            //             script (Script): The script of Actions in the game.
            //         
            public virtual object execute(object cast, object script) {
                var score1 = cast.get_first_actor("score1");
                var score2 = cast.get_first_actor("score2");
                var cycle_one = cast.get_first_actor("cycle_one");
                var cycle_two = cast.get_first_actor("cycle_two");
                var segments_one = cycle_one.get_segments();
                var segments_two = cycle_two.get_segments();
                var messages = cast.get_actors("messages");
                this._video_service.clear_buffer();
                this._video_service.draw_actors(segments_one);
                this._video_service.draw_actors(segments_two);
                this._video_service.draw_actor(score1);
                this._video_service.draw_actor(score2);
                this._video_service.draw_actors(messages, true);
                this._video_service.flush_buffer();
            }
        }
    }
}