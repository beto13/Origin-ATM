using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class ATM : Form
    {
        private bool CambiarTap = false;
        private bool TarjetaValida = false;
        private bool PinValido = false;
        private Tarjeta objTarjeta = new Tarjeta();

        public ATM()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();

            foreach (TabPage item in Pantalla.TabPages)
            {
                if (item.Text != "Home")
                {
                    item.Text = "";
                }
            }
        }

        private void Pantalla_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!CambiarTap) e.Cancel = true;
        }

        private void Pantalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TabPage item in Pantalla.TabPages)
            {
                item.Text = "";
            }

            switch (Pantalla.SelectedIndex)
            {
                case 0:
                    Pantalla.SelectedTab.Text = "Home";
                    break;
                case 1:
                    Pantalla.SelectedTab.Text = "PIN";
                    break;
                case 2:
                    Pantalla.SelectedTab.Text = "Operaciones";
                    break;
                case 3:
                    Pantalla.SelectedTab.Text = "Balance";
                    break;
                case 4:
                    Pantalla.SelectedTab.Text = "Retiro";
                    break;
                case 5:
                    Pantalla.SelectedTab.Text = "Resumen";
                    break;
                default:
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void Limpiar()
        {
            lblError.Text = "";
            txtPin.Text = "";
            txtNumeroTarjeta.Text = "";
            txtMonto.Text = "";
            objTarjeta = null;
            TarjetaValida = false;
            CambiarTap = false;
            PinValido = false;
        }

        private void Salir()
        {
            Limpiar();
            CambiarTap = true;
            Pantalla.SelectedIndex = 0;
            CambiarTap = false;
        }

        private void Volver(int num)
        {
            CambiarTap = true;
            Pantalla.SelectedIndex = Pantalla.SelectedIndex - num;
            CambiarTap = false;
        }

        private void Avanzar(int num)
        {
            CambiarTap = true;
            Pantalla.SelectedIndex = Pantalla.SelectedIndex + num;
            CambiarTap = false;
        }

    #region "Teclado Numerico"

        private void IngresarNumero(int indice, string numero)
        {
            switch (indice)
            {
                case 0:
                    if (TarjetaValida == false)
                    {
                        if (txtNumeroTarjeta.Text.Length < 19)
                        {
                            txtNumeroTarjeta.Text = txtNumeroTarjeta.Text + numero;
                        }
                    }
                    break;

                case 1:
                    if (TarjetaValida == true)
                    {
                        if (txtPin.Text.Length < 4)
                        {
                            txtPin.Text = txtPin.Text + numero;
                        }
                    }
                    break;

                case 4:
                    if (PinValido == true )
                    {
                        if (txtMonto.Text.Length < 6)
                        {
                            txtMonto.Text = txtMonto.Text + numero ;
                        }
                    }
                        break;

                default:
                    break;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex,"1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            IngresarNumero(Pantalla.SelectedIndex, "0");
        }
    #endregion

    #region "Home"
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (Pantalla.SelectedIndex == 0)
            {
                  txtNumeroTarjeta.Text = "";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Pantalla.SelectedIndex==0)
            {
                string numeroTarjeta = txtNumeroTarjeta.Text.Replace("-", "");

                if (numeroTarjeta.Length < 16)
                {
                    lblError.Text = "El número debe tener 16 digitos.";
                    txtNumeroTarjeta.Text = "";
                    Avanzar(6);
                }
                else
                {
                    TarjetaAdm objAdmin = new TarjetaAdm();
                    objTarjeta = objAdmin.ValidarTarjeta(numeroTarjeta);

                    if (objTarjeta != null)
                    {
                        TarjetaValida = true;
                        txtNumeroTarjeta.Text = "";
                        Avanzar(1);
                    }
                    else
                    {
                        lblError.Text = "Número de tarjeta inválido.";
                        txtNumeroTarjeta.Text = "";
                        Avanzar(6);
                    }
                }
            }
        }

        private void txtNumeroTarjeta_TextChanged(object sender, EventArgs e)
        {
            int cont = txtNumeroTarjeta.Text.Length;

            if (cont == 4 || cont == 9 || cont == 14)
            {
                txtNumeroTarjeta.Text = txtNumeroTarjeta.Text + "-";
                txtNumeroTarjeta.SelectionStart = cont + 1;
            }
        }

        private void txtNumeroTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    #endregion

    #region "Balance"
        private void btnBalanceSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void btnBalanceAtras_Click(object sender, EventArgs e)
        {
            Volver(1);
        }
    #endregion

    #region "PIN"

        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnPinAceptar_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text;

            if (TarjetaValida == true)
            {
                if (pin.Length < 4)
                {
                    lblError.Text = "El PIN debe tener 4 digitos.";
                    txtPin.Text = "";
                    Avanzar(5);
                }
                else
                {
                    if (objTarjeta!=null)
                    {
                        if (objTarjeta.Pin==pin)
                        {
                            PinValido = true;
                            txtPin.Text = "";;
                            Avanzar(1);
                        }
                        else
                        {
                            TarjetaAdm objAdm=new TarjetaAdm();
                            int idTarjeta = objTarjeta.IdTarjeta;

                            switch (objTarjeta.Intentos)
                            {
                                case 0:
                                    if (objAdm.ActualizarTarjeta("INTENTOS", idTarjeta, "1") == true)
                                    {
                                        objTarjeta = objAdm.BuscarTarjeta(idTarjeta);
                                    }
                                    txtPin.Text = "";;
                                    lblError.Text = "PIN incorrecto.";
                                    Avanzar(5);
                                    break;

                                case 1:
                                    if (objAdm.ActualizarTarjeta("INTENTOS", idTarjeta, "1") == true)
                                    {
                                        objTarjeta = objAdm.BuscarTarjeta(idTarjeta);
                                    }
                                    txtPin.Text = "";
                                    lblError.Text = "PIN incorrecto.";
                                    Avanzar(5);
                                    break;

                                case 2:
                                    if (objAdm.ActualizarTarjeta("INTENTOS", idTarjeta, "1") == true)
                                    {
                                        objTarjeta = objAdm.BuscarTarjeta(idTarjeta);
                                    }
                                    txtPin.Text = "";;
                                    lblError.Text = "PIN incorrecto.";
                                    Avanzar(5);
                                    break;

                                case 3:
                                    if (objAdm.ActualizarTarjeta("BLOQUEAR", idTarjeta, "1") == true)
                                    {
                                        objTarjeta = objAdm.BuscarTarjeta(idTarjeta);
                                    }
                                    Limpiar();
                                    lblError.Text = "Tarjeta Bloqueda.";
                                    Avanzar(5);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void btnPinLimpiar_Click(object sender, EventArgs e)
        {
            txtPin.Text = "";;
        }

        private void btnPinSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }
    #endregion

    #region "Retiro"
        private void btnRetiroAceptar_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text != "")
            {
                string entrada = txtMonto.Text.Replace(".", "");
                int monto = Convert.ToInt32(entrada);
                int idOperacion = 0;

                if (monto > 0)
                {
                    if (monto <= 10000)
                    {
                        if (monto % 500 == 0)
                        {
                            if (monto <= objTarjeta.Saldo)
                            {
                                TarjetaAdm objAdmin = new TarjetaAdm();

                                idOperacion = objAdmin.Retirar(objTarjeta.IdTarjeta, monto);

                                if (idOperacion > 0)
                                {
                                    OperacionAdm objAdm = new OperacionAdm();
                                    Operacion objOp = new Operacion();
                                    objOp = objAdm.ConsultarOperacion(idOperacion);

                                    if (objOp != null)
                                    {
                                        lblFecha.Text = objOp.Fecha.ToString();
                                        lblOperacion.Text = objOp.IdOperacion.ToString();
                                        lblTarjeta.Text = objOp.IdTarjeta.ToString();
                                        lblMonto.Text = objOp.Monto.ToString();
                                        Avanzar(1);
                                    }
                                }
                            }
                            else
                            {
                                txtMonto.Text = "";
                                lblError.Text = "Fondos insuficientes.";
                                Avanzar(2);
                            }
                        }
                        else
                        {
                            txtMonto.Text = "";
                            lblError.Text = "El monto debe ser multiplo de 500.";
                            Avanzar(2);
                        }
                    }
                    else
                    {
                        txtMonto.Text = "";
                        lblError.Text = "El monto maximo es 10.000$.";
                        Avanzar(2);
                    }
                }
                else
                {
                    txtMonto.Text = "";
                    lblError.Text = "Monto inválido.";
                    Avanzar(2);
                }
            }
            else
            {
                lblError.Text = "Debe ingresar un monto.";
                Avanzar(2);
            }
        }

        private void btnRetiroLimpiar_Click(object sender, EventArgs e)
        {
             txtMonto.Text = "";
        }

        private void btnRetiroSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtMonto.Text))
            {
                int Position = this.txtMonto.SelectionStart;
                Decimal result = 0;
                if (Decimal.TryParse(this.txtMonto.Text, out result))
                {
                    this.txtMonto.Text = result.ToString("###,###,###");
                    this.txtMonto.SelectionStart = Position + 1;
                }
            }
        }
    #endregion

    #region "Operaciones"
        private void btnOpBalance_Click(object sender, EventArgs e)
        {
            OperacionAdm objAdm = new OperacionAdm();
            Operacion objOp = new Operacion();
            objOp.TipoOperacion = "Balance";
            objOp.Fecha = DateTime.Now;
            objOp.Monto= objTarjeta.Saldo;
            objOp.IdTarjeta = objTarjeta.IdTarjeta;
            objAdm.RegistrarOperacion(objOp);

            lblBalanceNroT.Text = objTarjeta.NumeroTarjeta.ToString();
            lblBalanceFecha.Text = objTarjeta.FechaVencimiento.ToShortDateString();
            lblBalanceSaldo.Text = objTarjeta.Saldo.ToString();
            Avanzar(1);
        }

        private void btnOpRetiro_Click(object sender, EventArgs e)
        {
            Avanzar(2);
        }

        private void btnOpSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void btnResumenSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }
        #endregion

        private void btnErrorAtras_Click(object sender, EventArgs e)
        {
            if (TarjetaValida==false && PinValido==false)
            {
                Volver(6);
            }
            else if (TarjetaValida == true && PinValido == false)
            {
                Volver(5);
            }
            else if (TarjetaValida == true && PinValido == true)
            {
                Volver(2);
            }
        }
    }
}
