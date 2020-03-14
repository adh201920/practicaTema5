using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaTema5
{
    public partial class Form1 : Form
    {
        private TextBox aluNombre;
        private Label AlumnoNombreLabel;
        private TextBox aluNota;
        private Label NotaAlumnoLabel;
        private TextBox listaAlumnos;
        private Button button1;
        Alumnos misAlumnos = new Alumnos();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno miAlumno = new Alumno();
            String miAlumnoStr;

            miAlumno.Nombre = aluNombre.Text;
            miAlumno.Nota = Convert.ToInt32(aluNota.Text);
            miAlumnoStr = aluNombre.Text + " " + aluNota.Text + (miAlumno.Aprobado ? " Aprobado" : " Suspenso")+"\n";
            listaAlumnos.AppendText(miAlumnoStr);
            misAlumnos.Agregar(miAlumno);
        }

        private void InitializeComponent()
        {
            this.aluNombre = new System.Windows.Forms.TextBox();
            this.AlumnoNombreLabel = new System.Windows.Forms.Label();
            this.aluNota = new System.Windows.Forms.TextBox();
            this.NotaAlumnoLabel = new System.Windows.Forms.Label();
            this.listaAlumnos = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aluNombre
            // 
            this.aluNombre.Location = new System.Drawing.Point(46, 50);
            this.aluNombre.Name = "aluNombre";
            this.aluNombre.Size = new System.Drawing.Size(196, 22);
            this.aluNombre.TabIndex = 0;
            // 
            // AlumnoNombreLabel
            // 
            this.AlumnoNombreLabel.AutoSize = true;
            this.AlumnoNombreLabel.Location = new System.Drawing.Point(44, 25);
            this.AlumnoNombreLabel.Name = "AlumnoNombreLabel";
            this.AlumnoNombreLabel.Size = new System.Drawing.Size(136, 17);
            this.AlumnoNombreLabel.TabIndex = 1;
            this.AlumnoNombreLabel.Text = "Nombre del Alumno:";
            // 
            // aluNota
            // 
            this.aluNota.Location = new System.Drawing.Point(385, 51);
            this.aluNota.Name = "aluNota";
            this.aluNota.Size = new System.Drawing.Size(234, 22);
            this.aluNota.TabIndex = 2;
            // 
            // NotaAlumnoLabel
            // 
            this.NotaAlumnoLabel.AutoSize = true;
            this.NotaAlumnoLabel.Location = new System.Drawing.Point(387, 34);
            this.NotaAlumnoLabel.Name = "NotaAlumnoLabel";
            this.NotaAlumnoLabel.Size = new System.Drawing.Size(115, 17);
            this.NotaAlumnoLabel.TabIndex = 3;
            this.NotaAlumnoLabel.Text = "Nota del alumno:";
            // 
            // listaAlumnos
            // 
            this.listaAlumnos.Location = new System.Drawing.Point(49, 104);
            this.listaAlumnos.Multiline = true;
            this.listaAlumnos.Name = "listaAlumnos";
            this.listaAlumnos.ReadOnly = true;
            this.listaAlumnos.Size = new System.Drawing.Size(570, 256);
            this.listaAlumnos.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar Alumno";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(857, 399);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listaAlumnos);
            this.Controls.Add(this.NotaAlumnoLabel);
            this.Controls.Add(this.aluNota);
            this.Controls.Add(this.AlumnoNombreLabel);
            this.Controls.Add(this.aluNombre);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }




    class Alumno
    {
        private string nombre;
        private int nota;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Nota
        {
            get { return nota; }
            set
            {
                if (value >= 0 && value <= 10)
                    nota = value;
            }
        }
        public Boolean Aprobado
        {
            get
            {
                if (nota >= 5)
                    return true;
                else
                    return false;
            }
        }
    }

    class Alumnos
    {
        private ArrayList listaAlumnos = new ArrayList();

        // Agrega un nuevo alumno a la lista
        //        
        public void Agregar(Alumno alu)
        {
            listaAlumnos.Add(alu);
        }

        // Devuelve el alumno que está en la posición num
        //
        public Alumno Obtener(int num)
        {
            if (num >= 0 && num <= listaAlumnos.Count)
            {
                return ((Alumno)listaAlumnos[num]);
            }
            return null;
        }

        // Devuelve la nota media de los alumnos
        //
        public float Media
        {
            get
            {
                if (listaAlumnos.Count == 0)
                    return 0;
                else
                {
                    float media = 0;
                    for (int i = 0; i < listaAlumnos.Count; i++)
                    {
                        media += ((Alumno)listaAlumnos[i]).Nota;
                    }
                    return (media / listaAlumnos.Count);
                }
            }
        }
    }



}
    

