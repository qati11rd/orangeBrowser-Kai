namespace orangeBrowser_Kai.Forms
{
	partial class Main
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonSettings = new System.Windows.Forms.Button();
			this.textBoxUrlBar = new System.Windows.Forms.TextBox();
			this.buttonGo = new System.Windows.Forms.Button();
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// buttonSettings
			// 
			this.buttonSettings.Location = new System.Drawing.Point(0, 0);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(55, 23);
			this.buttonSettings.TabIndex = 0;
			this.buttonSettings.Text = "Settings";
			this.buttonSettings.UseVisualStyleBackColor = true;
			// 
			// textBoxUrlBar
			// 
			this.textBoxUrlBar.AcceptsReturn = true;
			this.textBoxUrlBar.AllowDrop = true;
			this.textBoxUrlBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxUrlBar.Font = new System.Drawing.Font("MS UI Gothic", 12F);
			this.textBoxUrlBar.Location = new System.Drawing.Point(56, 0);
			this.textBoxUrlBar.Multiline = true;
			this.textBoxUrlBar.Name = "textBoxUrlBar";
			this.textBoxUrlBar.Size = new System.Drawing.Size(1101, 23);
			this.textBoxUrlBar.TabIndex = 1;
			this.textBoxUrlBar.TextChanged += new System.EventHandler(this.textBoxUrlBar_TextChanged);
			this.textBoxUrlBar.Enter += new System.EventHandler(this.textBoxUrlBar_Enter);
			this.textBoxUrlBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUrlBar_KeyPress);
			this.textBoxUrlBar.Leave += new System.EventHandler(this.textBoxUrlBar_Leave);
			// 
			// buttonGo
			// 
			this.buttonGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGo.Location = new System.Drawing.Point(1157, 0);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new System.Drawing.Size(27, 23);
			this.buttonGo.TabIndex = 2;
			this.buttonGo.Text = "Go";
			this.buttonGo.UseVisualStyleBackColor = true;
			this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
			// 
			// webBrowser
			// 
			this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.webBrowser.Location = new System.Drawing.Point(0, 24);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(1184, 739);
			this.webBrowser.TabIndex = 3;
			this.webBrowser.Url = new System.Uri("about:blank", System.UriKind.Absolute);
			this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
			this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser_Navigated);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 762);
			this.Controls.Add(this.webBrowser);
			this.Controls.Add(this.buttonGo);
			this.Controls.Add(this.textBoxUrlBar);
			this.Controls.Add(this.buttonSettings);
			this.Name = "Main";
			this.Text = "orangeBrowser-Kai";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.TextBox textBoxUrlBar;
		private System.Windows.Forms.Button buttonGo;
		private System.Windows.Forms.WebBrowser webBrowser;
	}
}
