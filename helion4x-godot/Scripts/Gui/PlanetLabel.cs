using Godot;
using Helion4x.Runtime;
using Helion4x.Singleton;

namespace Helion4x.Gui
{
    public class PlanetLabel : Control
    {
        #region Exports

        [Export] private float _moveDown;

        #endregion

        private Spatial _parent;
        private SelectionSystem _selectionSystem;

        public override void _Ready()
        {
            _parent = GetParent<Spatial>();
        }

        public override void _Process(float delta)
        {
            var parentPosition = _parent.GlobalTransform.origin;
            parentPosition.y -= _moveDown;
            var viewPosition = GetViewport().GetCamera().UnprojectPosition(parentPosition);
            var halfWidth = RectSize.x / 2;
            viewPosition.x -= halfWidth;
            SetPosition(viewPosition);
        }


        public override void _GuiInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mouseButton
                && mouseButton.IsPressed()
                && mouseButton.ButtonIndex == 1)
                foreach (var child in _parent.GetChildren())
                    if (child is Selectable selectable)
                        EventBus.InvokeSelected(selectable);
        }
    }
}