using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Text;
using Com.AdamReeve.Slim.SlimCliLib;
using Microsoft.Win32;


namespace Com.AdamReeve.Slim.WinSlim
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{	    
	    private PrefForm prefForm;

	    private SlimCli client;
	    private Server server;
	    private bool expanded;
	    
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.Expanded = false;
			
			string cliHost = (string)readPref("host", "localhost");
			int cliPort = (int)readPref("port", 9090);
			
			reconnect(cliHost, cliPort);
			
			prefForm = new PrefForm();
			prefForm.MainForm = this;
			
			if (!client.Connected) {
			    // this will return only when the client is connected or
			    // the user has hit cancel
			    prefForm.ShowDialog();
			} 

		}
		
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			try {
			    Application.Run(new MainForm());
			} catch (Exception e) {
		    	MessageBox.Show("Sorry, an error occured and the application will now exit. Details are in error.txt");
		        FileStream errLog = File.Create("error.txt");
		        StreamWriter sw = new StreamWriter(errLog);
		        sw.WriteLine("ERROR: " + e.ToString());
		        sw.WriteLine(e.StackTrace);
		        if (e is InvalidResponseException) {
		            sw.WriteLine(((InvalidResponseException)e).Response.dump());
		        }
		        sw.Close();
		        Environment.Exit(1);
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
			this.buttonPlay = new System.Windows.Forms.Button();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonPause = new System.Windows.Forms.Button();
			this.comboPlayers = new System.Windows.Forms.ComboBox();
			this.buttonPrev = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonPower = new System.Windows.Forms.Button();
			this.sliderVolume = new System.Windows.Forms.TrackBar();
			this.systemHotkeyPlay = new CodeProject.SystemHotkey.SystemHotkey(this.components);
			this.systemHotkeyStop = new CodeProject.SystemHotkey.SystemHotkey(this.components);
			this.systemHotkeyNext = new CodeProject.SystemHotkey.SystemHotkey(this.components);
			this.systemHotkeyPrev = new CodeProject.SystemHotkey.SystemHotkey(this.components);
			this.systemHotkeyVolUp = new CodeProject.SystemHotkey.SystemHotkey(this.components);
			this.systemHotkeyVolDown = new CodeProject.SystemHotkey.SystemHotkey(this.components);
			this.buttonPrefs = new System.Windows.Forms.Button();
			this.buttonInfo = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.labelAlbum = new System.Windows.Forms.Label();
			this.labelArtist = new System.Windows.Forms.Label();
			this.labelTitle = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.sliderVolume)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonPlay
			// 
			this.buttonPlay.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonPlay.Location = new System.Drawing.Point(13, 39);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(29, 23);
			this.buttonPlay.TabIndex = 0;
			this.buttonPlay.Text = "4";
			this.buttonPlay.UseCompatibleTextRendering = true;
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new System.EventHandler(this.ButtonPlayClick);
			// 
			// buttonStop
			// 
			this.buttonStop.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonStop.Location = new System.Drawing.Point(83, 39);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(29, 23);
			this.buttonStop.TabIndex = 1;
			this.buttonStop.Text = "<";
			this.buttonStop.UseCompatibleTextRendering = true;
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
			// 
			// buttonPause
			// 
			this.buttonPause.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonPause.Location = new System.Drawing.Point(48, 39);
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.Size = new System.Drawing.Size(29, 23);
			this.buttonPause.TabIndex = 2;
			this.buttonPause.Text = ";";
			this.buttonPause.UseCompatibleTextRendering = true;
			this.buttonPause.UseVisualStyleBackColor = true;
			this.buttonPause.Click += new System.EventHandler(this.ButtonPauseClick);
			// 
			// comboPlayers
			// 
			this.comboPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboPlayers.FormattingEnabled = true;
			this.comboPlayers.Location = new System.Drawing.Point(12, 12);
			this.comboPlayers.Name = "comboPlayers";
			this.comboPlayers.Size = new System.Drawing.Size(170, 21);
			this.comboPlayers.TabIndex = 5;
			this.comboPlayers.SelectedIndexChanged += new System.EventHandler(this.ComboPlayersSelectedIndexChanged);
			// 
			// buttonPrev
			// 
			this.buttonPrev.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonPrev.Location = new System.Drawing.Point(118, 39);
			this.buttonPrev.Name = "buttonPrev";
			this.buttonPrev.Size = new System.Drawing.Size(29, 23);
			this.buttonPrev.TabIndex = 6;
			this.buttonPrev.Text = "9";
			this.buttonPrev.UseCompatibleTextRendering = true;
			this.buttonPrev.UseVisualStyleBackColor = true;
			this.buttonPrev.Click += new System.EventHandler(this.ButtonPrevClick);
			// 
			// buttonNext
			// 
			this.buttonNext.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonNext.Location = new System.Drawing.Point(153, 39);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(29, 23);
			this.buttonNext.TabIndex = 7;
			this.buttonNext.Text = ":";
			this.buttonNext.UseCompatibleTextRendering = true;
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.ButtonNextClick);
			// 
			// buttonPower
			// 
			this.buttonPower.Font = new System.Drawing.Font("Tahoma", 11F);
			this.buttonPower.Location = new System.Drawing.Point(189, 12);
			this.buttonPower.Name = "buttonPower";
			this.buttonPower.Size = new System.Drawing.Size(64, 23);
			this.buttonPower.TabIndex = 8;
			this.buttonPower.Text = "OFF";
			this.buttonPower.UseCompatibleTextRendering = true;
			this.buttonPower.UseVisualStyleBackColor = true;
			this.buttonPower.Click += new System.EventHandler(this.ButtonPowerClick);
			// 
			// sliderVolume
			// 
			this.sliderVolume.LargeChange = 10;
			this.sliderVolume.Location = new System.Drawing.Point(260, 3);
			this.sliderVolume.Maximum = 100;
			this.sliderVolume.Name = "sliderVolume";
			this.sliderVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.sliderVolume.Size = new System.Drawing.Size(45, 70);
			this.sliderVolume.TabIndex = 9;
			this.sliderVolume.TickFrequency = 25;
			this.sliderVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.sliderVolume.ValueChanged += new System.EventHandler(this.SliderVolumeValueChanged);
			// 
			// systemHotkeyPlay
			// 
			this.systemHotkeyPlay.Shortcut = System.Windows.Forms.Keys.MediaPlayPause;
			this.systemHotkeyPlay.Pressed += new System.EventHandler(this.SystemHotkeyPlayPressed);
			// 
			// systemHotkeyStop
			// 
			this.systemHotkeyStop.Shortcut = System.Windows.Forms.Keys.MediaStop;
			this.systemHotkeyStop.Pressed += new System.EventHandler(this.SystemHotkeyStopPressed);
			// 
			// systemHotkeyNext
			// 
			this.systemHotkeyNext.Shortcut = System.Windows.Forms.Keys.MediaNextTrack;
			this.systemHotkeyNext.Pressed += new System.EventHandler(this.SystemHotkeyNextPressed);
			// 
			// systemHotkeyPrev
			// 
			this.systemHotkeyPrev.Shortcut = System.Windows.Forms.Keys.MediaPreviousTrack;
			this.systemHotkeyPrev.Pressed += new System.EventHandler(this.SystemHotkeyPrevPressed);
			// 
			// systemHotkeyVolUp
			// 
			this.systemHotkeyVolUp.Shortcut = System.Windows.Forms.Keys.VolumeUp;
			this.systemHotkeyVolUp.Pressed += new System.EventHandler(this.SystemHotkeyVolUpPressed);
			// 
			// systemHotkeyVolDown
			// 
			this.systemHotkeyVolDown.Shortcut = System.Windows.Forms.Keys.VolumeDown;
			this.systemHotkeyVolDown.Pressed += new System.EventHandler(this.SystemHotkeyVolDownPressed);
			// 
			// buttonPrefs
			// 
			this.buttonPrefs.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.buttonPrefs.Location = new System.Drawing.Point(189, 39);
			this.buttonPrefs.Name = "buttonPrefs";
			this.buttonPrefs.Size = new System.Drawing.Size(29, 23);
			this.buttonPrefs.TabIndex = 10;
			this.buttonPrefs.Text = "@";
			this.buttonPrefs.UseCompatibleTextRendering = true;
			this.buttonPrefs.UseVisualStyleBackColor = true;
			this.buttonPrefs.Click += new System.EventHandler(this.ButtonPrefsClick);
			// 
			// buttonInfo
			// 
			this.buttonInfo.Font = new System.Drawing.Font("Webdings", 9.75F);
			this.buttonInfo.Location = new System.Drawing.Point(224, 39);
			this.buttonInfo.Name = "buttonInfo";
			this.buttonInfo.Size = new System.Drawing.Size(29, 23);
			this.buttonInfo.TabIndex = 11;
			this.buttonInfo.Text = "i";
			this.buttonInfo.UseCompatibleTextRendering = true;
			this.buttonInfo.UseVisualStyleBackColor = true;
			this.buttonInfo.Click += new System.EventHandler(this.ButtonInfoClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.labelAlbum);
			this.groupBox1.Controls.Add(this.labelArtist);
			this.groupBox1.Controls.Add(this.labelTitle);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(13, 74);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(284, 75);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Now Playing";
			this.groupBox1.UseCompatibleTextRendering = true;
			// 
			// labelAlbum
			// 
			this.labelAlbum.Location = new System.Drawing.Point(70, 49);
			this.labelAlbum.Name = "labelAlbum";
			this.labelAlbum.Size = new System.Drawing.Size(208, 14);
			this.labelAlbum.TabIndex = 5;
			this.labelAlbum.Text = "Album";
			this.labelAlbum.UseCompatibleTextRendering = true;
			// 
			// labelArtist
			// 
			this.labelArtist.Location = new System.Drawing.Point(70, 35);
			this.labelArtist.Name = "labelArtist";
			this.labelArtist.Size = new System.Drawing.Size(208, 14);
			this.labelArtist.TabIndex = 4;
			this.labelArtist.Text = "Artist";
			this.labelArtist.UseCompatibleTextRendering = true;
			// 
			// labelTitle
			// 
			this.labelTitle.Location = new System.Drawing.Point(70, 21);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(208, 14);
			this.labelTitle.TabIndex = 3;
			this.labelTitle.Text = "Title";
			this.labelTitle.UseCompatibleTextRendering = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 14);
			this.label3.TabIndex = 2;
			this.label3.Text = "Album";
			this.label3.UseCompatibleTextRendering = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 14);
			this.label2.TabIndex = 1;
			this.label2.Text = "Artist";
			this.label2.UseCompatibleTextRendering = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(7, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title";
			this.label1.UseCompatibleTextRendering = true;
			// 
			// refreshTimer
			// 
			this.refreshTimer.Interval = 5000;
			this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimerTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 161);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonInfo);
			this.Controls.Add(this.buttonPrefs);
			this.Controls.Add(this.sliderVolume);
			this.Controls.Add(this.buttonPower);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.buttonPrev);
			this.Controls.Add(this.comboPlayers);
			this.Controls.Add(this.buttonPause);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonPlay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "MainForm";
			this.Text = "WinSlim";
			((System.ComponentModel.ISupportInitialize)(this.sliderVolume)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelArtist;
		private System.Windows.Forms.Label labelAlbum;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonInfo;
		private System.Windows.Forms.Button buttonPrefs;
		private CodeProject.SystemHotkey.SystemHotkey systemHotkeyVolDown;
		private CodeProject.SystemHotkey.SystemHotkey systemHotkeyVolUp;
		private CodeProject.SystemHotkey.SystemHotkey systemHotkeyPrev;
		private CodeProject.SystemHotkey.SystemHotkey systemHotkeyNext;
		private CodeProject.SystemHotkey.SystemHotkey systemHotkeyStop;
		private System.ComponentModel.IContainer components;
		private CodeProject.SystemHotkey.SystemHotkey systemHotkeyPlay;
		private System.Windows.Forms.TrackBar sliderVolume;
		private System.Windows.Forms.Button buttonPower;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonPrev;
		private System.Windows.Forms.ComboBox comboPlayers;
		private System.Windows.Forms.Button buttonPause;
		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.Button buttonStop;
		#endregion
		
		
		internal SlimCli Client {
		    get {
		        return client;		        
		    }
		}
		
		internal bool reconnect(string host, int port) {
			client = new SlimCli(host, port);		  
			
			bool connected = client != null && Client.Connected;
			
			if (connected) {
			    server = client.getServer();

    			Player[] players = server.getPlayers();
	    	    foreach(Player player in players) {
		    	    comboPlayers.Items.Add(player);
		        }
    			
    			if (comboPlayers.Items.Count > 0) {
    			    comboPlayers.SelectedIndex = 0;		
    			} else {
    			    MessageBox.Show("Can't find any connected players!");
    			}
			
    			writePref("host", host);
	    		writePref("port", port);
			}
			
			return connected;
		}
		
		public bool Expanded {
		    get {
		        return expanded;
		    }
		    set {
		        expanded = value;
		        if (expanded) {
                    this.Height = 185;
                    refreshAll();
                    refreshTimer.Start();
		        } else {
	   		        this.Height = 100;
	   		        refreshTimer.Stop();
		        }
		    
		    }
		}
		
		
		private Player selectedPlayer() {
		    return (Player)comboPlayers.SelectedItem;
		}
		
		void ButtonPlayClick(object sender, System.EventArgs e)
		{
		    selectedPlayer().play();
		    refreshAll();
		}
		
		void ButtonStopClick(object sender, System.EventArgs e)
		{
		    selectedPlayer().stop();
		    refreshAll();
		}
		
		void ButtonPauseClick(object sender, System.EventArgs e)
		{
		    selectedPlayer().pause();
		    refreshAll();
		}	
		
		void ButtonPrevClick(object sender, System.EventArgs e)
		{
		    selectedPlayer().prevTrack();
		    refreshAll();
		}
		
		void ButtonNextClick(object sender, System.EventArgs e)
		{
		    selectedPlayer().nextTrack();
		    refreshAll();
		}
		
		void ButtonPowerClick(object sender, System.EventArgs e)
		{
		    Player player = selectedPlayer();
		    player.Power = !player.Power;
		    refreshAll();		    
		}
		
				
		void ComboPlayersSelectedIndexChanged(object sender, System.EventArgs e) {
		    refreshAll();
		}
		
		void SliderVolumeValueChanged(object sender, System.EventArgs e){
		    selectedPlayer().Volume = sliderVolume.Value;
		}
		
		void SystemHotkeyPlayPressed(object sender, System.EventArgs e) {
			Player player = selectedPlayer();
			if (player.State == Player.PlayerState.PLAY) {
			    player.pause();
			} else {
			    player.play();
			}
			refreshAll();
		}
		
		void SystemHotkeyStopPressed(object sender, System.EventArgs e)	{
		    selectedPlayer().stop();
		    refreshAll();
		}
		
		void SystemHotkeyNextPressed(object sender, System.EventArgs e)	{
			selectedPlayer().nextTrack();
			refreshAll();
		}
		
		void SystemHotkeyPrevPressed(object sender, System.EventArgs e)	{
			selectedPlayer().prevTrack();
			refreshAll();			
		}
		
		void SystemHotkeyVolUpPressed(object sender, System.EventArgs e) {
		    selectedPlayer().volUp();
			refreshAll();			
		}
		
		void SystemHotkeyVolDownPressed(object sender, System.EventArgs e) {
			selectedPlayer().volDown();
			refreshAll();			
		}

		void refreshAll() {
		    Player player = selectedPlayer();
		    if (player.Power) {
		        buttonPlay.Enabled = true;
		        buttonStop.Enabled = true;
		        buttonPause.Enabled = true;
		        buttonNext.Enabled = true;
		        buttonPrev.Enabled = true;
		        buttonPower.Enabled = true;
		        buttonPower.Text = "OFF";	
		        groupBox1.Enabled = true;
		        
		        switch (player.State) {
		            case Player.PlayerState.PLAY:
		                buttonPlay.ForeColor = Color.Red;
		                buttonStop.ForeColor = Color.Black;
		                buttonPause.ForeColor = Color.Black;
		                break;
		            case Player.PlayerState.STOP:
		                buttonPlay.ForeColor = Color.Black;
		                buttonStop.ForeColor = Color.Red;
		                buttonPause.ForeColor = Color.Black;
		                break;
		            case Player.PlayerState.PAUSE:
		                buttonPlay.ForeColor = Color.Black;
		                buttonStop.ForeColor = Color.Black;
		                buttonPause.ForeColor = Color.Red;
		                break;		                
		        }
		        
		        sliderVolume.Enabled = true;
		        sliderVolume.Value = (int)player.Volume;
		        
		        if (expanded) {
        		    Track currentTrack = selectedPlayer().CurrentTrack;
        		    if (currentTrack != null) {
    		            labelAlbum.Text = currentTrack.Album;
	    	            labelArtist.Text = currentTrack.Artist;
		                labelTitle.Text = currentTrack.Title;
        		    } else {
        		        labelAlbum.Text = "";
	    	            labelArtist.Text = "";
		                labelTitle.Text = "";
        		    }
		        }
		        
		    } else {
		        buttonPlay.Enabled = false;
		        buttonStop.Enabled = false;
		        buttonPause.Enabled = false;
		        buttonNext.Enabled = false;
		        buttonPrev.Enabled = false;
		        buttonPower.Enabled = true;
		        buttonPower.Text = "ON";		        		        
		        sliderVolume.Enabled = false;
		        sliderVolume.Value = (int)player.Volume;
		        groupBox1.Enabled = false;
		        labelAlbum.Text = "";
	            labelArtist.Text = "";
                labelTitle.Text = "";
		    }		    
		}
		
		void ButtonPrefsClick(object sender, System.EventArgs e)
		{
		    prefForm.ShowDialog();
		}
		
		private void writePref(string key, object value) {
		    RegistryKey softwareKey = Registry.CurrentUser.OpenSubKey("Software", true);
		    RegistryKey winslimKey = softwareKey.CreateSubKey("WinSlim");
		    winslimKey.SetValue(key, value);
		}
		
		private object readPref(string key, object defaultVal) {
		    RegistryKey softwareKey = Registry.CurrentUser.OpenSubKey("Software");
		    RegistryKey winslimKey = softwareKey.OpenSubKey("WinSlim");
		    if (winslimKey != null) {
		        object val = winslimKey.GetValue(key);		        
		        return val == null ? defaultVal : val;
		    } else {
		        return defaultVal;
		    }
		}
		
		
		
		void ButtonInfoClick(object sender, System.EventArgs e)	{
            this.Expanded = !this.Expanded;
		}
		
		void RefreshTimerTick(object sender, System.EventArgs e) {
		    refreshAll();
		}
	}
}
