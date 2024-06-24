-----------
****
დელეგატზე სტრიქონით მოშაობა უნდა გადასცე ref string
    delegate void Del2Delegate(ref string str);



****
str.Replace('A', 'C') ყველა ჩარის შეცვლა

char[] xmovan = { 'ა', 'ე', 'ი', 'ო', 'უ' };
foreach (char c in xmovan)
{
    str = str.Replace(c, '0');
}

------------
****
თვისება პლიუს ინდექსატორი
int this[int indexator] { get; set; }


****
არჩევანი ინტერფეისებს შორის
inter3ver1 inter1;

inter3ver1.Metodi1() {
  rafaca
}

Metodi_a()
{
    return inter1.Metodi1();
}


-----------------------
****

DataColumn[] keys = new DataColumn[1];
keys[0] = ds.Tables["Personali"].Columns["PersonaliID"];

ds.Tables["Personali"].PrimaryKey = keys;

DataRow rowfind = ds.Tables["Personali"].Rows.Find(1);



***
 DataView dv = new DataView(ds.Tables["Personali"]);

 dv.RowFilter = "personaliID = 4";

 dv.Sort = "tarigi_dawyebis DESC, gadasaxdeli_l ASC";

  dataGridView1.DataSource = dv;



****
object qaliRaod = ds.Tables["Shemkveti"].Compute("COUNT(shemkvetiID)", "sqesi = 'ქალი'");


--------------------
*****
SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

ds.Tables["Personali"].Rows[5]["staji"] = axaliMnishvn;
adapter.Update(ds, "Personali");





******
DataRow dr = ds.Tables["Personali"].NewRow();

dr["staji"] = staji;
dr["asaki"] = asaki;
ds.Tables["Personali"].Rows.Add(dr);

adapter.Update(ds, "Personali"); 






*******
 DataRow row = ds.Tables["Personali"].Rows.Find(2);

 if (row != null )
 {
     row.Delete();
     adapter.Update(ds, "Personali");
     label1.Text = "Waishalaaaa";
 } else { label1.Text = "ar waishala"; }







***************

 DataRelation relacia = new DataRelation("relacia",
     ds.Tables["Personali"].Columns["personaliID"],
     ds.Tables["Xelshekruleba"].Columns["personaliID"], 
     false
 );

 ds.Relations.Add( relacia );

 conn.Close();

 // Binding the data to DataGridViews
 BindingSource bindingSource1 = new BindingSource();
 bindingSource1.DataSource = ds;
 bindingSource1.DataMember = "Personali";

 BindingSource bindingSource2 = new BindingSource();
 bindingSource2.DataSource = bindingSource1;
 bindingSource2.DataMember = "relacia";

 dataGridView1.DataSource = bindingSource1;
 dataGridView2.DataSource = bindingSource2;




-----------------------------


*******
SqlCommand cmd = conn.CreateCommand();
cmd.CommandText = " SELECT COUNT(shemkvetiID) FROM Shemkveti WHERE qalaqi = N'თბილისი'";
object coooooo = cmd.ExecuteScalar();



*******

cmd.CommandText = "INSERT INTO Personali(gvari, saxeli, xelfasi) VALUES (@gvariVal, @saxeliVal, @xelfasiVal)";
cmd.Parameters.Add("@gvariVal", SqlDbType.NVarChar, 20);
cmd.Parameters.Add("@saxeliVal", SqlDbType.NVarChar, 20);
cmd.Parameters.Add("@xelfasiVal", SqlDbType.Float);

cmd.Parameters["@gvariVal"].Value = "Maisadze";
cmd.Parameters["@saxeliVal"].Value = "Nikoloz";
cmd.Parameters["@xelfasiVal"].Value = 1500.31;

int rowsAffected = cmd.ExecuteNonQuery();



-----------------------------

******
 var Fasi = from manqna in manqanebi
   where manqna.CarBrand == "Toyota"
   select new { manqna.CountryOfManufacture, manqna.Price };


*********

    var gafiltrul = from xelsh in ds.Tables["Xelshekruleba"].AsEnumerable()
                    where double.Parse(xelsh["vali_l"].ToString()) > 500.00
                    select xelsh;
