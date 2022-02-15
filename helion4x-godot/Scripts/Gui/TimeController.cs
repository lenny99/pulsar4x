using System.Globalization;
using Godot;
using Helion4x.Runtime;

namespace Helion4x.Gui
{
    public class TimeController : Control
    {
        private Button _fasterButton;
        private Button _pauseButton;
        private Button _slowerButton;
        private Label _timeLabel;

        private TimeManager _timeManager;


        public override void _Ready()
        {
            _timeManager = GetNode<TimeManager>(_timeManagerPath);
            _timeLabel = GetNode<Label>(_timeLabelPath);
            _slowerButton = GetNode<Button>(_slowerButtonPath);
            _pauseButton = GetNode<Button>(_pauseButtonPath);
            _fasterButton = GetNode<Button>(_fasterButtonPath);
        }

        public override void _Process(float delta)
        {
            _timeLabel.Text = _timeManager.Time.ToString(CultureInfo.InvariantCulture);
        }

        #region Exports

        [Export] private NodePath _timeManagerPath;
        [Export] private NodePath _timeLabelPath;
        [Export] private NodePath _slowerButtonPath;
        [Export] private NodePath _pauseButtonPath;
        [Export] private NodePath _fasterButtonPath;

        #endregion
    }
}