using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SharpMap;
using SharpMap.Layers;
using SharpMap.Data.Providers;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        // we start with the connection string
        static string connstr = "Data Source=192.168.2.60;Initial Catalog=gisdb;Persist Security Info=True;User ID=sa;Password=cai123";
        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“gisdbDataSet.PT_TOWN”中。您可以根据需要移动或删除它。
           // this.pT_TOWNTableAdapter.Fill(this.gisdbDataSet.PT_TOWN);

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            
            VectorLayer layCountries = new VectorLayer("Countries");
            layCountries.DataSource = new ShapeFile("GeoData/World/countries.shp", true);
            layCountries.Style.Fill = new SolidBrush(Color.GreenYellow);
            layCountries.Style.Outline = Pens.Black;
            layCountries.Style.EnableOutline = true;
            layCountries.SRID = 4326;


            this.mapBox1.Map.Layers.Add(layCountries);

            this.mapBox1.Map.ZoomToExtents();
            this.mapBox1.Refresh();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.mapBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VectorLayer layCountries = new VectorLayer("Mssql");
            //SqlServer2008 MSSQLDP = new SharpMap.Data.Providers.SqlServer2008(connstr, "PT_TOWN", "ID", SqlServerSpatialObjectType.Geography);
            //MSSQLDP.Table = "gisdb.dbo.PT_TOWN";
            //MSSQLDP.TableSchema = String.Empty;
             layCountries.DataSource = new SharpMap.Data.Providers.SqlServer2008(connstr, "gisdb.dbo.PT_TOWN", "geom","ID",SqlServerSpatialObjectType.Geography); 
            //  (connstr, "PT_TOWN", "geom", "ID");
           // layCountries.DataSource = MSSQLDP;


            layCountries.Style.Fill = new SolidBrush(Color.GreenYellow);
            layCountries.Style.Outline = Pens.Black;
            layCountries.Style.EnableOutline = true;
            //layCountries.SRID = 4326;
            

            this.mapBox1.Map.Layers.Add(layCountries);
            this.mapBox1.Map.ZoomToExtents();
            this.mapBox1.Refresh();



        }
    }
}
