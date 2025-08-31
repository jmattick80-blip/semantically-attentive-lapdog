using System.Collections.Generic;
using System.Linq;
using GalleryDrivers.Prism.Input.InputDefinitions;
using GalleryDrivers.Prism.Shared.Enums;

namespace GalleryDrivers.Prism.Input.InputMaps
{
    public class InputMap
    {
        public List<RawInputDefinition> Actions { get; }

        public InputMap(List<RawInputDefinition> definitions)
        {
            Actions = definitions;
        }

        public RawInputDefinition FindByActionName(string name)
        {
            return Actions.Find(def => def.ActionName == name);
        }

        public IEnumerable<RawInputDefinition> FilterByIntent(InputIntentType intent)
        {
            return Actions.FindAll(def => def.IntentType == intent);
        }
        
        public IEnumerable<string> GetBindingsForAction(string actionId)
        {
            return Actions
                .Where(def => def.ActionName == actionId && !string.IsNullOrEmpty(def.BindingPath))
                .Select(def => def.BindingPath);
        }

    }
}