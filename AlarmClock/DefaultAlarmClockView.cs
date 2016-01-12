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
    public DefaultAlarmClockView(AlarmClock.IAlarmView alarmView, AlarmClock.IClockView clockView)
    {
        this.__alarmView = alarmView;
        this.__clockView = clockView;
        var l_alarmView = (System.Windows.Forms.Control)alarmView;
        var l_clockView = (System.Windows.Forms.Control)clockView;
        this.btnTurnMeOff = new System.Windows.Forms.Button();
        this.SuspendLayout();
        l_alarmView.Location = new System.Drawing.Point(40, 67);
        l_alarmView.Name = "defaultAlarmView1";
        l_alarmView.Size = new System.Drawing.Size(272, 124);
        l_alarmView.TabIndex = 0;
        l_clockView.Location = new System.Drawing.Point(42, 12);
        l_clockView.Name = "defaultClockView1";
        l_clockView.Size = new System.Drawing.Size(150, 49);
        l_clockView.TabIndex = 1;
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
        this.Controls.Add(l_clockView);
        this.Controls.Add(l_alarmView);
        this.Name = "DefaultAlarmClockView";
        this.Text = "An implementation of an Alarm Clock";
        this.ResumeLayout(false);
        originalAlarmColor = this.BackColor;
    }

    public DefaultAlarmClockView()
    {
        InitializeComponent();
        originalAlarmColor = this.BackColor;
    }

    public event EventHandler TurnOffAlarm;

    private AlarmClock.IAlarmView __alarmView;
    private AlarmClock.IClockView __clockView;
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