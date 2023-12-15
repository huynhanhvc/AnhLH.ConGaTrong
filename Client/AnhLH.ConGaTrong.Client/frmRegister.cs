using AnhLH.ConGaTrong.Client.Dtos;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnhLH.ConGaTrong.Client
{
    public partial class frmRegister : Form
    {
        public event EventHandler G_EvenReturnRegister;
        public frmRegister(string phone)
        {
            
            InitializeComponent();
            txtPhoneNumber.Text = phone;
            txtPhoneNumber.Enabled = false;

            string[] ports = new string[2] { "Nam", "Nữ"};
            cboGender.DataSource = ports.Select(p => new KeyValuePair<string, string>(p, p)).ToList();
           
            cboGender.DisplayMember = "Key";
            cboGender.ValueMember = "Value";
            cboGender.SelectedValue = ports[0];
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool gender = cboGender.SelectedValue.Equals("Nam") ? true : false ;
            CustomersDto customersDto = new CustomersDto()
            {
                CustomerName = txtCustomerName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Gender = gender,
                Birthday = Convert.ToDateTime(txtBirthday.Text),
                Address = txtAddress.Text
            };

            CustomersDto customers = Service.CreatedCustomer(customersDto);
            G_EvenReturnRegister.Invoke(customers, e);

            DialogResult result;
            result = MessageBox.Show("Đăng ký thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {            
                Close();
            }
        }
    }
}
