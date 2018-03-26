/*
 *Application name  : Opdracht 3 webservice
 *Author            : Team firefly
*/
namespace WindowsServiceOpdracht3
{
    partial class ProjectInstaller
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
            this.opdracht3Installer1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.opdracht3service = new System.ServiceProcess.ServiceInstaller();
            // 
            // opdracht3Installer1
            // 
            this.opdracht3Installer1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.opdracht3Installer1.Password = null;
            this.opdracht3Installer1.Username = null;
            // 
            // opdracht3service
            // 
            this.opdracht3service.ServiceName = "opdracht3service";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.opdracht3Installer1,
            this.opdracht3service});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller opdracht3Installer1;
        private System.ServiceProcess.ServiceInstaller opdracht3service;
    }
}