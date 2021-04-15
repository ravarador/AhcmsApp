﻿using AutomatedHumanContactMonitorySystemApp.Helpers;
using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutomatedHumanContactMonitorySystemApp.Forms.LoginForms
{
    public partial class LoginForm : Form
    {
        public IAppUserRepository AppUserRepository { get; set; }
        public LoginForm(IAppUserRepository appUserRepository)
        {
            AppUserRepository = appUserRepository;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var appUser = new AppUser()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            var placeId = AppUserRepository.IsAuthorized(appUser);

            if (placeId != 0)
            {
                PlaceHelper.PlaceId = placeId;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Username/Password");
            }
        }
    }
}
