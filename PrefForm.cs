/*
 * Copyright 2016 Adam Reeve
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except 
 * in compliance with the License. You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under the License 
 * is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express 
 * or implied. See the License for the specific language governing permissions and limitations 
 * under the License.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using Com.AdamReeve.Slim.SlimCliLib;


namespace Com.AdamReeve.Slim.WinSlim
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public class PrefForm : System.Windows.Forms.Form
	{	    	
	    
	    private MainForm mainForm;
	    
		public PrefForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}		
				
		internal MainForm MainForm {
		    set {
		        this.mainForm = value;
		    }
		}
		
		private void refreshAll() {
		    SlimCli client = mainForm.Client;
		    
		    Assembly ws = Assembly.GetExecutingAssembly();
		    labelWSVer.Text = ws.GetName().Version.ToString();
		    labelSCLVer.Text = client.getVersion();

		    if (client.Connected) {
    		    Server server = client.getServer();		    
    		    labelSSVer.Text = server.ServerVersion;
    		    
    		    labelLibStats.Text = string.Format(
    		                                  "Your music library contains {0} albums with {1} songs by {2} artists",
    		                                  server.AlbumCount,
    		                                  server.SongCount,
    		                                  server.ArtistCount);
    		    
    		    labelLibScanning.Text = server.Scanning ? "Scanning in progress" : "Scanning complete";
		    } else {
    		    labelSSVer.Text = "Not Connected";
		        labelLibStats.Text = "Not Connected - No Library Available";
		        labelLibScanning.Text = "";
		    }
		}
		
		
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.labelSSVer = new System.Windows.Forms.Label();
			this.labelSCLVer = new System.Windows.Forms.Label();
			this.labelWSVer = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonWipeCache = new System.Windows.Forms.Button();
			this.buttonRescanPlaylists = new System.Windows.Forms.Button();
			this.labelLibScanning = new System.Windows.Forms.Label();
			this.buttonRescan = new System.Windows.Forms.Button();
			this.labelLibStats = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textPort = new System.Windows.Forms.TextBox();
			this.textHost = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.labelSSVer);
			this.groupBox1.Controls.Add(this.labelSCLVer);
			this.groupBox1.Controls.Add(this.labelWSVer);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(10, 14);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(327, 99);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "About";
			this.groupBox1.UseCompatibleTextRendering = true;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(313, 32);
			this.label4.TabIndex = 7;
			this.label4.Text = "WinSlim && SlimCliLib are copyright 2006 Adam Reeve. ";
			this.label4.UseCompatibleTextRendering = true;
			// 
			// labelSSVer
			// 
			this.labelSSVer.Location = new System.Drawing.Point(128, 45);
			this.labelSSVer.Name = "labelSSVer";
			this.labelSSVer.Size = new System.Drawing.Size(130, 15);
			this.labelSSVer.TabIndex = 6;
			this.labelSSVer.UseCompatibleTextRendering = true;
			// 
			// labelSCLVer
			// 
			this.labelSCLVer.Location = new System.Drawing.Point(128, 30);
			this.labelSCLVer.Name = "labelSCLVer";
			this.labelSCLVer.Size = new System.Drawing.Size(130, 15);
			this.labelSCLVer.TabIndex = 5;
			this.labelSCLVer.UseCompatibleTextRendering = true;
			// 
			// labelWSVer
			// 
			this.labelWSVer.Location = new System.Drawing.Point(128, 15);
			this.labelWSVer.Name = "labelWSVer";
			this.labelWSVer.Size = new System.Drawing.Size(130, 15);
			this.labelWSVer.TabIndex = 4;
			this.labelWSVer.UseCompatibleTextRendering = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 15);
			this.label1.TabIndex = 3;
			this.label1.Text = "WinSlim Version";
			this.label1.UseCompatibleTextRendering = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "SlimCliLib Version";
			this.label3.UseCompatibleTextRendering = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "SlimServer Version";
			this.label2.UseCompatibleTextRendering = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonWipeCache);
			this.groupBox2.Controls.Add(this.buttonRescanPlaylists);
			this.groupBox2.Controls.Add(this.labelLibScanning);
			this.groupBox2.Controls.Add(this.buttonRescan);
			this.groupBox2.Controls.Add(this.labelLibStats);
			this.groupBox2.Location = new System.Drawing.Point(10, 119);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(327, 128);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Library";
			this.groupBox2.UseCompatibleTextRendering = true;
			// 
			// buttonWipeCache
			// 
			this.buttonWipeCache.Location = new System.Drawing.Point(219, 94);
			this.buttonWipeCache.Name = "buttonWipeCache";
			this.buttonWipeCache.Size = new System.Drawing.Size(100, 23);
			this.buttonWipeCache.TabIndex = 11;
			this.buttonWipeCache.Text = "Wipe && Rescan";
			this.buttonWipeCache.UseCompatibleTextRendering = true;
			this.buttonWipeCache.UseVisualStyleBackColor = true;
			// 
			// buttonRescanPlaylists
			// 
			this.buttonRescanPlaylists.Location = new System.Drawing.Point(113, 94);
			this.buttonRescanPlaylists.Name = "buttonRescanPlaylists";
			this.buttonRescanPlaylists.Size = new System.Drawing.Size(100, 23);
			this.buttonRescanPlaylists.TabIndex = 10;
			this.buttonRescanPlaylists.Text = "Rescan Playlists";
			this.buttonRescanPlaylists.UseCompatibleTextRendering = true;
			this.buttonRescanPlaylists.UseVisualStyleBackColor = true;
			// 
			// labelLibScanning
			// 
			this.labelLibScanning.Location = new System.Drawing.Point(7, 68);
			this.labelLibScanning.Name = "labelLibScanning";
			this.labelLibScanning.Size = new System.Drawing.Size(312, 23);
			this.labelLibScanning.TabIndex = 9;
			this.labelLibScanning.Text = "Library scanning is complete";
			this.labelLibScanning.UseCompatibleTextRendering = true;
			// 
			// buttonRescan
			// 
			this.buttonRescan.Location = new System.Drawing.Point(7, 94);
			this.buttonRescan.Name = "buttonRescan";
			this.buttonRescan.Size = new System.Drawing.Size(100, 23);
			this.buttonRescan.TabIndex = 8;
			this.buttonRescan.Text = "Rescan";
			this.buttonRescan.UseCompatibleTextRendering = true;
			this.buttonRescan.UseVisualStyleBackColor = true;
			// 
			// labelLibStats
			// 
			this.labelLibStats.Location = new System.Drawing.Point(7, 17);
			this.labelLibStats.Name = "labelLibStats";
			this.labelLibStats.Size = new System.Drawing.Size(312, 42);
			this.labelLibStats.TabIndex = 0;
			this.labelLibStats.UseCompatibleTextRendering = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textPort);
			this.groupBox3.Controls.Add(this.textHost);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Location = new System.Drawing.Point(10, 253);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(327, 78);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Preferences";
			this.groupBox3.UseCompatibleTextRendering = true;
			// 
			// textPort
			// 
			this.textPort.Location = new System.Drawing.Point(113, 44);
			this.textPort.MaxLength = 8;
			this.textPort.Name = "textPort";
			this.textPort.Size = new System.Drawing.Size(145, 21);
			this.textPort.TabIndex = 7;
			// 
			// textHost
			// 
			this.textHost.Location = new System.Drawing.Point(113, 17);
			this.textHost.Name = "textHost";
			this.textHost.Size = new System.Drawing.Size(145, 21);
			this.textHost.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 47);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 15);
			this.label6.TabIndex = 5;
			this.label6.Text = "SlimServer Port";
			this.label6.UseCompatibleTextRendering = true;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "SlimServer Host";
			this.label5.UseCompatibleTextRendering = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(262, 337);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseCompatibleTextRendering = true;
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(181, 337);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseCompatibleTextRendering = true;
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// refreshTimer
			// 
			this.refreshTimer.Interval = 5000;
			this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimerTick);
			// 
			// PrefForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(348, 364);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PrefForm";
			this.Text = "WinSlim Preferences";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PrefFormFormClosed);
			this.Load += new System.EventHandler(this.PrefFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textHost;
		private System.Windows.Forms.TextBox textPort;
		private System.Windows.Forms.Button buttonWipeCache;
		private System.Windows.Forms.Button buttonRescanPlaylists;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label labelLibStats;
		private System.Windows.Forms.Button buttonRescan;
		private System.Windows.Forms.Label labelLibScanning;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labelWSVer;
		private System.Windows.Forms.Label labelSCLVer;
		private System.Windows.Forms.Label labelSSVer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		#endregion
		
		
		void ButtonOKClick(object sender, System.EventArgs e)
		{
		    SlimCli client = mainForm.Client;

		    if (!(textHost.Text.Equals(client.ServerHost) && textPort.Text.Equals(client.ServerPort))) {
		        bool result = mainForm.reconnect(textHost.Text, int.Parse(textPort.Text));
		        if (!result) {
		            MessageBox.Show(string.Format("Unable to connect to slimserver at {0}:{1}. Please enter the correct values.", textHost.Text, textPort.Text),
		                            "Connection Error", 
		                            MessageBoxButtons.OK);
    		        return;
		        }
		    }
		    this.Close();
		}
		
		void ButtonCancelClick(object sender, System.EventArgs e)
		{
		    this.Close();			
		}
		
		void RefreshTimerTick(object sender, System.EventArgs e)
		{
		    refreshAll();
		}
		
		void PrefFormFormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
		    refreshTimer.Stop();
		}
		
		void PrefFormLoad(object sender, System.EventArgs e)
		{
		    refreshAll();
		    SlimCli client = mainForm.Client;
		    textHost.Text = client.ServerHost;
		    textPort.Text = client.ServerPort.ToString();
		    refreshTimer.Start();
		}
		
	}
}
