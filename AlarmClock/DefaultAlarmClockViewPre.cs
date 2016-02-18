
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
internal partial class DefaultAlarmClockView : Form, IAlarmClockView
{
    public DefaultAlarmClockView(Interfaces.IClockView clockView, Interfaces.IAlarmView alarmView)
    {
        this.__clockView = clockView;
        this.__alarmView = alarmView;
        var l_clockView = (System.Windows.Forms.Control)clockView;
        var l_alarmView = (System.Windows.Forms.UserControl)alarmView;
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.btnTurnMeOff = new System.Windows.Forms.Button();
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
        this.tableLayoutPanel1.Controls.Add(l_clockView, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.btnTurnMeOff, 0, 3);
        this.tableLayoutPanel1.Controls.Add(l_alarmView, 0, 1);
        this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 12);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 4;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.09925331F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.90075F));
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(255, 65534);
        this.tableLayoutPanel1.TabIndex = 3;
        l_clockView.Location = new System.Drawing.Point(4, 4);
        l_clockView.Name = "defaultClockView1";
        l_clockView.Size = new System.Drawing.Size(247, 58);
        l_clockView.TabIndex = 3;
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
        l_alarmView.AutoSize = true;
        l_alarmView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        l_alarmView.Location = new System.Drawing.Point(4, 69);
        l_alarmView.Name = "defaultAlarmView1";
        l_alarmView.Size = new System.Drawing.Size(53, 20);
        l_alarmView.TabIndex = 5;
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
        originalAlarmColor = this.BackColor;
    }

    public DefaultAlarmClockView()
    {
        InitializeComponent();
        originalAlarmColor = this.BackColor;
    }

    public event EventHandler TurnOffAlarm;

    private Interfaces.IClockView __clockView;
    private Interfaces.IAlarmView __alarmView;
    private Color originalAlarmColor;
    public void StartAlarm()
    {
        this.BackColor = Color.Red;
    }

    public void StopAlarm()
    {
        this.BackColor = originalAlarmColor;
    }

    private void btnTurnMeOff_Click(object sender, EventArgs e)
    {
        var handler = TurnOffAlarm;
        if (handler != null)
        {
            handler(this, new EventArgs());
        }
    }


}
}