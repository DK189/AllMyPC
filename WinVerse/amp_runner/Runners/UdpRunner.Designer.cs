namespace amp_runner.Runners
{
    partial class UdpRunner
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Logger = new System.Diagnostics.EventLog();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.Logger)).BeginInit();
            // 
            // Worker
            // 
            this.Worker.WorkerReportsProgress = true;
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            // 
            // UdbRunner
            // 
            this.ServiceName = "UdbRunner";
            ((System.ComponentModel.ISupportInitialize)(this.Logger)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog Logger;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}
