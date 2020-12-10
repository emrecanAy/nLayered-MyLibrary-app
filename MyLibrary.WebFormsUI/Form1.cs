using MyLibrary.Business.Abstract;
using MyLibrary.Business.Concrete;
using MyLibrary.DataAccess.Concrete.EntityFramework;
using MyLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary.WebFormsUI
{
    public partial class Form1 : Form
    {      
        public Form1()
        {
            InitializeComponent();
            _bookService = new BookManager(new EfBookDal());
        }

        private void LoadBooks()
        {
            dgwBook.DataSource = _bookService.GetAll();
        }

        private IBookService _bookService;
        private void Form1_Load(object sender, EventArgs e)
        {            
            dgwBook.DataSource = _bookService.GetAll();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _bookService.Add(new Book
            {
                BookName = tbxName.Text,
                Author = tbxAuthor.Text,
                CategoryName = cmbCategory.Text,
                Page = int.Parse(mskPage.Text),
                Status = rchStatus.Text

            });
            MessageBox.Show("Kitap eklendi!","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            LoadBooks();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _bookService.Update(new Book
            {
                BookId = Convert.ToInt32(dgwBook.CurrentRow.Cells[0].Value),
                BookName = tbxName.Text,
                CategoryName = cmbCategory.Text,
                Author = tbxAuthor.Text,
                Page = int.Parse(mskPage.Text),
                Status = rchStatus.Text

            });
            MessageBox.Show("Kitap güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBooks();
        }

        private void dgwBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwBook.CurrentRow;
            tbxName.Text = row.Cells[1].Value.ToString();          
            cmbCategory.Text = row.Cells[2].Value.ToString();
            tbxAuthor.Text = row.Cells[3].Value.ToString();
            mskPage.Text = row.Cells[4].Value.ToString();
            rchStatus.Text = row.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwBook.CurrentRow != null)
            {
                try
                {
                _bookService.Delete(new Book
                {
                    BookId = Convert.ToInt32(dgwBook.CurrentRow.Cells[0].Value)
                });
                    MessageBox.Show("Kitap silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LoadBooks();
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                
            }

            
        }

        private void tbxBookName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxBookName.Text))
            {
                dgwBook.DataSource = _bookService.GetBooksByBookName(tbxBookName.Text);
            }
            else
            {
                LoadBooks();
            }

        }

        //Borderless form to move
        int mov;
        int movX;
        int movY;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov==1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.Firebrick;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Freelance Yazılım Geliştirici \n\n Emrecan AY \n\n codemrecan@gmail.com \n\n -------- \n\n Sosyal Medya=@codemrecan ", "İletişim", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
