namespace Namespace {
    
    using System.Collections.Generic;
    
    public static class Module {
        
        // A collection of actions.
        //     The responsibility of Script is to keep track of a collection of actions. It has methods for 
        //     adding, removing and getting them by a group name.
        //     Attributes:
        //     ---
        //         _actions (dict): A dictionary of actions { key: group_name, value: a list of actions }
        //     
        public class Script {
            
            public Script() {
                this._actions = new Dictionary<object, object> {
                };
            }
            
            // Adds an action to the given group.
            //         Args:
            //         ---
            //             group (string): The name of the group.
            //             action (Action): The action to add.
            //         
            public virtual object add_action(object group, object action) {
                if (!this._actions.keys().Contains(group)) {
                    this._actions[group] = new List<object>();
                }
                if (!this._actions[group].Contains(action)) {
                    this._actions[group].append(action);
                }
            }
            
            // Gets the actions in the given group.
            //         Args:
            //         ---
            //             group (string): The name of the group.
            //         Returns:
            //             List: The actions in the group.
            //         
            public virtual object get_actions(object group) {
                var results = new List<object>();
                if (this._actions.keys().Contains(group)) {
                    results = this._actions[group].copy();
                }
                return results;
            }
            
            // Removes an action from the given group.
            //         Args:
            //         ---
            //             group (string): The name of the group.
            //             action (Action): The action to remove.
            //         
            public virtual object remove_action(object group, object action) {
                if (this._actions.Contains(group)) {
                    this._actions[group].remove(action);
                }
            }
        }
    }
}