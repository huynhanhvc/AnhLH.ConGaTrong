using AnhLH.ConGaTrong.Client.Dtos;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnhLH.ConGaTrong.Client
{
    public partial class Main : Form
    {
        private static string customerCode = "";
        public Main()
        {
            InitializeComponent();
            LoadListOrders();
            LoadListTicket();
        }

        private void txtTicketNumber_TextChanged(object sender, EventArgs e)
        {
            CheckTicketNumber(txtTicketNumber.Text);
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            CheckPhoneNumber(txtPhoneNumber.Text);
        }

        void CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length >= 10)
            {
                var cust = Service.GetCustomer(phoneNumber);
                if (cust != null)
                {
                    txtCustomerName.Text = cust.CustomerName;
                    customerCode = cust.CustomerCode;
                }
                else
                {
                    frmRegister frm = new frmRegister(phoneNumber);
                    frm.G_EvenReturnRegister += EvenReturnRegister;
                    frm.ShowDialog();
                }
            }
        }

        void CheckTicketNumber(string number)
        {           
            if (!string.IsNullOrEmpty(number))
            {
                int num = Convert.ToInt32(number);
                if (num <= 0 || num > 9)
                {
                    DialogResult result;
                    result = MessageBox.Show("Chỉ được chọn dãy số từ 1 đến 9!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        txtTicketNumber.Text = "";
                    }
                }
            }
        }

        void EvenReturnRegister(object sender, EventArgs e)
        {
            CustomersDto dataTable = sender as CustomersDto;

            customerCode = dataTable.CustomerCode;
            txtCustomerName.Text = dataTable.CustomerName;
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                string ticketNumber = txtTicketNumber.Text;
                string phoneNumber = txtPhoneNumber.Text;
                string customerName = txtCustomerName.Text;
                string remark = txtRemark.Text;

                if (string.IsNullOrEmpty(ticketNumber))
                {
                    MessageBox.Show(string.Format("Vui lòng chọn số!"),
                                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTicketNumber.Focus();
                }

                if (string.IsNullOrEmpty(phoneNumber))
                {
                    MessageBox.Show(string.Format("Chưa nhập thông tin số điện thoại!"),
                                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPhoneNumber.Focus();
                }

                if (string.IsNullOrEmpty(customerName))
                {
                    MessageBox.Show(string.Format("Chưa nhập thông tin người tham gia!"),
                                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCustomerName.Focus();
                }

                OrderDto orderDto = new OrderDto()
                {
                    CustomerCode = customerCode,
                    CustomerName = customerName,
                    PhoneNumber = phoneNumber,
                    TicketNumber = int.Parse(ticketNumber),
                    Remark = remark,
                        
                };
                var order = Service.CreatedOrder(orderDto);

                if (order != null)
                {
                    DialogResult result;
                    result = MessageBox.Show(string.Format("Đặt thành công số {0} cho slot mở {1}", ticketNumber, order.TicketCode), 
                                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result == DialogResult.OK)
                    {
                        LoadListOrders();
                        txtTicketNumber.Text = "";
                        txtPhoneNumber.Text = "";
                        txtCustomerName.Text = "";
                        txtRemark.Text = "";
                    }
                }    
                else
                {
                    DialogResult result;
                    result = MessageBox.Show(string.Format("Mỗi slot bạn chỉ được đặt 1 số!", ticketNumber, order.TicketCode),
                                                "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        void LoadListOrders()
        {
            dgvOrders.DataSource = null;
            dgvOrders.Refresh();

            dgvOrders.DataSource = Service.GetListOrder();
        }

        void LoadListTicket()
        {
            dgvTicket.DataSource = null;
            dgvTicket.Refresh();

            dgvTicket.DataSource = Service.GetListTicket();
        }
    
        private void txtPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            CheckPhoneNumber(txtPhoneNumber.Text);
        }

        private void txtPhoneNumber_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            CheckPhoneNumber(txtPhoneNumber.Text);
        }

        private void timer_Ticket_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute == 0 )
            {
                Service.CreatedTicket();
                LoadListTicket();
            }
        }
    }
}
