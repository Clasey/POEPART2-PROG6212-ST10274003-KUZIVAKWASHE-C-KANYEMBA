using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CMCS_UI
{
    public partial class MainWindow : Window
    {
        private List<Claim> claimsList = new List<Claim>();
        private string uploadedFilePath = string.Empty; // Initialize uploadedFilePath

        public MainWindow()
        {
            InitializeComponent();
            ClaimsList.ItemsSource = claimsList; // Binding the list of claims to the ListView
        }

        // Login Button Click
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "lecturer" && password == "password123")
            {
                MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Invalid Credentials!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Submit Claim Button Click
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(HoursWorkedTextBox.Text, out double hoursWorked) &&
                double.TryParse(HourlyRateTextBox.Text, out double hourlyRate))
            {
                double totalAmount = hoursWorked * hourlyRate;

                var newClaim = new Claim
                {
                    ClaimId = claimsList.Count + 1,
                    LecturerName = "John Doe",  // Can be dynamically set
                    DateSubmitted = ClaimDate.SelectedDate ?? DateTime.Now,
                    HoursWorked = hoursWorked,
                    HourlyRate = hourlyRate,
                    TotalAmount = totalAmount,
                    Status = "Pending",
                    SupportingDocument = uploadedFilePath
                };

                claimsList.Add(newClaim);
                ClaimsList.Items.Refresh(); // Refresh ListView

                MessageBox.Show("Claim Submitted Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for hours worked and hourly rate.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Upload Supporting Document
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Documents (*.pdf; *.docx; *.xlsx)|*.pdf;*.docx;*.xlsx",
                Title = "Select Supporting Document"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                if (new FileInfo(openFileDialog.FileName).Length > (5 * 1024 * 1024)) // Limiting file size to 5MB
                {
                    MessageBox.Show("File is too large. Please upload a file smaller than 5MB.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    uploadedFilePath = openFileDialog.FileName;
                    MessageBox.Show("File Uploaded Successfully: " + uploadedFilePath, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // Approve Claim
        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsList.SelectedItem is Claim selectedClaim)
            {
                selectedClaim.Status = "Approved";
                ClaimsList.Items.Refresh(); // Refresh ListView after status update
                MessageBox.Show("Claim Approved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Reject Claim
        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsList.SelectedItem is Claim selectedClaim)
            {
                selectedClaim.Status = "Rejected";
                ClaimsList.Items.Refresh(); // Refresh ListView after status update
                MessageBox.Show("Claim Rejected!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Event handler for GotFocus on UsernameTextBox
        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Username")
            {
                UsernameTextBox.Text = string.Empty;
                UsernameTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        // Event handler for LostFocus on UsernameTextBox
        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Username";
                UsernameTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        // Event handler for No Button Click
        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for No button click (e.g., navigate back to previous tab)
        }

        // Event handler for Yes Button Click
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for Yes button click (e.g., log out the user)
            MessageBox.Show("Logged out successfully!", "Logout", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    // Claim Class to manage claim data
    public class Claim
    {
        public int ClaimId { get; set; }
        public string? LecturerName { get; set; }
        public DateTime DateSubmitted { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public double TotalAmount { get; set; }
        public string? Status { get; set; }
        public string? SupportingDocument { get; set; } // File path to the supporting document
    }
}
