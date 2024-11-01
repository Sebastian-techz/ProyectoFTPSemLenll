using FluentFTP;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProyectoFTPSemLenll
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private FtpClient ftpClient;
        private string selectedFilePath;
        private string localPath;

        public object FtpFileSystemObjectType { get; private set; }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEstadoConexion = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.lblSeleccionarArchivoEstado = new System.Windows.Forms.Label();
            this.btnDescargarArchivo = new System.Windows.Forms.Button();
            this.lstArchivosServidor = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnEliminarArchivo = new System.Windows.Forms.Button();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(301, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Estado:";
            // 
            // lblEstadoConexion
            // 
            this.lblEstadoConexion.AutoSize = true;
            this.lblEstadoConexion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoConexion.Location = new System.Drawing.Point(379, 21);
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Size = new System.Drawing.Size(16, 24);
            this.lblEstadoConexion.TabIndex = 4;
            this.lblEstadoConexion.Text = "-";
            // 
            // txtServidor
            // 
            this.txtServidor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtServidor.Location = new System.Drawing.Point(134, 18);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(126, 22);
            this.txtServidor.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsuario.Location = new System.Drawing.Point(134, 54);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(126, 22);
            this.txtUsuario.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPassword.Location = new System.Drawing.Point(134, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(126, 22);
            this.txtPassword.TabIndex = 7;
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.Lime;
            this.btnConectar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(281, 78);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(99, 32);
            this.btnConectar.TabIndex = 8;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click_1);
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCargarArchivo.Enabled = false;
            this.btnCargarArchivo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.Location = new System.Drawing.Point(33, 396);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(183, 32);
            this.btnCargarArchivo.TabIndex = 11;
            this.btnCargarArchivo.Text = "Subir Archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = false;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click_1);
            // 
            // lblSeleccionarArchivoEstado
            // 
            this.lblSeleccionarArchivoEstado.AutoSize = true;
            this.lblSeleccionarArchivoEstado.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionarArchivoEstado.Location = new System.Drawing.Point(29, 143);
            this.lblSeleccionarArchivoEstado.Name = "lblSeleccionarArchivoEstado";
            this.lblSeleccionarArchivoEstado.Size = new System.Drawing.Size(260, 24);
            this.lblSeleccionarArchivoEstado.TabIndex = 14;
            this.lblSeleccionarArchivoEstado.Text = "Lista de Archivos del Servidor:";
            // 
            // btnDescargarArchivo
            // 
            this.btnDescargarArchivo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDescargarArchivo.Enabled = false;
            this.btnDescargarArchivo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarArchivo.Location = new System.Drawing.Point(222, 396);
            this.btnDescargarArchivo.Name = "btnDescargarArchivo";
            this.btnDescargarArchivo.Size = new System.Drawing.Size(183, 32);
            this.btnDescargarArchivo.TabIndex = 15;
            this.btnDescargarArchivo.Text = "Descargar";
            this.btnDescargarArchivo.UseVisualStyleBackColor = false;
            this.btnDescargarArchivo.Click += new System.EventHandler(this.btnDescargarArchivo_Click);
            // 
            // lstArchivosServidor
            // 
            this.lstArchivosServidor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lstArchivosServidor.Enabled = false;
            this.lstArchivosServidor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstArchivosServidor.FormattingEnabled = true;
            this.lstArchivosServidor.ItemHeight = 24;
            this.lstArchivosServidor.Location = new System.Drawing.Point(24, 172);
            this.lstArchivosServidor.Name = "lstArchivosServidor";
            this.lstArchivosServidor.Size = new System.Drawing.Size(561, 220);
            this.lstArchivosServidor.TabIndex = 16;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(33, 448);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(561, 46);
            this.progressBar.TabIndex = 17;
            // 
            // btnEliminarArchivo
            // 
            this.btnEliminarArchivo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEliminarArchivo.Enabled = false;
            this.btnEliminarArchivo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArchivo.Location = new System.Drawing.Point(411, 398);
            this.btnEliminarArchivo.Name = "btnEliminarArchivo";
            this.btnEliminarArchivo.Size = new System.Drawing.Size(183, 32);
            this.btnEliminarArchivo.TabIndex = 18;
            this.btnEliminarArchivo.Text = "Eliminar";
            this.btnEliminarArchivo.UseVisualStyleBackColor = false;
            this.btnEliminarArchivo.Click += new System.EventHandler(this.btnEliminarArchivo_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.BackColor = System.Drawing.Color.IndianRed;
            this.btnDesconectar.Enabled = false;
            this.btnDesconectar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesconectar.Location = new System.Drawing.Point(401, 77);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(124, 32);
            this.btnDesconectar.TabIndex = 19;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = false;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(640, 573);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnEliminarArchivo);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lstArchivosServidor);
            this.Controls.Add(this.btnDescargarArchivo);
            this.Controls.Add(this.lblSeleccionarArchivoEstado);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.lblEstadoConexion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Proyecto FTP";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnConectar_Click_1(object sender, System.EventArgs e)
        {
            // Inicializa el cliente FTP con las credenciales proporcionadas
            ftpClient = new FtpClient(txtServidor.Text, txtUsuario.Text, txtPassword.Text);

            try
            {
                // Conecta al servidor FTP
                ftpClient.Connect();
                

                // Actualiza el estado de la conexión
                lblEstadoConexion.Text = "Conectado";
                lblEstadoConexion.ForeColor = Color.Green;
                txtPassword.Clear();
                txtServidor.Clear();
                txtUsuario.Clear();
                btnConectar.Enabled = false;
                btnCargarArchivo.Enabled = true;
                btnDescargarArchivo.Enabled = true;
                btnEliminarArchivo.Enabled = true;
                lstArchivosServidor.Enabled = true;
                btnDesconectar.Enabled = true;
                refrescarLista();
                
            }
            catch (Exception ex)
            {
                // Maneja el error de conexión
                lblEstadoConexion.Text = "Desconectado";
                lblEstadoConexion.ForeColor = Color.Red;
                btnCargarArchivo.Enabled = false;
                btnDescargarArchivo.Enabled = false;
                lstArchivosServidor.Items.Clear();
                lstArchivosServidor.Enabled= false;
                btnEliminarArchivo.Enabled = false;
                MessageBox.Show($"Error al conectar: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtServidor.Clear();
                txtUsuario.Clear();
            }
        }

        private void btnCargarArchivo_Click_1(object sender, EventArgs e)
        {
            // Verifica si el cliente FTP está conectado
            if (ftpClient != null && ftpClient.IsConnected)
            {
                // Abre un diálogo para seleccionar el archivo a cargar
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Seleccionar archivo para cargar",
                    Filter = "Todos los archivos (*.*)|*.*"
                };

                // Verifica si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Guarda la ruta del archivo seleccionado en la variable localPath
                    localPath = openFileDialog.FileName;

                    try
                    {
                        // Reinicia el valor del ProgressBar antes de comenzar la carga
                        progressBar.Value = 0;

                        // Sube el archivo al servidor FTP con seguimiento del progreso
                        ftpClient.UploadFile(localPath, Path.GetFileName(localPath), FtpRemoteExists.Overwrite, false, FtpVerify.None, new Action<FtpProgress>(p =>
                        {
                            // Actualiza el ProgressBar con el porcentaje de progreso de la subida
                            progressBar.Value = (int)p.Progress;
                        }));

                        // Muestra un mensaje de éxito si el archivo se carga correctamente
                        MessageBox.Show("Archivo cargado con éxito.", "Carga Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refrescarLista();
                        progressBar.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        // Muestra un mensaje de error si ocurre algún problema durante la carga
                        MessageBox.Show($"Error al cargar el archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        progressBar.Value = 0;
                    }
                }
                else
                {
                    // Muestra un mensaje si no se selecciona ningún archivo en el diálogo
                    MessageBox.Show("No se ha seleccionado ningún archivo para cargar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Muestra un mensaje de advertencia si el cliente no está conectado
                MessageBox.Show("Debe estar conectado al servidor para cargar un archivo.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        
        private void btnDescargarArchivo_Click(object sender, EventArgs e)
        {
            // Verifica si el cliente FTP está conectado y si se ha seleccionado un archivo en la lista
            if (ftpClient != null && ftpClient.IsConnected && lstArchivosServidor.SelectedItem != null)
            {
                // Obtiene el nombre del archivo seleccionado en el ListBox
                string nombreArchivo = lstArchivosServidor.SelectedItem.ToString();

                // Configura un cuadro de diálogo para elegir dónde guardar el archivo descargado
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = nombreArchivo,
                    Title = "Guardar archivo como",
                    Filter = "Todos los archivos (*.*)|*.*"
                };

                // Verifica si el usuario seleccionó una ubicación para guardar el archivo
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Obtiene la ruta local donde se guardará el archivo descargado
                    string rutaLocal = saveFileDialog.FileName;

                    try
                    {
                        // Reinicia el ProgressBar para reflejar el progreso de la descarga
                        progressBar.Value = 0;

                        // Descargar el archivo con seguimiento del progreso
                        ftpClient.DownloadFile(rutaLocal, nombreArchivo, FtpLocalExists.Overwrite, FtpVerify.None, new Action<FtpProgress>(p =>
                        {
                            // Actualiza el ProgressBar con el porcentaje de progreso de la descarga
                            progressBar.Value = (int)p.Progress;
                        }));

                        // Muestra un mensaje de éxito si la descarga se completa
                        MessageBox.Show("Archivo descargado con éxito.", "Descarga Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        progressBar.Value = 0;
                    }
                    catch (Exception ex)
                    {
                        // Muestra un mensaje de error si ocurre algún problema durante la descarga
                        MessageBox.Show($"Error al descargar el archivo.", "Descarga Fallida" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                        progressBar.Value = 0;
                    }
                }
            }
            else
            {
                // Muestra un mensaje de advertencia si el cliente no está conectado o no se ha seleccionado un archivo
                MessageBox.Show("Por favor, asegúrese de seleccionar un archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnEliminarArchivo_Click(object sender, EventArgs e)
        {
            // Verifica si el cliente FTP está conectado
        if (ftpClient != null && ftpClient.IsConnected)
            {
                // Abre el diálogo para seleccionar el archivo en el servidor
                if (lstArchivosServidor.SelectedItem != null)
                {
                    string archivoSeleccionado = lstArchivosServidor.SelectedItem.ToString();

                    // Verifica si el archivo seleccionado no está vacío
                    if (!string.IsNullOrEmpty(archivoSeleccionado))
                    {
                        // Muestra el cuadro de diálogo de confirmación
                        DialogResult confirmacion = MessageBox.Show(
                            "¿Está seguro de que desea eliminar el archivo seleccionado?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                        );

                        // Si el usuario confirma la eliminación
                        if (confirmacion == DialogResult.Yes)
                        {
                            try
                            {
                                // Inicia el valor del ProgressBar en 0
                                progressBar.Value = 0;

                                // Elimina el archivo en el servidor
                                ftpClient.DeleteFile(archivoSeleccionado);

                                // Verifica si el archivo aún existe en el servidor
                                if (!ftpClient.FileExists(archivoSeleccionado))
                                {
                                    // Actualiza el ProgressBar al 100% si se eliminó con éxito
                                    progressBar.Value = 100;
                                    MessageBox.Show("Archivo eliminado con éxito.", "Eliminación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    progressBar.Value = 0;
                                    refrescarLista();
                                }
                                else
                                {
                                    // Muestra un mensaje de error si no se pudo eliminar el archivo
                                    MessageBox.Show("No se pudo eliminar el archivo. Verifique si el archivo existe.", "Error de eliminación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                // Muestra un mensaje de error si ocurre algún problema durante la eliminación
                                MessageBox.Show($"Error al eliminar el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        // Muestra un mensaje si no se selecciona ningún archivo
                        MessageBox.Show("Debe seleccionar un archivo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    // Muestra un mensaje si no hay selección en el ListBox
                    MessageBox.Show("Debe seleccionar un archivo de la lista.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Muestra un mensaje de advertencia si el cliente no está conectado
                MessageBox.Show("Debe estar conectado al servidor para eliminar un archivo.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void refrescarLista()
        {
            if (ftpClient != null && ftpClient.IsConnected)
            {
                try
                {
                    // Limpia el ListBox antes de agregar nuevos elementos
                    lstArchivosServidor.Items.Clear();

                    // Obtiene la lista de archivos y carpetas del servidor FTP
                    var archivos = ftpClient.GetListing();

                    // Añade los nombres de los archivos al ListBox
                    foreach (var archivo in archivos)
                    {
                        // Verifica si el elemento es de tipo archivo
                        if (archivo.Type == FtpObjectType.File)
                        {
                            lstArchivosServidor.Items.Add(archivo.Name);
                        }
                    }

                    if (lstArchivosServidor.Items.Count == 0)
                    {
                        MessageBox.Show("No hay archivos disponibles en el servidor.", "Sin archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al listar los archivos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, conéctese al servidor antes de intentar seleccionar un archivo.", "Conexión Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ftpClient.Disconnect();
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            ftpClient.Disconnect();
            lblEstadoConexion.Text = "Desconectado";
            lblEstadoConexion.ForeColor = Color.Red;
            btnCargarArchivo.Enabled = false;
            btnDescargarArchivo.Enabled = false;
            lstArchivosServidor.Items.Clear();
            lstArchivosServidor.Enabled = false;
            btnEliminarArchivo.Enabled = false;
            btnConectar.Enabled = true;
            MessageBox.Show($"Se ha desconectado con éxito. ", "Finalizó la conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtServidor.Clear();
            txtUsuario.Clear();
        }
    }
}
