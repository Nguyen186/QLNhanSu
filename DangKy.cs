﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace QLNhanSu
{
    public partial class DangKy : Form
    {
        //Data source(khac nhau)
        string dataSource = @"Data Source=DESKTOP-152SFQ3;Initial Catalog=Quanlynhasu_3F;Integrated Security=True";
        SqlConnection connection;
        SqlCommand command;
        public DangKy()
        {
            InitializeComponent();
        }
        private void DangKy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(dataSource);
            connection.Open();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
           
            try
            {
                command = connection.CreateCommand();
                string taiKhoan = txtTaikhoan.Text;
                string matKhau = txtMatkhau.Text;
                command.CommandText = "INSERT INTO DANGNHAP (TaiKhoan, MatKhau) VALUES ('" + taiKhoan + "', '" + matKhau + "')";
                command.ExecuteNonQuery();

                this.Hide();
                DangNhap dangNhap = new DangNhap();
                dangNhap.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
        }

    }
}
