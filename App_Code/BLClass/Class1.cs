using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

    class Class1
    {
        public void Validatecurrency(TextBox sender, System.Windows.Forms.KeyPressEventArgs e)
        {
           
            if (char.IsNumber(e.KeyChar) == true)
            {
            }
            else if (Convert.ToChar(e.KeyChar) == 8)
            {
            }
            else if (Convert.ToChar(e.KeyChar) == 46)
            {
                for (int i = 0; i < sender.Text.Length; i++)
                {
                    if (sender.Text.Substring(i, 1) == ".")
                    {
                        e.Handled = true;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                e.Handled = true;
            }
                
                
                //48 to 57 = 0 to 9 and 8 = Back Space 46 = . 32 = Escape 
        }

      
        public void ValidatePhoneno(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
             if (char.IsNumber(e.KeyChar) == true)
            {
            }
            else if (Convert.ToChar(e.KeyChar) == 8)
            {
            }
            else
             {
                    e.Handled = true;
             }
            }

        }


