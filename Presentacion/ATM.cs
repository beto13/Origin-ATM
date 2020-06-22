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
            lblError.Text = "";
            lblPinError.Text = "";
            lblRetirarError.Text = "";

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

        private void Limpiar(int indice)
        {
            switch (indice)
            {
                case 0:
                    txtNumeroTarjeta.Text = "";
                    lblError.Text = "";
                    break;

                case 1:
                    txtPin.Text = "";
                    lblPinError.Text = "";
                    break;

                case 4:
                    txtMonto.Text = "";
                    lblRetirarError.Text = "";
                    break;

                default:
                    lblError.Text = "";
                    txtPin.Text = "";
                    lblPinError.Text = "";
                    txtNumeroTarjeta.Text = "";
                    txtMonto.Text = "";
                    objTarjeta = null;
                    TarjetaValida = false;
                    CambiarTap = false;
                    PinValido = false;
                    break;
            }
        }

        private void Salir()
        {
            Limpiar(9);
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
                Limpiar(0);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           string numeroTarjeta = txtNumeroTarjeta.Text.Replace("-", "");

            if (numeroTarjeta.Length < 16)
            {
                lblError.Text = "El número debe tener 16 digitos.";
            }
            else
            {
                TarjetaAdm objAdmin = new TarjetaAdm();
                objTarjeta = objAdmin.ValidarTarjeta(numeroTarjeta);

                if (objTarjeta!=null)
                {
                    TarjetaValida = true;
                    Limpiar(0);
                    Avanzar(1);
                }
                else
                {
                    lblError.Text = "Número de tarjeta inválido.";
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
                    lblPinError.Text = "El PIN debe tener 4 digitos.";
                }
                else
                {
                    if (objTarjeta!=null)
                    {
                        if (objTarjeta.Pin==pin)
                        {
                            PinValido = true;
                            Limpiar(1);
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
                                    Limpiar(1);
                                    lblPinError.Text = "PIN incorrecto.";
                                    break;

                                case 1:
                                    if (objAdm.ActualizarTarjeta("INTENTOS", idTarjeta, "1") == true)
                                    {
                                        objTarjeta = objAdm.BuscarTarjeta(idTarjeta);
                                    }
                                    Limpiar(1);
                                    lblPinError.Text = "PIN incorrecto.";
                                    break;

                                case 2:
                                    if (objAdm.ActualizarTarjeta("INTENTOS", idTarjeta, "1") == true)
                                    {
                                        objTarjeta = objAdm.BuscarTarjeta(idTarjeta);
                                    }
                                    Limpiar(1);
                                    lblPinError.Text = "PIN incorrecto.";
                                    break;

                                case 3:
                                    if (objAdm.ActualizarTarjeta("BLOQUEAR", idTarjeta, "1") == true)
                                    {
                                        objTarjeta = objAdm.BuscarTarjeta(idTarjeta);
                                    }
                                    Limpiar(9);
                                    lblPinError.Text = "Tarjeta Bloqueda.";
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
            Limpiar(1);
        }

        private void btnPinSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }
    #endregion

    #region "Retiro"
        private void btnRetiroAceptar_Click(object sender, EventArgs e)
        {
            string entrada = txtMonto.Text.Replace(".","");
            int monto = Convert.ToInt32(entrada);
            int idOperacion = 0;

            if (monto > 0)
            {
                if (monto<=10000)
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
                            lblRetirarError.Text = "Fondos insuficientes.";
                        }
                    }
                    else
                    {
                        txtMonto.Text = "";
                        lblRetirarError.Text = "El monto debe ser multiplo de 500.";
                    }
                }
                else
                {
                    txtMonto.Text = "";
                    lblRetirarError.Text = "El monto maximo es 10.000$.";
                }
            }
            else
            {
                txtMonto.Text = "";
                lblRetirarError.Text = "Monto inválido.";
            }
        }

        private void btnRetiroLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(4);
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

    }
}
