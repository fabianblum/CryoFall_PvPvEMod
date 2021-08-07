namespace AtomicTorch.CBND.CoreMod.UI.Controls.Game.PvEProtection.Data
{
    using System.Windows;
    using AtomicTorch.CBND.CoreMod.Helpers.Client;
    using AtomicTorch.CBND.CoreMod.UI.Controls.Core;

    public class ViewModelHUDPvEProtectionInfo : BaseViewModel
    {
        public ViewModelHUDPvEProtectionInfo()
        {
            ClientUpdateHelper.UpdateCallback += this.UpdateTimerOnly;
            this.UpdateText();
        }

        public string ProtectionTimeRemainingText { get; set; }

        public float RequiredHeight { get; set; }

        public Visibility Visibility { get; private set; }

        public void Setup()
        {
            this.UpdateText();
        }

        protected override void DisposeViewModel()
        {
            base.DisposeViewModel();
            ClientUpdateHelper.UpdateCallback -= this.UpdateTimerOnly;
        }

        private void UpdateText()
        {
            if (this.IsDisposed)
            {
                return;
            }

            ClientTimersSystem.AddAction(0.333, this.UpdateText);
        }

        private void UpdateTimerOnly()
        {
            /*this.timeRemaining -= Client.Core.DeltaTime;
            if (this.timeRemaining <= 0)
            {
                this.timeRemaining = 0;
                this.Visibility = Visibility.Collapsed;
                return;
            }*/

            this.Visibility = Visibility.Visible;
        }
    }
}