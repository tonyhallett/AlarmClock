using DefaultViews;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.defaultClockView1 = new DefaultViews.DefaultClockView();
            this.btnTurnMeOff = new System.Windows.Forms.Button();
            this.defaultAlarmView1 = new AlarmClock.DefaultAlarmView();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.defaultClockView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTurnMeOff, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.defaultAlarmView1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.09925331F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.90075F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(255, 65534);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // defaultClockView1
            // 
            this.defaultClockView1.Location = new System.Drawing.Point(4, 4);
            this.defaultClockView1.Name = "defaultClockView1";
            this.defaultClockView1.Size = new System.Drawing.Size(247, 58);
            this.defaultClockView1.TabIndex = 3;
            // 
            // btnTurnMeOff
            // 
            this.btnTurnMeOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTurnMeOff.Location = new System.Drawing.Point(4, 32767);
            this.btnTurnMeOff.Name = "btnTurnMeOff";
            this.btnTurnMeOff.Size = new System.Drawing.Size(247, 37);
            this.btnTurnMeOff.TabIndex = 4;
            this.btnTurnMeOff.Text = "Turn off alarm";
            this.btnTurnMeOff.UseVisualStyleBackColor = true;
            // 
            // defaultAlarmView1
            // 
            this.defaultAlarmView1.AutoSize = true;
            this.defaultAlarmView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.defaultAlarmView1.Location = new System.Drawing.Point(4, 69);
            this.defaultAlarmView1.Name = "defaultAlarmView1";
            this.defaultAlarmView1.Size = new System.Drawing.Size(53, 20);
            this.defaultAlarmView1.TabIndex = 5;
            // 
            // DefaultAlarmClockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(120, 268);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DefaultAlarmClockView";
            this.Text = "Alarm Clock";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DefaultClockView defaultClockView1;
        private System.Windows.Forms.Button btnTurnMeOff;
        private DefaultAlarmView defaultAlarmView1;
    }
}

