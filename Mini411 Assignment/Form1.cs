using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini411_Assignment
{
    public partial class Form1 : Form
    {
        string[] NameArray = new string[100];  //Declare global variables
        string[] PhoneArray = new string[100];
        int iCurrentIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strName, strPhone;

                lbNames.Items.Clear();
                lbPhone.Items.Clear();

                strName = txtName.Text.Trim();
                strPhone = txtPhone.Text.Trim();

                if(string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtName.Text)) //check to see if the textboxes are blank
                {
                    MessageBox.Show("Please fill out all values");
                    txtName.Clear();
                    txtPhone.Clear();
                    return;
                }
                    if (iCurrentIndex < 100) //checks the array's index
                    {
                        NameArray[iCurrentIndex] = strName; //adds name in the current index of the array
                        PhoneArray[iCurrentIndex] = strPhone;//adds phone number in the current index of the array
                        iCurrentIndex++;
                    }
                    else // if index value exceeds the size of the array
                    {
                        MessageBox.Show("No more space! Please delete someone to add more.");
                    }
                    MessageBox.Show("Successfully added");
                    lblCustomers.Text = "Number of Customers: " + iCurrentIndex; //if user has been added outputs the number of customers
                    txtName.Clear();
                    txtPhone.Clear();
                }
            catch
            {
                MessageBox.Show("Enter valid information!");
                txtName.Clear();
                txtPhone.Clear();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            int i;

            lbNames.Items.Clear();
            lbPhone.Items.Clear();

            for (i = 0; i < iCurrentIndex; i++) //loop to display names and phone numbers
            {
                lbNames.Items.Add(NameArray[i]); //outputs names to lbnames
                lbPhone.Items.Add(PhoneArray[i]); //outputs phone numbers to lbphone
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            try
            {
                int i, counter;
                string strName;

                strName = txtName.Text.Trim().ToLower();

                lbNames.Items.Clear();
                lbPhone.Items.Clear();

                counter = 0;

                for (i = 0; i < iCurrentIndex; i++) //loop to check if the 411 has the name entered
                {
                    if (NameArray[i].Trim().ToLower() == strName) //if the entered name is available in the array
                    {
                        lbNames.Items.Add(NameArray[i]); //displays the name of searched person
                        lbPhone.Items.Add(PhoneArray[i]);//displays the number of searched person
                        counter++;
                    }
                }
                if (counter == 0) //if the person does not exist, shows an error
                {
                    MessageBox.Show("Name does not exist in 411!");
                    txtName.Clear();
                    txtPhone.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Enter valid information!");
                txtName.Clear();
                txtPhone.Clear();
                lbNames.Items.Clear();
                lbPhone.Items.Clear();
            }
        }

        private void btnSearchNumber_Click(object sender, EventArgs e)
        {
            try
            {
                int i, counter;
                string strPhone;

                lbNames.Items.Clear();
                lbPhone.Items.Clear();

                strPhone = txtPhone.Text.Trim();

                counter = 0;

                for (i = 0; i < iCurrentIndex; i++) //loop to check if the 411 has the phone number entered 
                {
                    if (PhoneArray[i].Trim().ToLower() == strPhone) //if the entered phone number is available in the array
                    {
                        lbNames.Items.Add(NameArray[i]); //displays the name of the person with the entered phone number
                        lbPhone.Items.Add(PhoneArray[i]); //displays the phone number in of the person
                        counter++;
                    }
                }
                if (counter == 0) //if the phone number does not exist, shows an error
                {
                    MessageBox.Show("Number does not exist in 411!");
                    txtName.Clear();
                    txtPhone.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Enter valid information!");
                txtName.Clear();
                txtPhone.Clear();
                lbNames.Items.Clear();
                lbPhone.Items.Clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i, iCounter;
            string strName, strPhone;
            
            lbNames.Items.Clear();
            lbPhone.Items.Clear();

            strName = txtName.Text.Trim().ToLower();
            strPhone = txtPhone.Text.Trim().ToLower();

            iCounter = 0;

            if (string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtName.Text)) //check to see if the textboxes are blank
            {
                MessageBox.Show("Please fill out all values");
                return;
            }
            for (i = 0; i < iCurrentIndex; i++)
            {
                if (NameArray[i].Trim().ToLower() == strName) //checks the name to edit
                {
                    PhoneArray[i] = strPhone; // replaces the current phone number with the entered phone number
                    iCounter++;
                    MessageBox.Show("Sucessfully Edited");
                    txtName.Clear();
                    txtPhone.Clear();
                }
            }
            if (iCounter == 0)//if person doesn't exist, shows error.
            {
                MessageBox.Show("This person does not exist in 411!");
                txtName.Clear();
                txtPhone.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int i, j, counter;
                string strName, strPhone;

                lbNames.Items.Clear();
                lbPhone.Items.Clear();

                strName = txtName.Text.Trim().ToLower();
                strPhone = txtPhone.Text.Trim().ToLower();

                counter = 0;

                if (string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please fill out all values");
                    txtName.Clear();
                    txtPhone.Clear();
                    return;
                }
                else
                {
                    for (i = 0; i < iCurrentIndex; i++)
                    {
                        if (NameArray[i].Trim().ToLower() == strName && PhoneArray[i].Trim().ToLower() == strPhone) //checks if user selected a name or phone number
                        {
                            if (i == 99)
                            {
                                iCurrentIndex = iCurrentIndex - 1; //removes the name needed to be deleted
                                MessageBox.Show("Successfully Deleted!");//sucessfully deleted
                                txtName.Clear();
                                txtPhone.Clear();
                                return;
                            }
                            else
                            {
                                for (j = i; j < iCurrentIndex; j++)
                                {
                                    NameArray[j] = NameArray[j + 1]; //moves the names up the list
                                    PhoneArray[j] = PhoneArray[j + 1]; //moves the phone numbers up the list
                                    iCurrentIndex = iCurrentIndex - 1; //removes the name needed to be deleted
                                    lblCustomers.Text = "Number of Customers: " + iCurrentIndex.ToString(); //subtracts the total number of customers
                                    MessageBox.Show("Successfully Deleted!");//sucessfully deleted
                                    txtName.Clear();
                                    txtPhone.Clear();
                                    return;
                                }
                            }
                            counter = counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        MessageBox.Show("Delete failed: Wrong number or Name");
                        txtName.Clear();
                        txtPhone.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Enter valid information!");
                txtName.Clear();
                txtPhone.Clear();
                lbNames.Items.Clear();
                lbPhone.Items.Clear();
            }
        }

        private void lbNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = lbNames.SelectedIndex;
            lbPhone.SelectedIndex = index;
        }

        private void lbPhone_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index;
            index = lbPhone.SelectedIndex;
            lbNames.SelectedIndex = index;
        }
    }
}
