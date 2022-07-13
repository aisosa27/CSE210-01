namespace Namespace {
    
    using constants;
    
    using Cast = game.casting.cast.Cast;
    
    using Score = game.casting.score.Score;
    
    using Cycle = game.casting.cycle.Cycle;
    
    using Script = game.scripting.script.Script;
    
    using ControlActorsAction = game.scripting.control_actors_action.ControlActorsAction;
    
    using MoveActorsAction = game.scripting.move_actors_action.MoveActorsAction;
    
    using HandleCollisionsAction = game.scripting.handle_collisions_action.HandleCollisionsAction;
    
    using DrawActorsAction = game.scripting.draw_actors_action.DrawActorsAction;
    
    using Director = game.directing.director.Director;
    
    using KeyboardService = game.services.keyboard_service.KeyboardService;
    
    using VideoService = game.services.video_service.VideoService;
    
    using Point = game.shared.point.Point;
    
    using System;
    
    public static class Module {
        
        public static object main() {
            // Creates two cycles, gets their position and color
            var cycle_one = Cycle(Point(Convert.ToInt32(constants.MAX_X - 600), Convert.ToInt32(constants.MAX_Y / 2)));
            var cycle_two = Cycle(Point(Convert.ToInt32(constants.MAX_X - 300), Convert.ToInt32(constants.MAX_Y / 2)));
            cycle_one.set_cycle_color(constants.GREEN);
            cycle_two.set_cycle_color(constants.RED);
            var cycle_one_name = input("\n\nPlease enter player 1 name: " + "\n\n");
            var cycle_two_name = input("\n\nPlease enter player 2 name: " + "\n\n");
            cycle_one.set_name(cycle_one_name);
            cycle_two.set_name(cycle_two_name);
            // Create the cast
            var cast = Cast();
            var score1 = Score();
            var score2 = Score();
            score1.set_position(Point(constants.MAX_X - 850, 0));
            score2.set_position(Point(constants.MAX_X - 200, 0));
            score1.add_points(3);
            score2.add_points(3);
            score1.set_player_name(cycle_one_name);
            score2.set_player_name(cycle_two_name);
            cast.add_actor("cycle_one", cycle_one);
            cast.add_actor("cycle_two", cycle_two);
            cast.add_actor("score1", score1);
            cast.add_actor("score2", score2);
            // Start the game
            var keyboard_service = KeyboardService();
            var video_service = VideoService();
            var script = Script();
            script.add_action("input", ControlActorsAction(keyboard_service));
            script.add_action("update", HandleCollisionsAction());
            script.add_action("update", MoveActorsAction());
            script.add_action("output", DrawActorsAction(video_service));
            var director = Director(video_service);
            director.start_game(cast, script);
        }
        
        static Module() {
            main();
        }
    }
}