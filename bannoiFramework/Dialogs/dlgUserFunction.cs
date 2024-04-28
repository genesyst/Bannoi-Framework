using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bannoiFramework.Dataset;
using bannoiFramework.Models;
using bannoiFramework.Services;

namespace bannoiFramework.Dialogs
{
    public partial class dlgUserFunction : Form
    {
        private BNSDATA_EHREntities db;
        private string SYSTEMCODE;
        private SiginModel signinModel;
        private UserGantModel userGant;
        private IQueryable<VIEW_EHRSIGNIN> EHRSIGNIN;

        public dlgUserFunction(string SystemCode,SiginModel signinModel,UserGantModel userGantModel)
        {
            InitializeComponent();
            try
            {
                this.db = new BNSDATA_EHREntities();
                this.SYSTEMCODE = SystemCode.ToUpper();
                this.signinModel = signinModel;
                this.userGant = userGantModel;
                
                if (Convert.ToInt32(userGantModel.levelCode) >= 8)
                {
                    this.textBox1.Visible = true;
                    this.findUser(this.textBox1.Text.Trim());
                }
                else
                {
                    this.textBox1.Visible = false;
                    this.findUser(signinModel.userName);
                }

                int delCell = bnsServiceControl.getGridCellIndex(this.dataGridView1, "DEL");
                if (Convert.ToInt32(userGantModel.levelCode) < 9)
                {
                    this.dataGridView1.Columns[delCell].Visible = false;
                    this.dataGridView2.Visible = false;
                    this.textBox3.Visible = false;
                }
            }
            catch { throw; }
        }

        private void findEmployee(string findValue)
        {
            try
            {
                var signUser = (from p in this.db.SIN_USER 
                           where p.EMPCODE.Contains(findValue) || p.USERNAME.Contains(findValue) 
                           orderby p.USERNAME ascending
                           select new { p.USERNAME, p.EMPCODE,p.REC_ID });

                this.dataGridView2.DataSource = signUser.ToList();
            }
            catch { throw; }
        }

        private void findUser(string findValue)
        {
            try
            {
                this.EHRSIGNIN = this.db.VIEW_EHRSIGNIN.Where(
                    c=>c.EMPCODE.Contains(findValue) || 
                        c.USERNAME.Contains(findValue) || 
                        c.FULLNAME.Contains(findValue));
                this.dataGridView1.DataSource = this.EHRSIGNIN.Where(c=>c.SYSTEMCODE==this.SYSTEMCODE && c.GSTT!="X").ToList();
            }
            catch { throw; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.findUser(this.textBox1.Text.Trim());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    int userCell=bnsServiceControl.getGridCellIndex(this.dataGridView1,"USERNAME");
                    int delCell = bnsServiceControl.getGridCellIndex(this.dataGridView1, "DEL");
                    if (e.ColumnIndex == userCell)
                    {
                        #region
                        decimal userId = Convert.ToDecimal(this.dataGridView1.Rows[e.RowIndex].Cells["SIGNID"].Value);
                        this.usernameTxt.Text = this.dataGridView1.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString();
                        this.empcodeTxt.Text = this.dataGridView1.Rows[e.RowIndex].Cells["EMPCODE"].Value.ToString();
                        this.fullnameTxt.Text = this.dataGridView1.Rows[e.RowIndex].Cells["FULLNAME"].Value.ToString();
                        if (this.dataGridView1.Rows[e.RowIndex].Cells["ISADMIN"].Value.ToString() == "Y")
                            this.isadminChk.Checked = true;
                        else
                            this.isadminChk.Checked = false;

                        this.tabControl1.SelectedTab = this.tabControl1.TabPages[1];
                        #endregion
                    }
                    else if (e.ColumnIndex == delCell)
                    {
                        #region
                        if (MessageBox.Show("ต้องการยกเลิกผู้ใช้ " + this.dataGridView1.Rows[e.RowIndex].Cells["EMPCODE"].Value.ToString() + " หรือไม่?", "ยกเลิก",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            decimal id=Convert.ToDecimal(this.dataGridView1.Rows[e.RowIndex].Cells["SIGNID"].Value);
                            var data = this.db.SIN_USERGANT.Where(c=>c.SIGNID==id && c.SYSTEMCODE==this.SYSTEMCODE).FirstOrDefault();
                            if (data != null)
                            {
                                if (data.ISADMIN == "Y")
                                {
                                    MessageBox.Show("ไม่สามารถยกเลิกได้ เนื่องจากผู้ใช้อยู่ในระดับผู้ดูแลระบบ", "ยกเลิก", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    data.STT = "X";
                                    db.SaveChanges();

                                    this.findUser("");
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            catch { throw; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBox5.Text.Trim() == this.signinModel.userPassword)
                {
                    if (!String.IsNullOrEmpty(this.textBox6.Text))
                    {
                        if (this.textBox6.Text.Trim() == this.textBox2.Text.Trim())
                        {
                            using (BNSDATA_EHREntities dbUpdate = new BNSDATA_EHREntities())
                            {
                                var user = dbUpdate.SIN_USER.Where(c=>c.REC_ID==this.signinModel.userId).FirstOrDefault();
                                if (user != null)
                                {
                                    user.USERPW = this.textBox6.Text.Trim();
                                    dbUpdate.SaveChanges();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("กรุณายืนยันรหัสผ่านใหม่", ((Button)sender).Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                this.Close();
            }
            catch { throw; }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.panel1.Visible = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Trim() != this.signinModel.userPassword)
                ((TextBox)sender).BackColor = Color.OrangeRed;
            else
                ((TextBox)sender).BackColor = Color.LightGreen;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox3.Text.Length > 2)
            {
                this.findEmployee(this.textBox3.Text.Trim());
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    int cellSel = bnsServiceControl.getGridCellIndex(this.dataGridView2, "SEL");
                    if (e.ColumnIndex == cellSel)
                    {
                        #region
                        if (MessageBox.Show("ต้องการให้สิทธิ์ผู้ใช้งานกับรหัส " + this.dataGridView2.Rows[e.RowIndex].Cells["EMPCODE2"].Value.ToString() + " หรือไม่?", 
                            "ให้สิทธิ์", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SIN_USERGANT gant = new SIN_USERGANT();
                            gant.GROUPCODE = "0";
                            gant.SIGNID = Convert.ToDecimal(this.dataGridView2.Rows[e.RowIndex].Cells["REC_ID"].Value);
                            gant.LEVELCODE = "3";
                            gant.SYSTEMCODE = this.SYSTEMCODE;
                            gant.SYSTEMVERSION = this.userGant.systemVersion;
                            gant.ISADMIN = "N";
                            gant.STT = "A";
                            gant.CREATE_BY = signinModel.empCode;
                            gant.CREATE_DATE = DateTime.Now;

                            if (bnsServiceDMP.gantUserTo(this.db, gant))
                            {
                                this.findUser("");
                            }
                            else
                            {
                                MessageBox.Show("ผิดพลาด...ไม่สามารถให้สิทธิ์ได้", "ให้สิทธิ์", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        #endregion
                    }
                }
            }
            catch { throw; }
        }
    }
}
