using BLL;
using ENTITY;
using PROYECTO_FINAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
namespace PROYECTO_RIEGO_AUTOMATICO
{
    public partial class INICIAR : Form
    {
        private int intentos = 3;
        ServiciosUsuario serviciosusuario;
        List<Usuario> listaUsuario;
        public INICIAR()
        {
            InitializeComponent();
            serviciosusuario = new ServiciosUsuario();
            listaUsuario = serviciosusuario.MostrarTodos().ToList();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public bool ValidarInformacion(string nombreUsu, string contra)
        {
            if (listaUsuario == null || listaUsuario.Count == 0)
            {
                MessageBox.Show("No hay usuarios cargados.");
                return false;
            }

            foreach (var lis in listaUsuario)
            {
                if (lis.Accedio == 1)
                {
                    lis.Accedio = 0;
                    serviciosusuario.Actualizar(lis);
                }

            }

            if (intentos <= 0)
            {
                MessageBox.Show("Ha excedido el número máximo de intentos fallidos. La aplicación se cerrará.");
                Application.Exit();
                return false;
            }

            foreach (var usuario in listaUsuario)
            {
                if (usuario.NombreUsuario == nombreUsu)
                {
                    if (usuario.Password == contra)
                    {
                        MessageBox.Show("ACCESO CONCEDIDO");
                        usuario.Accedio = 1;
                        serviciosusuario.Actualizar(usuario);
                        MENUPRINCIPAL form = new MENUPRINCIPAL();
                        form.Show();
                        this.Hide();
                        return true;
                    }
                    else
                    {
                        intentos--;
                        MessageBox.Show($"La contraseña es incorrecta. Te quedan {intentos} intento(s).");
                        return false;
                    }
                }
            }

            intentos--;
            MessageBox.Show("Usuario no encontrado. Verifique el nombre de usuario. " + intentos + " Intentos.");
            return false;

        }
        private void INICIAR_Load(object sender, EventArgs e)
        {

        }

        private void tbnIniciar_Click(object sender, EventArgs e)
        {
            ValidarInformacion(txtUsuario.Text, txtContraseña.Text);
        }

        private void btnCrearCuenta_Click_1(object sender, EventArgs e)
        {
            NuevoUsuario form3 = new NuevoUsuario();
            form3.Show();
            this.Hide();
        }
    }
}
