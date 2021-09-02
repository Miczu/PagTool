using System.Windows.Forms;

namespace PagTool
{
    //an extremely basic input dialog
    public partial class AddToListDialog : Form
    {
        public AddToListDialog()
        {
            InitializeComponent();
        }

        public new string Show()
        {
            this.ActiveControl = textBox_Input; //give focus to the text field immediately
            
            //show the dialog
            var result = ShowDialog();
            
            //check if user clicked OK 
            if (result == DialogResult.OK)
            {
                return textBox_Input.Text;
            } else
                return "";
        }
    }
}