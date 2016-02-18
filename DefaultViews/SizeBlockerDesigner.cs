using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace DefaultViews
{
    
    public class SizeBlockerDesigner : ControlDesigner
    {

        protected override void PostFilterProperties(System.Collections.IDictionary
        properties)

        {
            StreamWriter writer = new StreamWriter(@"C:\Users\Tony\Documents\StylusPoints\sizeBlocker.txt");
            writer.WriteLine("In PostFilterProperties");
            writer.Close();
            base.PostFilterProperties(properties);
            properties.Remove("Size");

        }

    }
}
