namespace AlarmClock
{
    partial class DefaultAlarmClockView
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
            this.defaultAlarmView1 = new AlarmClock.DefaultAlarmView();
            this.defaultClockView1 = new AlarmClock.DefaultClockView();
            this.btnTurnMeOff = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defaultAlarmView1
            // 
            this.defaultAlarmView1.Location = new System.Drawing.Point(40, 67);
            this.defaultAlarmView1.Name = "defaultAlarmView1";
            this.defaultAlarmView1.Size = new System.Drawing.Size(272, 124);
            this.defaultAlarmView1.TabIndex = 0;
            // 
            // defaultClockView1
            // 
            this.defaultClockView1.Location = new System.Drawing.Point(42, 12);
            this.defaultClockView1.Name = "defaultClockView1";
            this.defaultClockView1.Size = new System.Drawing.Size(150, 49);
            this.defaultClockView1.TabIndex = 1;
            // 
            // btnTurnMeOff
            // 
            this.btnTurnMeOff.Location = new System.Drawing.Point(65, 187);
            this.btnTurnMeOff.Name = "btnTurnMeOff";
            this.btnTurnMeOff.Size = new System.Drawing.Size(75, 23);
            this.btnTurnMeOff.TabIndex = 2;
            this.btnTurnMeOff.Text = "Turn Me Off !";
            this.btnTurnMeOff.UseVisualStyleBackColor = true;
            this.btnTurnMeOff.Click += new System.EventHandler(this.btnTurnMeOff_Click);
            // 
            // DefaultAlarmClockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 222);
            this.Controls.Add(this.btnTurnMeOff);
            this.Controls.Add(this.defaultClockView1);
            this.Controls.Add(this.defaultAlarmView1);
            this.Name = "DefaultAlarmClockView";
            this.Text = "An implementation of an Alarm Clock";
            this.ResumeLayout(false);

        }


        #endregion

        private DefaultAlarmView defaultAlarmView1;
        private DefaultClockView defaultClockView1;
        private System.Windows.Forms.Button btnTurnMeOff;
    }
}

